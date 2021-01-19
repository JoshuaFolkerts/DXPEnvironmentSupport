using System.Configuration;

namespace DXPEnvironmentSupport.Configuration
{
    public class HostsCollection : ConfigurationElementCollection
    {
        public new HostConfigElement this[string name]
        {
            get
            {
                if (IndexOf(name) < 0)
                    return null;

                return (HostConfigElement)BaseGet(name);
            }
        }

        public HostConfigElement this[int index] =>
            (HostConfigElement)BaseGet(index);

        public int IndexOf(string name)
        {
            name = name.ToLower();

            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].HostName.ToLower() == name)
                    return idx;
            }
            return -1;
        }

        public override ConfigurationElementCollectionType CollectionType =>
            ConfigurationElementCollectionType.BasicMap;

        protected override ConfigurationElement CreateNewElement() =>
            new HostConfigElement();

        protected override object GetElementKey(ConfigurationElement element) =>
            ((HostConfigElement)element).HostName;

        protected override string ElementName =>
            "host";

        public class HostConfigElement : ConfigurationElement
        {
            public HostConfigElement()
            {
            }

            public HostConfigElement(string hostName, string type, string scheme, string culture)
            {
                this.HostName = hostName;
                this.Type = type;
                this.Scheme = scheme;
                this.Culture = culture;
            }

            [ConfigurationProperty("hostName", IsRequired = true, IsKey = true, DefaultValue = "")]
            public string HostName
            {
                get { return (string)this["hostName"]; }
                set { this["hostName"] = value; }
            }

            [ConfigurationProperty("type", IsRequired = false)]
            public string Type
            {
                get { return (string)this["type"]; }
                set { this["type"] = value; }
            }

            [ConfigurationProperty("scheme", IsRequired = false, DefaultValue = "")]
            public string Scheme
            {
                get { return (string)this["scheme"]; }
                set { this["scheme"] = value; }
            }

            [ConfigurationProperty("culture", IsRequired = false, DefaultValue = "")]
            public string Culture
            {
                get { return (string)this["culture"]; }
                set { this["culture"] = value; }
            }
        }
    }
}