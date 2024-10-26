using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Automation.Library.Helpers
{
    public class SettingsReader
    {
        private static readonly string SettingsFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");

        /// <summary>
        /// Gets settings from the appsettings.json file.
        /// </summary>
        /// <typeparam name="T">The type that the settings will be converted to.</typeparam>
        /// <param name="section">The name of the section as it appears in the appsettings file.</param>
        /// <returns></returns>
        public static T GetSettings<T>(string section)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile(SettingsFilePath)
              .Build();

            return configuration.GetRequiredSection(section).Get<T>();
        }

        public static IEnumerable<IConfigurationSection> GetSettingsSection(string section)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile(SettingsFilePath)
              .Build();

            return configuration.GetRequiredSection(section).GetChildren();
        }
    }
}