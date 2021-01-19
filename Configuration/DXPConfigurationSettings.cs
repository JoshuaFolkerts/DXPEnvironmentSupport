using System;
using System.Configuration;

namespace DXPEnviromentSupport.Configuration
{
    public class DXPConfiguration
    {
        public static DXPConfigurationSection DXPSectionConfiguration = ConfigurationManager.GetSection(DXPConfigurationSection.sectionName) as DXPConfigurationSection;

        public static EnviromentCollection GetEnvironments() =>
            DXPSectionConfiguration.Environments;

        public static bool IsEnabled() =>
            DXPSectionConfiguration.Enabled;

        public static EnvironmentConfigElement GetEnvironment(string environmentType)
        {
            var item = GetEnvironments()[environmentType];
            return item;
        }

        public static EnvironmentConfigElement GetEnvironment(DXPEnviromentType environmentType)
        {
            var item = GetEnvironments()[environmentType.ToString()];
            return item;
        }
    }

    public class DXPConfigurationSection : ConfigurationSection
    {
        public const string sectionName = "dxpConfigurationSection";

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public EnviromentCollection Environments
        {
            get
            {
                EnviromentCollection hostCollection = (EnviromentCollection)base[""];
                return hostCollection;
            }
        }

        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }
    }
}