using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryInterface", Version = "1.0")]

namespace DallyTally.Application.Common.Interfaces
{
    public interface IQuery
    {

    }
}