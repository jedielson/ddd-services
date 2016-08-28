using System;
using System.Collections.Generic;
using System.Linq;
using Ddd.Services.Interfaces.Services;
using Ddd.Validation.Interfaces;

namespace Ddd.Services.Common
{
    /// <summary>
    /// Uma implementação para <see cref="IServiceOperationResult"/>
    /// </summary>
    public class ServiceOperationResult : IServiceOperationResult
    {
        /// <summary>
        /// Inicia uma nova instância de <see cref="ServiceOperationResult"/>
        /// </summary>
        public ServiceOperationResult()
        {
            Errors = new List<string>();   
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IList<string> Errors { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Success => !Errors.Any();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="errorMessage"></param>
        public void Add(string errorMessage)
        {
            if (errorMessage == null || errorMessage.Trim().Length == 0)
            {
                return;
            }

            Errors.Add(errorMessage);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="validationResult"></param>
        public void Add(IValidationResult validationResult)
        {
            if (validationResult == null)
            {
                return;
            }

            foreach (var validationError in validationResult.Errors)
            {
                Add(validationError);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="validationError"></param>
        public void Add(IValidationError validationError)
        {
            if (string.IsNullOrEmpty(validationError?.Message) || 
                string.IsNullOrWhiteSpace(validationError.Message))
            {
                return;
            }

            Errors.Add(validationError.Message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="exception"></param>
        public void Add(Exception exception)
        {
            if (exception == null)
            {
                return;
            }
            Add($"{nameof(exception)} - {exception.Message}{Environment.NewLine} - {exception.StackTrace}");
        }
    }
}