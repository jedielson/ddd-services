namespace Ddd.Services.Interfaces.Repositories
{
    /// <summary>
    /// Expõe operações de deleção de entidades através dos repositórios.
    /// <para>
    /// Esta divisão faz-se necessária para evitar a quebra do ISP, e evitar que entidades que
    /// não devem ser deletadas ofereçam este serviço, pois por este princípio, nenhum cliente deve
    /// ser forçado a depender de métodos que ele não use.
    /// </para>
    /// <para>
    /// Esta interface é usada em conjunto com as interfaces <see cref="IWritableRepository{TEntity}"/> e <see cref="IReadOnlyRepository{TEntity,TKey}"/> 
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
    public interface IDeletableRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Remove uma entidade do repositório
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
    }
}