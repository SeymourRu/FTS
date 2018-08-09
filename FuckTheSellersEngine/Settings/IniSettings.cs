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

        public string ModuleSubdir { get; private set; }

        public List<KeyValuePair<string, string>> Modules { get; private set; }

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
            this.ModuleSubdir = modulesSection.Keys.GetKeyData("ModuleSubdir").Value;

            this.Modules = new List<KeyValuePair<string, string>>();

            for (int i = 0; i < count; i++)
            {
                var moduleName = modulesSection.Keys.GetKeyData("ModuleName" + (i + 1)).Value;
                var dbName = modulesSection.Keys.GetKeyData("ModuleDBName" + (i + 1)).Value;
                this.Modules.Add(new KeyValuePair<string, string>(moduleName, dbName));
            }
        }
    }
}