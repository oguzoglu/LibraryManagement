using System.ComponentModel.DataAnnotations;

namespace BookLibrary.WebApp.Models;

public class CreateBookViewModel
{
    public int Id { get; set; }
    [Required (ErrorMessage = "Lütfen Kitap adI giriniz.")]
    public string Name { get; set; }
    public bool IsReturned { get; set; }
    [Required (ErrorMessage = "Lütfen bir kategori seçin.")]
    public int CategoryId { get;set; }
    [Required (ErrorMessage = "Lütfen bir Yazar seçin.")]
    public int AuthorId { get; set; }
}