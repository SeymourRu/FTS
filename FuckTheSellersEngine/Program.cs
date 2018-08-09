using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using FuckTheSellersEngine.Settings;

namespace FuckTheSellersEngine
{
    class Program
    {
        public static IContainer _container;

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IniSettings>().As<IIniSettings>();
            return builder.Build();
        }

        static void Main(string[] args)
        {
            _container = BuildContainer();
            var inis = _container.Resolve<IIniSettings>();

            Console.ReadLine();
        }
    }
}