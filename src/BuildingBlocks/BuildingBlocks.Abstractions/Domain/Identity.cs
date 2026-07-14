namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Classe base para objetos de identidade (Value Objects) com um tipo genérico.
/// </summary>
/// <typeparam name="TId">O tipo do valor da identidade.</typeparam>
public abstract record Identity<TId>
{
    protected Identity(TId value) => Value = value;
    public TId Value { get; protected set; }

    public static implicit operator TId(Identity<TId> identityId)
        => identityId.Value;

    public override string ToString()
    {
        return IdAsString();
    }

    public string IdAsString()
    {
        return $"{GetType().Name} [Id={Value}]";
    }
}

/// <summary>
/// Classe base para objetos de identidade (Value Objects) com o tipo <see cref="long"/>.
/// </summary>
public abstract record Identity : Identity<long>
{
    protected Identity(long value) : base(value)
    {
    }
}
