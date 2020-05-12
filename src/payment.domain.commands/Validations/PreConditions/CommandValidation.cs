using AG.Payment.Domain.Commands.Validations.Interface;
using AG.Payment.Domain.Core.Commands;
using Ether.Outcomes;

namespace Payment.Domain.Commands.Validations.PreConditions
{
    public abstract class CommandValidation<T> : ICommandValidation<T> where T : Command
    {
        public abstract IOutcome ValidateCommand(T command);
    }
}
