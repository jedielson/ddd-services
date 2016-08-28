namespace Ddd.Services.Interfaces.Services
{
    /// <summary>
    /// Expõe operações de deleção de entidades através dos services.
    /// <para>
    /// Esta divisão faz-se necessária para evitar a quebra do ISP, e evitar que entidades que
    /// não devem ser deletadas ofereçam este serviço, pois por este princípio, nenhum cliente deve
    /// ser forçado a depender de métodos que ele não use.
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
    /// <typeparam name="TEntity">O tipo base do Service</typeparam>
    public interface IDeletableService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Deleta uma entidade
        /// </summary>
        /// <param name="entity">A entidade a ser Deletada</param>
        /// <returns>Um <see cref="IServiceOperationResult"/></returns>
        IServiceOperationResult Delete(TEntity entity);
        
    }
}