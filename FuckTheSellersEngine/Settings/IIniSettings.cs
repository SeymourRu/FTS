using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckTheSellersEngine.Settings
{
    public interface IIniSettings
    {
        int RefreshHours { get; }
        int RefreshMinutes { get; }
        string ModuleSubdir { get; }
        List<KeyValuePair<string, string>> Modules { get; }
    }
}