﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ddd.Services.Interfaces.Repositories;
using Ddd.Services.Interfaces.Services;
using Ddd.Validation.Interfaces;

namespace Ddd.Services.Common
{
    /// <summary>
    /// Esta classe implementa todas as funcionalidades básicas de um serviço de domínio.
    /// <para>
    /// Através dela, é possível efetuar operações básicas de escrita, leitura e deleção em um <see cref="IRepository{TEntity,TKey}"/>
    /// </para>
    /// <para>
    /// Por implementar todas as funcionalidades, seu uso é desencorajado em situações onde um destes serviços não será utilizado, 
    /// afim de evitar que haja violação do ISP (Solid).
    /// </para>
    /// </summary>
    /// <typeparam name="TEntity">O tipo da entidade a ser manipulada no serviço</typeparam>
    /// <typeparam name="TKey">O tipo doa identidade da entidade a ser manipulada no serviço</typeparam>
    public abstract class ServiceBase<TEntity, TKey> : IDisposable, IReadOnlyService<TEntity, TKey>, IWritableService<TEntity>, IDeletableService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Um <see cref="IRepository{TEntity,TKey}"/>
        /// </summary>
        protected IRepository<TEntity, TKey> Repository { get; set; }

        /// <summary>
        /// Inicia uma nova instância de <see cref="ServiceBase{TEntity,TKey}"/>
        /// </summary>
        /// <param name="repository">Um <see cref="IRepository{TEntity,TKey}"/></param>
        protected ServiceBase(IRepository<TEntity, TKey> repository)
        {
            Repository = repository;
            
        }
        
        /// <inheritdoc/>
        public TEntity Get(TKey id, bool @readonly = false)
        {
            return Repository.Get(id);
        }

        /// <inheritdoc/>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return Repository.Find(predicate, @readonly);
        }

        /// <summary>
        /// <inheritdoc/> 
        /// <para>
        /// Caso esta entidade implemente <see cref="ISelfValidation"/> irá validar a 
        /// a entidade com base em sua validação padrão.
        /// </para>
        /// <para>
        /// Do contrário, não fará validação nenhuma.
        /// </para>
        /// </summary>
        /// <param name="entity">A entidade</param>
        /// <returns>Um <see cref="IServiceOperationResult"/></returns>
        /// <autogeneratedoc />
        public virtual IServiceOperationResult Create(TEntity entity)
        {
            var result = new ServiceOperationResult();
            var obj = entity as ISelfValidation;

            if (obj != null && !obj.IsValid)
            {
                result.Add(obj.ValidationResult);
                return result;
            }

            Repository.Save(entity);
            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// <para>
        /// Caso esta entidade implemente <see cref="ISelfValidation"/> irá validar a 
        /// a entidade com base em sua validação padrão.
        /// </para>
        /// <para>Do contrário, não fará validação nenhuma.
        /// </para>
        /// </summary>
        /// <param name="entity">A entidade a ser atualizada</param>
        /// <returns>Um <see cref="IServiceOperationResult"/></returns>
        public virtual IServiceOperationResult Update(TEntity entity)
        {
            var result = new ServiceOperationResult();
            var obj = entity as ISelfValidation;

            if (obj != null && !obj.IsValid)
            {
                result.Add(obj.ValidationResult);
                return result;
            }

            Repository.Update(entity);
            return result;
        }

        /// <inheritdoc/>
        public virtual IServiceOperationResult Delete(TEntity entity)
        {
            var result = new ServiceOperationResult();
            try
            {
                Repository.Remove(entity);
            }
            catch (Exception ex)
            {
                result.Add(ex);
                throw;
            }
            return result;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Repository?.Dispose();
        }
    }
}