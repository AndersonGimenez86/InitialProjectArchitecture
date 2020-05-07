namespace AG.Payment.Domain.Commands.Validations.Interface
{
    using AG.Payment.Domain.Core.Commands;
    using Ether.Outcomes;

    public interface ICommandValidation<T> where T : Command
    {
        IOutcome ValidateCommand(T command);
    }
}
