namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Define um contrato para um consumidor de mensagens do barramento.
/// </summary>
public interface IBusConsumer
{
    /// <summary>
    /// Consome uma mensagem com um manipulador específico.
    /// </summary>
    /// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
    /// <param name="handler">O manipulador para executar a mensagem.</param>
    /// <param name="consumeBuilder">Configurações adicionais para o consumidor.</param>
    void Consume<TMessage>(
        IMessageHandler<TMessage> handler,
        Action<IConsumeConfigurationBuilder>? consumeBuilder = null)
        where TMessage : class, IMessage;

    /// <summary>
    /// Consome uma mensagem com um delegate específico.
    /// </summary>
    /// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
    /// <param name="subscribeMethod">O delegate para executar a mensagem.</param>
    /// <param name="consumeBuilder">Configurações adicionais para o consumidor.</param>
    void Consume<TMessage>(
        MessageHandler<TMessage> subscribeMethod,
        Action<IConsumeConfigurationBuilder>? consumeBuilder = null)
        where TMessage : class, IMessage;

    /// <summary>
    /// Consome uma mensagem descobrindo automaticamente o manipulador correspondente.
    /// </summary>
    /// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
    void Consume<TMessage>()
        where TMessage : class, IMessage;

    /// <summary>
    /// Consome uma mensagem de um tipo específico, descobrindo automaticamente o manipulador.
    /// </summary>
    /// <param name="messageType">O tipo da mensagem.</param>
    void Consume(Type messageType);

    /// <summary>
    /// Consome uma mensagem com um tipo de manipulador e mensagem explícitos.
    /// </summary>
    /// <typeparam name="THandler">O tipo do manipulador.</typeparam>
    /// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
    void Consume<THandler, TMessage>()
        where THandler : IMessageHandler<TMessage>
        where TMessage : class, IMessage;

    /// <summary>
    /// Consome todas as mensagens que possuem um manipulador registrado.
    /// </summary>
    void ConsumeAll();

    /// <summary>
    /// Consome todas as mensagens de um assembly específico.
    /// </summary>
    /// <typeparam name="TType">Um tipo para identificar o assembly.</typeparam>
    void ConsumeAllFromAssemblyOf<TType>();

    /// <summary>
    /// Consome todas as mensagens de múltiplos assemblies.
    /// </summary>
    /// <param name="assemblyMarkerTypes">Tipos para identificar os assemblies.</param>
    void ConsumeAllFromAssemblyOf(params Type[] assemblyMarkerTypes);

    /// <summary>
    /// Remove o consumidor para um tipo de mensagem específico.
    /// </summary>
    /// <param name="messageType">O tipo da mensagem.</param>
    void RemoveConsume(Type messageType);

    /// <summary>
    /// Remove todos os consumidores.
    /// </summary>
    void RemoveAllConsume();

    /// <summary>
    /// Remove todos os consumidores de um assembly específico.
    /// </summary>
    /// <typeparam name="TType">Um tipo para identificar o assembly.</typeparam>
    void RemoveAllConsumeFromAssemblyOf<TType>();

    /// <summary>
    /// Remove todos os consumidores de múltiplos assemblies.
    /// </summary>
    /// <param name="assemblyMarkerTypes">Tipos para identificar os assemblies.</param>
    void RemoveAllConsumeFromAssemblyOf(params Type[] assemblyMarkerTypes);

    /// <summary>
    /// Evento disparado quando uma mensagem é consumida.
    /// </summary>
    event Action<object, Type> MessageConsumed;
}
