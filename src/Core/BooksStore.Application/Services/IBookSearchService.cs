using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using BooksStore.Domain.Entities;

namespace BooksStore.Application.Services;

public interface IBookSearchService
{
    Task<Result<List<Book>>> GetAllBooks();
}
