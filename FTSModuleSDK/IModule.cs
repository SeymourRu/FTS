using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTSModuleSDK
{
    public interface IModule
    {
        void Configure();
        void Run();
    }
}