using System.ComponentModel.DataAnnotations;

namespace BookLibrary.WebApp.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReturned { get; set; }
        public CategoryViewModel Category { get; set; }
        [Required (ErrorMessage = "Lütfen bir kategori seçin.")]
        public int CategoryId { get;set; }
        public AuthorViewModel Author { get; set; }
        [Required (ErrorMessage = "Lütfen bir Yazar seçin.")]
        public int AuthorId { get; set; }
        
        public string ImageUrl { get; set; }

        public List<CheckoutViewModel> Checkouts { get; set; }
        
    }
}
