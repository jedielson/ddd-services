using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ddd.Services.Interfaces.Repositories
{
    /// <summary>
    /// Expõe operações de leitura de entidades através dos repositórios.
    /// <para>
    /// Esta divisão faz-se necessária para evitar a quebra do ISP, e evitar que entidades que
    /// não devem ser deletadas ofereçam este serviço, pois por este princípio, nenhum cliente deve
    /// ser forçado a depender de métodos que ele não use.
    /// </para>
    /// <para>
    /// Esta interface é usada em conjunto com as interfaces <see cref="IDeletableRepository{TEntity}"/> e <see cref="IWritableRepository{TEntity}"/> 
    /// para formar um repositório completo com operações de leitura e escrita.
    /// </para>
    /// <para>
    /// Este repositório pode ser obtido implementando-se a interface <see cref="IRepository{TEntity,TKey}"/>. No entanto, é preferível utilizar interfaces separadas, 
    /// afim de se manter o ISP
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Para maiores informações, ver: 
    /// </para>
    /// <list type="bullet">
    /// <item><description><a href="http://eduardopires.net.br/2015/01/solid-teoria-e-pratica/">Eduardo Pires - Solid - Teoria e Prática</a></description></item>
    /// <item><description><a href="https://robsoncastilho.com.br/2013/04/14/principios-solid-principio-da-segregacao-de-interface-isp/">Robson Castilho - ISP</a></description></item>
    /// <item><description><a href="http://netcoders.com.br/blog/aplicando-solid-com-c-isp-interface-segregation-principle/"></a>NetCoders - ISP</description></item>
    /// </list>
    /// </remarks>
    /// <typeparam name="TEntity">O tipo da entidade que é manipulada no repositório</typeparam>
    /// <typeparam name="TKey">O tipo do atributo que é a identidade do objeto</typeparam>
    public interface IReadOnlyRepository<TEntity, in TKey> where TEntity : class
    {
        /// <summary>
        /// Recupera um objeto com base em sua Key
        /// </summary>
        /// <param name="id">Uma Key definida na entidade</param>
        /// <returns>Um objeto do tipo TEntity</returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Retorna um <see cref="IEnumerable{T}"/> que abstrai todos os objetos no repositório
        /// Este método deve ser usado com atenção redobrada, para evitar sobrecarga de dados em memória.
        /// </summary>
        /// <param name="readonly">Caso seja definido como somente leitura, os dados não são colocados abaixo da camada de proxy de um ORM</param>
        /// <returns>Um <see cref="IEnumerable{T}"/></returns>
        IEnumerable<TEntity> All(bool @readonly = false);

        /// <summary>
        /// Retorna um <see cref="IEnumerable{T}"/> que abstrai uma coleção filtrada de objetos no repositório.
        /// Este método deve ser usado com atenção redobrada, para evitar sobrecarga de dados em memória.
        /// </summary>
        /// <param name="predicate">O filtro dos dados</param>
        /// <param name="readonly">Caso seja definido como somente leitura, os dados não são colocados abaixo da camada de proxy de um ORM</param>
        /// <returns>Um <see cref="IEnumerable{T}"/></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
    }
}