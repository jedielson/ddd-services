namespace Ddd.Services.Interfaces.Services
{
    /// <summary>
    /// Fornece uma implementação full das interfaces de serviços, permitindo a criação de um serviço com Leitura, Escrita e Deleção.
    /// <para>
    /// Embora este serviço seja mais completo, seu uso só é indicado para operações que precisem de todas estas funcionalidades. 
    /// </para>
    /// <para>
    /// Do contrário, é recomendado o uso das interfaces específicas <see cref="IReadOnlyService{TEntity,TKey}"/>, <see cref="IWritableService{TEntity}"/> e <see cref="IDeletableService{TEntity}"/>
    /// </para>
    /// </summary>
    /// <typeparam name="TEntity">O tipo do objeto a ser manipulado no serviço</typeparam>
    /// <typeparam name="TKey">O tipo da chave primária do serviço</typeparam>
    public interface IService<TEntity, TKey> : IWritableService<TEntity>, IReadOnlyService<TEntity, TKey>, IDeletableService<TEntity> where TEntity : class
    {
         
    }
}