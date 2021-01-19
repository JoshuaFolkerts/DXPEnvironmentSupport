using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXPEnviromentSupport.Configuration
{
    public class EnvironmentConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("environmentType", IsRequired = true, IsKey = true)]
        public string EnvironmentType
        {
            get { return (string)this["environmentType"]; }
            set { this["environmentType"] = value; }
        }

        [ConfigurationProperty("sites", IsDefaultCollection = false)]
        public SitesCollection Sites =>
            (SitesCollection)base["sites"];
    }
}