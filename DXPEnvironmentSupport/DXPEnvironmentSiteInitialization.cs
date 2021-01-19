using DXPEnvironmentSupport.Configuration;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using static DXPEnvironmentSupport.Configuration.HostsCollection;
using static DXPEnvironmentSupport.Configuration.SitesCollection;

namespace DXPEnvironmentSupport
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DXPEnvironmentSiteInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            string environment = ConfigurationManager.AppSettings["episerver:EnvironmentName"];
            if (!string.IsNullOrWhiteSpace(environment))
            {
                if (Enum.TryParse(environment, out DXPEnviromentType result))
                {
                    if (DXPConfiguration.IsEnabled())
                    {
                        var environmentConfig = DXPConfiguration.GetEnvironment(result);
                        if (environmentConfig != null)
                            this.PopulateSitesNodes(context, environmentConfig);
                    }
                }
            }
        }

        private void PopulateSitesNodes(InitializationEngine context, EnvironmentConfigElement environmentConfig)
        {
            var siteDefinitionRepository = context.Locate.Advanced.GetInstance<ISiteDefinitionRepository>();

            foreach (var site in environmentConfig.Sites)
            {
                var siteConfig = site as SiteConfigElement;
                if (Guid.TryParse(siteConfig.Id, out Guid result))
                {
                    var definition = siteDefinitionRepository.Get(result);
                    if (definition != null)
                    {
                        var siteDefinitionClone = definition.CreateWritableClone();
                        siteDefinitionClone.SiteUrl = new Uri(siteConfig.Url);

                        if (!string.IsNullOrWhiteSpace(siteConfig.Name))
                            siteDefinitionClone.Name = siteConfig.Name;

                        if (siteConfig.UpdateAllHosts)
                        {
                            siteDefinitionClone.Hosts.Clear();

                            foreach (var host in siteConfig.Hosts)
                            {
                                var hostConfig = host as HostConfigElement;
                                var newHost = new HostDefinition()
                                {
                                    Name = hostConfig.HostName,
                                    Type = HostDefinitionType.Undefined
                                };

                                if (!string.IsNullOrWhiteSpace(hostConfig.Type))
                                {
                                    if (Enum.TryParse(hostConfig.Type, out HostDefinitionType hostType))
                                    {
                                        newHost.Type = hostType;
                                    }
                                }

                                if (!string.IsNullOrWhiteSpace(hostConfig.Culture))
                                {
                                    newHost.Language = new System.Globalization.CultureInfo(hostConfig.Culture);
                                }

                                siteDefinitionClone.Hosts.Add(newHost);
                            }
                        }
                        siteDefinitionRepository.Save(siteDefinitionClone);
                    }
                }
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}