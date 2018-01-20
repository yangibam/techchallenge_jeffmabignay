using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WH.RACEDAY.CORE.INTERFACES;

namespace WH.RACEDAY.WEB.Providers
{
    public sealed class DynamicQueryProcessor : IQueryProcessor
    {
        private readonly Container _container;

        public DynamicQueryProcessor(Container container)
        {
            _container = container;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            Type handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);
        }



    }

    public sealed class DynamicCommandProcessor : ICommandProcessor
    {
        private readonly Container _container;

        public DynamicCommandProcessor(Container container)
        {
            _container = container;
        }

        public void Execute(ICommand command)
        {
            Type handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _container.GetInstance(handlerType);
            handler.Handle((dynamic)command);
        }

    }
}