using FluentValidation.Results;
using SweetGoods.Recipes.Domain.Core.Events;
using System;

namespace SweetGoods.Recipes.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}