using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckTheSellersEngine.Settings;
using System.Reflection;
using FTSModuleSDK;

namespace FuckTheSellersEngine.ModulesMgr
{
    public class ModuleManager : IModuleManager
    {
        private IIniSettings _settings;

        private bool startState = false;
        private List<ModuleInformation> _runningModules = new List<ModuleInformation>();

        public ModuleManager(IIniSettings settings)
        {
            _settings = settings;
        }

        public void Init()
        {
            var moduleDir = _settings.ModuleSubdir + "\\";
            var modulesPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";

            foreach (var values in _settings.Modules)
            {
                var fullModulePath = modulesPath + moduleDir + values.Key;
                if (File.Exists(fullModulePath))
                {
                    var moduleAssembly = System.Reflection.Assembly.LoadFrom(fullModulePath);
                    var moduleTypes = moduleAssembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IModule)));

                    var modules = moduleTypes.Select(type =>
                    {
                        return (IModule)Activator.CreateInstance(type);
                    });

                    var task = new Task(() =>
                    {
                        var modulesCopy = modules;
                        var subTasks = new List<Task>();

                        foreach (var module in modulesCopy)
                        {
                            subTasks.Add(new Task(() =>
                            {
                                module.Configure();
                                module.Run();
                            }));
                        }

                        subTasks.ForEach(x => x.Start());

                        Task.WaitAll(subTasks.ToArray());
                    });

                    _runningModules.Add(new ModuleInformation(values.Key, values.Value, task));
                }
                else
                {
                    Console.WriteLine("Incorrect path to module :" + fullModulePath);
                }
                
            }
        }

        public bool Run()
        {
            if (!startState)
            {
                if (_runningModules.Count > 0)
                {
                    foreach (var module in _runningModules)
                    {
                        module.TaskObject.Start();
                    }
                    startState = true;
                }
                else
                {
                    Console.WriteLine("Missing modules, nothing to start");
                }
            }

            return startState;
        }
    }
}