using System;

namespace Ddd.Services.Interfaces.Repositories
{
    /// <summary>
    /// Um repositorio é a entidade responsável por efetuar as transações finais com o a 
    /// persistencia de dados.
    /// 
    /// <para>
    /// Um repositório não necessáriamente precisa persistir em um banco de dados.
    /// pode ser na Nuvem, em um sistema de arquivos, etc.
    /// </para> 
    /// 
    /// <para>
    /// Um repositório também não é um DAO (Data Access Object) no sentido classico da palavra,
    /// pois está mais intimamente ligado ao negócio. DAOs em geral, são abstraídos nas camadas de 
    /// acesso à banco de dados, ficando encapsulada num ORM de mercado (EF, Nhibernate) ou numa lib com acesso
    /// direto usando ADO.
    /// </para>
    /// <para>
    /// Extatamente por possuir esta caracteristica, o Repository é mais adequado ao modelo de arquitetura DDD
    /// </para>
    /// 
    /// <para>
    /// Embora esta interface ofereça um conjunto completo de operações, seu uso deve ser desencorajado quando 
    /// existir a possibilidade de se violar o ISP.
    /// </para>
    /// 
    /// <para>
    /// Para estes casos, recomenda-se o uso das interfaces <see cref="IWritableRepository{TEntity}"/>, <see cref="IReadOnlyRepository{TEntity,TKey}"/> e <see cref="IDeletableRepository{TEntity}"/> em separado.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description><a href="http://thinkinginobjects.com/2012/08/26/dont-use-dao-use-repository/">Don't use DAO, use Repository</a></description></item>
    /// <item><description><a href="http://www.javabuilding.com/academy/patterns/repository.html">Repository Pattern</a></description></item>
    /// <item><description><a href="http://manifesto.blog.br/2.0/Programacao/repository-pattern"> Repository Pattern 2</a></description></item>
    /// <item><description><a href="http://pt.stackoverflow.com/questions/12927/qual-a-diferen%C3%A7a-entre-dao-e-repository">Qual a diferença entre DAO e Repositorio</a></description></item>
    /// <item><description><a href="http://eduardopires.net.br/2015/01/solid-teoria-e-pratica/">Eduardo Pires - Solid - Teoria e Prática</a></description></item>
    /// <item><description><a href="https://robsoncastilho.com.br/2013/04/14/principios-solid-principio-da-segregacao-de-interface-isp/">Robson Castilho - ISP</a></description></item>
    /// <item><description><a href="http://netcoders.com.br/blog/aplicando-solid-com-c-isp-interface-segregation-principle/"></a>NetCoders - ISP</description></item>
    /// </list>
    /// </remarks>
    /// <typeparam name="TEntity">A Entidade básica a ser manipulada no repositório</typeparam>
    /// <typeparam name="TKey">O tipo de chave do repositório</typeparam>
    public interface IRepository<TEntity, in TKey> : IWritableRepository<TEntity>, IDeletableRepository<TEntity>, IReadOnlyRepository<TEntity, TKey>, IDisposable
      where TEntity : class
    {
        
    }
}