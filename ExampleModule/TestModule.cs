using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTSModuleSDK;

namespace ExampleModule
{
    public class TestModule : IModule
    {
        public void Configure()
        {
            Console.WriteLine("TestModule :: configuring");
        }

        public void Run()
        {
            Console.WriteLine("Module `TestModule` working");
            System.Threading.Thread.Sleep(99999999);
        }
    }
}
