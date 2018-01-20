using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.RACEDAY.CORE.INTERFACES
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }

    public interface ICommand
    {

    }

    public interface ICommandProcessor
    {
        void Execute(ICommand command);
    }
}
