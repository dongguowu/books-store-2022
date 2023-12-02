using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStore.Application.Abstractions.Messaging;

namespace BooksStore.Application.Books.Queries;
public sealed record GetBookByIdQuery(Guid BookId): IQuery<BookResponse>; 
