namespace Ddd.Services.Interfaces.Repositories
{
    /// <summary>
    /// Expõe operações de escrita de entidades através dos repositórios.
    /// <para>
    /// Esta interface é usada em conjunto com as interfaces <see cref="IDeletableRepository{TEntity}"/> e <see cref="IReadOnlyRepository{TEntity,TKey}"/> 
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
    public interface IWritableRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Persiste uma entidade no repositório
        /// </summary>
        /// <param name="entity">Uma entidade do sistema</param>
        void Save(TEntity entity);

        /// <summary>
        /// Atualiza uma entidade no repositório
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
    }
}