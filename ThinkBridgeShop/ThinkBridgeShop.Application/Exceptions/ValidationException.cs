using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace ThinkBridgeShop.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public readonly Dictionary<string, string[]> ErrorsDictionary;

        public List<string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }

        public ValidationException(Dictionary<string, string[]> errorsDictionary)
        {
            this.ErrorsDictionary = errorsDictionary;
        }
    }
}

