using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckTheSellersEngine.Settings;

namespace FuckTheSellersEngine
{
    class Fucker : IRobot
    {
        private readonly IIniSettings _settings;
        public Fucker(IIniSettings settings)
        {
            _settings = settings;
        }

        public bool Run()
        {
            Console.WriteLine("If you are seller - I`ll fuck you");
            return true;
        }
    }
}