using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckTheSellersEngine.ModulesMgr
{
    public class ModuleInformation
    {
        public string ModuleName { get; private set; }
        public string ModuleDb { get; private set; }
        public Task TaskObject { get; private set; }

        public ModuleInformation(string moduleName, string moduleDb, Task createdTask)
        {
            this.ModuleName = moduleName;
            this.ModuleDb = moduleDb;
            this.TaskObject = createdTask;
        }
    }
}