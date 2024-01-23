using System.ComponentModel.DataAnnotations;

namespace BooksStore.BlazorUI.ViewModels;

public class BookCategoryDetailVm
{
    public string Id { get; set; }

    [Required] 
    public string Name { get; set; }

    public string DateCreated { get; set; }
    public string DateModified { get; set; }

}
