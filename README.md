
# DXP Environment Support
Allows you to manage your sites via initialization in DXP Environments
The web.config structure follows standard hierarchial for the sites node.  Allows you to manage multiple sites and hosts per environment along with setting default wildcard as well.
## Sample Multisite web.config setup

    <dxpConfigurationSection enabled="true">
        <environment environmentType="Integration">
            <sites>
                <site id="00000000-0000-0000-0000-000000000000" url="int.epi.com" name="IntSite1" updateAllHosts="true">
                    <hosts>
                        <host hostName="*" culture="" type="" scheme="" />
                        <host hostName="int.epi.com" culture="" type="Primary" scheme="" />
                        <host hostName="perm.epi.com" culture="" type="RedirectPermanent" scheme="" />
                        <host hostName="temp.epi.com" culture="" type="RedirectTemporary" scheme="" />
                        <host hostName="edit.epi.com" culture="" type="Edit" scheme="" />
                    </hosts>
                </site>
                <site id="10000000-0000-0000-0000-000000000000" url="int2.epi.com" name="IntSite2" updateAllHosts="true">
                    <hosts>
                        <host hostName="int2.epi.com" culture="" type="Primary" scheme="" />
                    </hosts>
                </site>
            </sites>
        </environment>
        <environment environmentType="Preproduction">
            <sites>
                <site id="00000000-0000-0000-0000-000000000000" url="prep.epi.com" name="PreProdSite1" updateAllHosts="true">
                    <hosts>
                        <host hostName="*" culture="" type="" scheme="" />
                        <host hostName="prep.epi.com" culture="" type="Primary" scheme="" />
                    </hosts>
                </site>
            </sites>
        </environment>
        <environment environmentType="Production">
            <sites>
                <site id="00000000-0000-0000-0000-000000000000" url="prod.epi.com" name="ProdSite1" updateAllHosts="true">
                    <hosts>
                        <host hostName="*" culture="" type="" scheme="" />
                        <host hostName="prod.epi.com" culture="" type="Primary" scheme="" />
                    </hosts>
                </site>
            </sites>
        </environment>
    </dxpConfigurationSection>
