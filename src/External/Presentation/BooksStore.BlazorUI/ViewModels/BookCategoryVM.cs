using System.ComponentModel.DataAnnotations;

namespace BooksStore.BlazorUI.ViewModels;

public class BookCategoryVm
{
    public string Id { get; set; }

    [Required] public string Name { get; set; }
}
