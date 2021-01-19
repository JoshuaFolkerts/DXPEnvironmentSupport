using System.Configuration;

namespace DXPEnviromentSupport.Configuration
{
    public class EnviromentCollection : ConfigurationElementCollection
    {
        public EnviromentCollection()
        {
            EnvironmentConfigElement details = (EnvironmentConfigElement)CreateNewElement();
            if (!string.IsNullOrEmpty(details.EnvironmentType))
                Add(details);
        }

        public override ConfigurationElementCollectionType CollectionType =>
            ConfigurationElementCollectionType.BasicMap;

        protected override ConfigurationElement CreateNewElement() =>
            new EnvironmentConfigElement();

        protected override object GetElementKey(ConfigurationElement element) =>
            ((EnvironmentConfigElement)element).EnvironmentType;

        public EnvironmentConfigElement this[int index]
        {
            get
            {
                return (EnvironmentConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public EnvironmentConfigElement this[string name] =>
             (EnvironmentConfigElement)BaseGet(name);

        public int IndexOf(EnvironmentConfigElement details) =>
            BaseIndexOf(details);

        public void Add(EnvironmentConfigElement details)
        {
            BaseAdd(details);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(EnvironmentConfigElement details)
        {
            if (BaseIndexOf(details) >= 0)
                BaseRemove(details.EnvironmentType);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override string ElementName =>
            "environment";
    }
}