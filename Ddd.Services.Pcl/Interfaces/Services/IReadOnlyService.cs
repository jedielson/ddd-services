using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ddd.Services.Interfaces.Services
{
    /// <summary>
    /// Efetua operações padrão de leitura nos repositórios.
    /// </summary>
    /// <typeparam name="TEntity">O tipo de dado a ser retornado</typeparam>
    /// <typeparam name="TKey">O tipo de chave utilizada pelo serviço</typeparam>
    public interface IReadOnlyService<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// Retorna um objeto baseado em seu Id
        /// </summary>
        /// <param name="id">O identificador do objeto a ser pesquisado</param>
        /// <param name="readonly">Define se os dados devem ser somente leitura</param>
        /// <returns>Um objeto</returns>
        TEntity Get(TKey id, bool @readonly = false);

        /// <summary>
        /// Uma consulta filtrada realizada pelo service.
        /// </summary>
        /// <param name="predicate">Uma expression tree que deve ser utilizada como filtro</param>
        /// <param name="readonly">Define se os dados devem ser somente leitura</param>
        /// <returns>Um <see cref="IEnumerable{T}"/></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}