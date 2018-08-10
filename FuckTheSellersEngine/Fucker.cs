using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckTheSellersEngine.Settings;
using FuckTheSellersEngine.ModulesMgr;

namespace FuckTheSellersEngine
{
    class Fucker : IRobot
    {
        private readonly IIniSettings _settings;
        private readonly IModuleManager _moduleManager;
        public Fucker(IIniSettings settings, IModuleManager moduleMgr)
        {
            _settings = settings;
            _moduleManager = moduleMgr;
        }

        public bool Run()
        {
            _moduleManager.Init();
            if (_moduleManager.Run())
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(9999999);
                }
            }
            else
            {
                return false;
            }
        }
    }
}