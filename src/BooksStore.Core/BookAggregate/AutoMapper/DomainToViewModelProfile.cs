using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BooksStore.Core.BookAggregate.ViewModel;

namespace BooksStore.Core.BookAggregate.AutoMapper;
public class DomainToViewModelProfile : Profile
{
    public DomainToViewModelProfile()
    {
        CreateMap<Book, BookViewModel>();
    }
}
