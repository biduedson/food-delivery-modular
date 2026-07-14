using AutoMapper;
using BuildingBlocks.Abstractions.CQRS.Command;
using BuildingBlocks.Abstractions.CQRS.Query;
using BuildingBlocks.Abstractions.Messaging;
using BuildingBlocks.Abstractions.Web.Module;
using MediatR;

namespace BuildingBlocks.Abstractions.Web;

/// <summary>
/// Define uma interface para processamento de gateway, permitindo a execução de comandos, queries e ações assíncronas
/// dentro de um escopo de serviço, específico para um módulo.
/// </summary>
/// <typeparam name="TModule">O tipo do módulo, que deve ser uma classe e implementar <see cref="IModuleDefinition"/>.</typeparam>
public interface IGatewayProcessor<TModule>
    where TModule : class, IModuleDefinition
{
    /// <summary>
    /// Executa uma ação assíncrona dentro de um escopo de serviço.
    /// </summary>
    /// <param name="action">A função a ser executada, recebendo um <see cref="IServiceProvider"/>.</param>
    /// <returns>Uma <see cref="ValueTask"/> que representa a operação assíncrona.</returns>
    ValueTask ExecuteScopeAsync(Func<IServiceProvider, ValueTask> action);

    /// <summary>
    /// Executa uma ação assíncrona dentro de um escopo de serviço e retorna um resultado.
    /// </summary>
    /// <typeparam name="T">O tipo do resultado da função.</typeparam>
    /// <param name="action">A função a ser executada, recebendo um <see cref="IServiceProvider"/> e retornando um <see cref="ValueTask{T}"/>.</param>
    /// <returns>Uma <see cref="ValueTask{T}"/> que representa a operação assíncrona e contém o resultado.</returns>
    ValueTask<T> ExecuteScopeAsync<T>(Func<IServiceProvider, ValueTask<T>> action);

    /// <summary>
    /// Envia um comando assíncrono e espera por uma resposta.
    /// </summary>
    /// <typeparam name="TResponse">O tipo da resposta esperada, que não deve ser nulo.</typeparam>
    /// <param name="request">O comando a ser enviado.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task{TResponse}"/> que representa a operação assíncrona e contém a resposta.</returns>
    Task<TResponse> SendCommandAsync<TResponse>(
        ICommand<TResponse> request,
        CancellationToken cancellationToken = default)
        where TResponse : notnull;

    /// <summary>
    /// Envia um comando assíncrono sem esperar por uma resposta específica.
    /// </summary>
    /// <typeparam name="T">O tipo do comando, que deve ser uma classe e implementar <see cref="ICommand"/>.</typeparam>
    /// <param name="request">O comando a ser enviado.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task SendCommandAsync<T>(T request, CancellationToken cancellationToken = default)
        where T : class, ICommand;

    /// <summary>
    /// Executa um comando assíncrono.
    /// </summary>
    /// <typeparam name="TCommand">O tipo do comando, que deve implementar <see cref="ICommand"/>.</typeparam>
    /// <param name="command">O comando a ser executado.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task ExecuteCommand<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand;

    /// <summary>
    /// Executa um comando assíncrono e retorna um resultado.
    /// </summary>
    /// <typeparam name="TCommand">O tipo do comando, que deve implementar <see cref="ICommand{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">O tipo do resultado do comando, que não deve ser nulo.</typeparam>
    /// <param name="command">O comando a ser executado.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task{TResult}"/> que representa a operação assíncrona e contém o resultado.</returns>
    Task<TResult> ExecuteCommand<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResult>
        where TResult : notnull;

    /// <summary>
    /// Executa uma ação assíncrona com um processador de comandos e um mapeador.
    /// </summary>
    /// <param name="action">A função a ser executada, recebendo um <see cref="ICommandProcessor"/> e um <see cref="IMapper"/>.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task ExecuteCommand(Func<ICommandProcessor, IMapper, Task> action);

    /// <summary>
    /// Executa uma ação assíncrona com um processador de comandos.
    /// </summary>
    /// <param name="action">A função a ser executada, recebendo um <see cref="ICommandProcessor"/>.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task ExecuteCommand(Func<ICommandProcessor, Task> action);

    /// <summary>
    /// Executa uma ação assíncrona com um processador de comandos e retorna um resultado.
    /// </summary>
    /// <typeparam name="T">O tipo do resultado da função.</typeparam>
    /// <param name="action">A função a ser executada, recebendo um <see cref="ICommandProcessor"/> e retornando um <see cref="Task{T}"/>.</param>
    /// <returns>Uma <see cref="Task{T}"/> que representa a operação assíncrona e contém o resultado.</returns>
    Task<T> ExecuteCommand<T>(Func<ICommandProcessor, Task<T>> action);

    /// <summary>
    /// Executa uma ação assíncrona com um processador de comandos e um mapeador, retornando um resultado.
    /// </summary>
    /// <typeparam name="T">O tipo do resultado da função.</typeparam>
    /// <param name="action">A função a ser executada, recebendo um <see cref="ICommandProcessor"/> e um <see cref="IMapper"/>, e retornando um <see cref="Task{T}"/>.</param>
    /// <returns>Uma <see cref="Task{T}"/> que representa a operação assíncrona e contém o resultado.</returns>
    Task<T> ExecuteCommand<T>(Func<ICommandProcessor, IMapper, Task<T>> action);

    /// <summary>
    /// Publica uma mensagem usando o barramento de mensagens.
    /// </summary>
    /// <param name="action">A função a ser executada, recebendo um <see cref="IBus"/>.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task Publish(Func<IBus, Task> action);

    /// <summary>
    /// Envia uma query assíncrona e espera por uma resposta.
    /// </summary>
    /// <typeparam name="TResponse">O tipo da resposta esperada, que deve ser uma classe.</typeparam>
    /// <param name="query">A query a ser enviada.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task{TResponse}"/> que representa a operação assíncrona e contém a resposta.</returns>
    Task<TResponse> SendQueryAsync<TResponse>(
        IQuery<TResponse> query,
        CancellationToken cancellationToken = default)
        where TResponse : class;

    /// <summary>
    /// Executa uma query assíncrona e retorna um resultado.
    /// </summary>
    /// <typeparam name="TQuery">O tipo da query, que deve implementar <see cref="IQuery{TResult}"/>.</typeparam>
    /// <typeparam name="TResult">O tipo do resultado da query, que não deve ser nulo.</typeparam>
    /// <param name="query">A query a ser executada.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task{TResult}"/> que representa a operação assíncrona e contém o resultado.</returns>
    Task<TResult> ExecuteQuery<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : IQuery<TResult>
        where TResult : notnull;

    /// <summary>
    /// Executa uma ação assíncrona com um processador de queries e retorna um resultado.
    /// </summary>
    /// <typeparam name="T">O tipo do resultado da função.</typeparam>
    /// <param name="action">A função a ser executada, recebendo um <see cref="IQueryProcessor"/> e retornando um <see cref="Task{T}"/>.</param>
    /// <returns>Uma <see cref="Task{T}"/> que representa a operação assíncrona e contém o resultado.</returns>
    Task<T> ExecuteQuery<T>(Func<IQueryProcessor, Task<T>> action);

    /// <summary>
    /// Executa uma ação assíncrona com um processador de queries e um mapeador, retornando um resultado.
    /// </summary>
    /// <typeparam name="T">O tipo do resultado da função.</typeparam>
    /// <param name="action">A função a ser executada, recebendo um <see cref="IQueryProcessor"/> e um <see cref="IMapper"/>, e retornando um <see cref="Task{T}"/>.</param>
    /// <returns>Uma <see cref="Task{T}"/> que representa a operação assíncrona e contém o resultado.</returns>
    Task<T> ExecuteQuery<T>(
        Func<IQueryProcessor, IMapper, Task<T>> action);
}
