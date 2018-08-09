using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using FuckTheSellersEngine.Settings;
using FuckTheSellersEngine.ModulesMgr;

namespace FuckTheSellersEngine
{
    class Program
    {
        public static IContainer _container;

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IniSettings>().As<IIniSettings>();
            builder.RegisterType<ModuleManager>().As<IModuleManager>();
            builder.RegisterType<Fucker>().As<IRobot>();
            return builder.Build();
        }

        static void Main(string[] args)
        {
            _container = BuildContainer();
            var robot = _container.Resolve<IRobot>();
            robot.Run();
            Console.ReadLine();
        }
    }
}