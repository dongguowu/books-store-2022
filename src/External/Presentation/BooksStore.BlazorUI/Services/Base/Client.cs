﻿namespace BooksStore.BlazorUI.Services.Base;

public partial class Client : IClient
{
    public HttpClient HttpClient { get; }
}
