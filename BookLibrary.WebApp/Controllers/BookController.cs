using AutoMapper;
using BookLibrary.WebApp.Models;
using domain.Aggregates.Author;
using domain.Aggregates.Book;
using domain.Aggregates.Category;
using domain.Aggregates.Checkout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;


namespace BookLibrary.WebApp.Controllers
{
    public class BookController : Controller
    {
        /// <summary>
        /// Dependency Injections from IOC Container
        /// </summary>
        private readonly IBookRepository _bookRepository;

        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger; // add a logger field

        public BookController(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper, ILogger<BookController> logger)
        {
            this._bookRepository = bookRepository;
            this._authorRepository = authorRepository;
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
            _logger = logger;
        }

        // GET: BookController Display List Of the Books
        public async Task<ActionResult> Index(string currentFilter, string searchString, int? page)
        {
            try
            {
                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;
                IQueryable<Book> books;
                if (!String.IsNullOrEmpty(searchString))
                {
                    books = _bookRepository.Filter(searchString);
                }
                else
                {
                    books = _bookRepository.GetBooksAsync();
                }

                int pageSize = 4;
                int pageNumber = (page ?? 1);
                var bookViewModel = _mapper.Map<List<BookViewModel>>(books);
                return View(bookViewModel.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "An Error occured while gettings the books");
                return View("Error", new ErrorViewModel());
            }
        }

        // to Show The Book Status if it is not in the Library
        // GET: BookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var book = await _bookRepository.FindByIdAsync(id);
                var borrower = new BorrowerViewModel();
                var checkout = book.Checkouts.LastOrDefault(b => b.Book.Id == id);
                var borrowerNameList = checkout.Borrower.Split(" ");
                borrower.FirstName = borrowerNameList[0];
                borrower.LastName = borrowerNameList[1];
                borrower.bookId = book.Id.Value;
                borrower.ReturnDate = checkout.EndTime.Value;
                return View(borrower);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "An Error occured while gettings the Details");
                return View("Error", new ErrorViewModel());
            }
        }


        // To Checkout the book with borrower information and Return Date
        // GET: BookController/Edit/5
        [ProducesResponseType<Book>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Checkout(int? id)
        {
            try
            {
                var borrower = new BorrowerViewModel();
                if (id != null) borrower.bookId = id.Value;
                return View(borrower);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "An Error occured while getting the Checkout");
                return View("Error", new ErrorViewModel());
            }
        }


        // POST: BookController/Edit/5 Checkout Book
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(int id, BorrowerViewModel borrower, IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(borrower);
                }

                var book = await _bookRepository.FindByIdAsync(id);
                {
                    var isReturned = book.IsReturned;
                    if (isReturned)
                    {
                        var checkout = new Checkout(id,
                            DateTime.UtcNow,
                            borrower.ReturnDate.ToUniversalTime(),
                            borrower.FirstName + " " + borrower.LastName);
                        book.AddCheckout(checkout);
                        _bookRepository.Update(book);
                        await _bookRepository.UnitOfWork.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "An Error occured while Checkout Book");
                return View("Error", new ErrorViewModel());
            }
        }

        // Just Click And the Book Will beReturned To the Library
        // GET: BookController/ReturnBook/5
        public async Task<ActionResult> ReturnBook(int id)
        {
            try
            {
                var book = await _bookRepository.FindByIdAsync(id);
                if (book == null)
                {
                    //todo
                }
                else
                {
                    book.ReturnBook();
                    _bookRepository.Update(book);
                    await _bookRepository.UnitOfWork.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "An Error occured while ReturnBook");
                return View("Error", new ErrorViewModel());
            }
        }

        /// Get Adding New Book
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                var authors = _authorRepository.GetAuthorsAsync();
                var mappedAuthors = _mapper.Map<List<AuthorViewModel>>(authors);
                ViewBag.Authors = new SelectList(mappedAuthors.Select(a =>
                    new { FullName = String.Format("{0} {1}", a.FirstName, a.LastName), Id = a.Id }
                ), "Id", "FullName");

                var categories = _categoryRepository.GetCategoriesAsync();
                var mappedCategories = _mapper.Map<List<CategoryViewModel>>(categories);
                ViewBag.Categories = new SelectList(mappedCategories, "Id", "Name");

                var bookViewModel = new CreateBookViewModel();
                return View(bookViewModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "An Error occured while getting Book add get method");
                return View("Error", new ErrorViewModel());
            }
        }

        /// Post Adding New Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBookViewModel bookViewModel, IFormFile image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fileName = bookViewModel.Name + bookViewModel.AuthorId + bookViewModel.CategoryId +
                                   Path.GetFileName(image.FileName);
                    // Get the path to save the image
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    // Save the image to the wwwroot/images folder
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    // Save the image file name to the model

                    var book = new Book(bookViewModel.Name, bookViewModel.CategoryId, bookViewModel.AuthorId, fileName);
                    await _bookRepository.Add(book);
                    await _bookRepository.UnitOfWork.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                var authors = _authorRepository.GetAuthorsAsync();
                var mappedAuthors = _mapper.Map<List<AuthorViewModel>>(authors);
                ViewBag.Authors = new SelectList(mappedAuthors.Select(a =>
                    new { FullName = String.Format("{0} {1}", a.FirstName, a.LastName), Id = a.Id }
                ), "Id", "FullName");

                var categories = _categoryRepository.GetCategoriesAsync();
                var mappedCategories = _mapper.Map<List<CategoryViewModel>>(categories);
                ViewBag.Categories = new SelectList(mappedCategories, "Id", "Name");
                return View(bookViewModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, "An Error occured while Adding New Book ");
                return View("Error", new ErrorViewModel());
            }
        }
    }
}