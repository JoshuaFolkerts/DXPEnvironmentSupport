using System.Configuration;

namespace DXPEnvironmentSupport.Configuration
{
    public class SitesCollection : ConfigurationElementCollection
    {
        public new SiteConfigElement this[string name]
        {
            get
            {
                if (IndexOf(name) < 0) return null;

                return (SiteConfigElement)BaseGet(name);
            }
        }

        public SiteConfigElement this[int index] =>
            (SiteConfigElement)BaseGet(index);

        public int IndexOf(string id)
        {
            id = id.ToLower();

            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Id.ToLower() == id)
                    return idx;
            }
            return -1;
        }

        public override ConfigurationElementCollectionType CollectionType =>
            ConfigurationElementCollectionType.BasicMap;

        protected override ConfigurationElement CreateNewElement() =>
            new SiteConfigElement();

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SiteConfigElement)element).Id;
        }

        protected override string ElementName =>
            "site";

        public class SiteConfigElement : ConfigurationElement
        {
            public SiteConfigElement()
            {
            }

            public SiteConfigElement(string id, string name, string url)
            {
                this.Id = id;
                this.Name = Name;
                this.Url = url;
            }

            [ConfigurationProperty("id", IsRequired = true, IsKey = true, DefaultValue = "")]
            public string Id
            {
                get { return (string)this["id"]; }
                set { this["id"] = value; }
            }

            [ConfigurationProperty("name", IsRequired = false)]
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }

            [ConfigurationProperty("url", IsRequired = true)]
            public string Url
            {
                get { return (string)this["url"]; }
                set { this["url"] = value; }
            }

            [ConfigurationProperty("updateAllHosts", IsRequired = false, DefaultValue = false)]
            public bool UpdateAllHosts
            {
                get { return (bool)this["updateAllHosts"]; }
                set { this["updateAllHosts"] = value; }
            }

            [ConfigurationProperty("hosts", IsDefaultCollection = true)]
            public HostsCollection Hosts =>
                (HostsCollection)base["hosts"];
        }
    }
}