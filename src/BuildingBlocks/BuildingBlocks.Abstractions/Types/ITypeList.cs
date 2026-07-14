namespace BuildingBlocks.Abstractions.Types
{
    /// <summary>
    /// Um atalho para <see cref="ITypeList{TBaseType}"/> para usar <see cref="object"/> como tipo base.
    /// </summary>
    public interface ITypeList : ITypeList<object>
    {

    }

    /// <summary>
    /// Estende <see cref="IList{Type}"/> para adicionar restrição a um tipo base específico.
    /// </summary>
    /// <typeparam name="TBaseType">Tipo base dos <see cref="Type"/>s nesta lista.</typeparam>
    public interface ITypeList<in TBaseType> : IList<Type>
    {
        /// <summary>
        /// Adiciona um tipo à lista.
        /// </summary>
        /// <typeparam name="T">O tipo a ser adicionado.</typeparam>
        void Add<T>() where T : TBaseType;

        /// <summary>
        /// Tenta adicionar um tipo à lista se ele ainda não estiver presente.
        /// </summary>
        /// <typeparam name="T">O tipo a ser adicionado.</typeparam>
        /// <returns><c>true</c> se o tipo foi adicionado com sucesso; caso contrário, <c>false</c>.</returns>
        bool TryAdd<T>() where T : TBaseType;

        /// <summary>
        /// Verifica se um tipo existe na lista.
        /// </summary>
        /// <typeparam name="T">O tipo a ser verificado.</typeparam>
        /// <returns><c>true</c> se o tipo estiver na lista; caso contrário, <c>false</c>.</returns>
        bool Contains<T>() where T : TBaseType;

        /// <summary>
        /// Remove um tipo da lista.
        /// </summary>
        /// <typeparam name="T">O tipo a ser removido.</typeparam>
        void Remove<T>() where T : TBaseType;
    }
}
