﻿namespace Ddd.Services.Interfaces.Services
{
    /// <summary>
    /// Um serviço de escrita é um domain service capaz de gravar e atualizar dados nos repositórios
    /// </summary>
    /// <typeparam name="TEntity">O tipo base do Service</typeparam>
    public interface IWritableService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Salva uma entidade
        /// </summary>
        /// <param name="entity">A entidade</param>
        /// <returns>Um <see cref="IServiceOperationResult"/></returns>
        /// <autogeneratedoc />
        IServiceOperationResult Create(TEntity entity);

        /// <summary>
        /// Atualiza uma entidade
        /// </summary>
        /// <param name="entity">A entidade a ser atualizada</param>
        /// <returns>Um <see cref="IServiceOperationResult"/></returns>
        IServiceOperationResult Update(TEntity entity);
    }
}