using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStore.Domain.Entities;

namespace BooksStore.Domain.Abstractions;
public interface IbookRepository
{
    void Insert(Book book);
}
