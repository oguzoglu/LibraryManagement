using System.ComponentModel.DataAnnotations;

namespace BookLibrary.WebApp.Models;

public class BorrowerViewModel
{
    public int bookId { get; set; }
    
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
    public string FirstName { get; set; }
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
    public string LastName { get; set; }
    
    public DateTime ReturnDate { get; set; } = DateTime.Now;
}