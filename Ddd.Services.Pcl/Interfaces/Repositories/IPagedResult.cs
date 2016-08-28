using System.Collections.Generic;

namespace Ddd.Services.Interfaces.Repositories
{
    /// <summary>
    /// Define o comportamento de um resultado paginado para a aplicação
    /// </summary>
    /// <typeparam name="TEntity">O tipo do retorno do resultado paginado</typeparam>
    public interface IPagedResult<TEntity> where TEntity : class
    {
        /// <summary>
        /// A coleção de itens retornados
        /// </summary>
        IEnumerable<TEntity> Items { get; set; }

        /// <summary>
        /// A quantidade total de itens
        /// </summary>
        int TotalItems { get; set; }

        /// <summary>
        /// A quantidade de itens retornados por página
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// A quantidade de páginas existentes
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// O índice da página atual. Varia entre 1 e n
        /// </summary>
        int Page { get; set; }
    }
}