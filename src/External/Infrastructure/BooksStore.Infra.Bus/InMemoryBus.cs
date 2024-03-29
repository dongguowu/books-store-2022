﻿using BooksStore.Domain.Bus;
using BooksStore.Domain.Commands;
using MediatR;

namespace BooksStore.Infra.Bus;

public sealed class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;

    public InMemoryBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task SendCommand<T>(T command) where T : Command
    {
        return _mediator.Send(command);
    }
}
