﻿namespace BooksStore.Application.Interfaces.Shared;

public interface IAppLogger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
}
