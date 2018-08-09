using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace FuckTheSellersEngine.Settings
{
    public class IniSettings : IIniSettings
    {
        public int RefreshHours { get; private set; }
        public int RefreshMinutes { get; private set; }
        public List<string> Modules { get; private set; }

        public IniSettings()
        {
            var fileIniData = new FileIniDataParser();
            fileIniData.Parser.Configuration.CommentString = "#";
            var parsedData = fileIniData.ReadFile("Config.ini");
            var configSection = parsedData.Sections.GetSectionData("Configuration");
            this.RefreshHours = int.Parse(configSection.Keys.GetKeyData("RefreshTimeHours").Value);
            this.RefreshMinutes = int.Parse(configSection.Keys.GetKeyData("RefreshTimeMins").Value);

            var modulesSection = parsedData.Sections.GetSectionData("Modules");
            var count = int.Parse(modulesSection.Keys.GetKeyData("ModuleCount").Value);

            this.Modules = new List<string>();

            for (int i = 0; i < count;i++ )
            {
                this.Modules.Add(modulesSection.Keys.GetKeyData("Module" + (i + 1)).Value);
            }
        }
    }
}