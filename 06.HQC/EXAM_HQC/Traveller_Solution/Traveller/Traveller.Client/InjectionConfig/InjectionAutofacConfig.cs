using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Abstractions;
using Traveller.Core;
using Traveller.Commands.Creating;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories;
using Traveller.Core.Contracts;

namespace Traveller.Client.InjectionConfig
{
    public class InjectionAutofacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.Load("Traveller");

            builder.RegisterAssemblyTypes(currentAssembly)
                   .AsImplementedInterfaces();

            builder.RegisterType<NewEngine>().As<IEngine>().SingleInstance();
            builder.RegisterType<Constants>().AsSelf().SingleInstance();
            builder.RegisterType<DataBase>().As<IDataBase>().SingleInstance();
            builder.RegisterType<ConsoleRenderer>().As<IRenderer>();
            builder.RegisterType<CommandsFactory>().As<ICommandsFactory>();

            builder.RegisterType<CreateBusCommand>().Named<ICommand>("createbus");
            builder.RegisterType<CreateAirplaneCommand>().Named<ICommand>("createairplane");
            builder.RegisterType<CreateJourneyCommand>().Named<ICommand>("createjourney");
            builder.RegisterType<CreateTicketCommand>().Named<ICommand>("createticket");
            builder.RegisterType<CreateTrainCommand>().Named<ICommand>("createtrain");
            builder.RegisterType<ListVehiclesCommand>().Named<ICommand>("listvehicles");
            builder.RegisterType<ListJourneysCommand>().Named<ICommand>("listjourneys");
            builder.RegisterType<ListTicketsCommand>().Named<ICommand>("listtickets");

            builder.RegisterType<JourneyFactory>().As<IJourneyFactory>().SingleInstance();
        }
    }
}
