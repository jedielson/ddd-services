using System;
using System.Collections.Generic;
using Ddd.Validation.Interfaces;

namespace Ddd.Services.Interfaces.Services
{
    /// <summary>
    /// Expõe um padrão de comunicação de resultados de operações realizadas num domain service.
    /// <para>
    /// Este modelo de comunição é flexível o suficiente para adicionar diversos tipos de erros e 
    /// assim, permitir uma comunicação fluída e sem exceções indesejáveis ao longo da execução de um 
    /// fluxo de negócio
    /// </para>
    /// </summary>
    public interface IServiceOperationResult
    {
        /// <summary>
        /// Uma lista de erros reportados durante a execução de um processo
        /// </summary>
        IList<string> Errors { get; }

        /// <summary>
        /// Verifica se a operação foi bem sucedida.
        /// <para>
        /// Em caso negativo, os eventuais erros podem ser adicionados através do método
        /// <see cref="Add(string)"/>, ou uma de suas variantes, ficando disponíveis em <see cref="Errors"/>
        /// </para>
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Adiciona uma mensagem de erro em <see cref="Errors"/>.
        /// </summary>
        /// <param name="errorMessage">A mensagem de erro à ser adicionada</param>
        void Add(string errorMessage);

        /// <summary>
        /// Captura os erros existentes em um <see cref="IValidationResult"/> e os armazena em 
        /// <see cref="Errors"/>
        /// </summary>
        /// <param name="validationResult">Um <see cref="IValidationResult"/></param>
        void Add(IValidationResult validationResult);

        /// <summary>
        /// Transforma o erro disponível em um <see cref="IValidationError"/> 
        /// num erro disponível em <see cref="Errors"/>
        /// </summary>
        /// <param name="validationError">Um <see cref="IValidationError"/></param>
        void Add(IValidationError validationError);

        /// <summary>
        /// Recupera o erro de uma exception e o armazena em <see cref="Errors"/>
        /// </summary>
        /// <param name="exception">Uma <see cref="Exception"/></param>
        void Add(Exception exception);
    }
}