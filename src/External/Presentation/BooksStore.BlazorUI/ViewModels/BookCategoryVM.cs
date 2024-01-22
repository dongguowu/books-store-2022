using System.ComponentModel.DataAnnotations;

namespace BooksStore.BlazorUI.ViewModels;

public class BookCategoryVM
{
    public Guid Id { get; set; }

    [Required] public string Name { get; set; }
}
