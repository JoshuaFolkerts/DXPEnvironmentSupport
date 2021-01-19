
# DXP Environment Support
Allows you to manage your sites via initialization in DXP Environments
The web.config structure follows standard hierarchial for the sites node.  Allows you to manage multiple sites and hosts per environment along with setting default wildcard as well.
## Sample Multisite web.config setup

    <dxpConfigurationSection enabled="true">
        <environment environmentType="Integration">
        <sites>
            <site id="e8829d0d-4901-4ced-80e2-b052b7d5a8ca" name="My Demo" url="http://localhost.com" updateAllHosts="true">
            <hosts>
                <host hostName="*" culture="" type="" scheme="" />
                <host hostName="josh.int.com" culture="" type="" scheme="" />
                <host hostName="epi.int.com" culture="" type="RedirectPermanent" scheme="https" />
                <host hostName="work.int.com" culture="" type="RedirectPermanent" scheme="" />
                <host hostName="all.int.com" culture="" type="RedirectPermanent" scheme="" />
                <host hostName="proj.int.com" culture="" type="RedirectPermanent" scheme="" />
            </hosts>
            </site>
        </sites>
        </environment>
        <environment environmentType="Preproduction">
        <sites>
            <site id="e8829d0d-4901-4ced-80e2-b052b7d5a8ca" url="http://localhost:49631/">
            <hosts>
                <host hostName="josh.prep.com" culture="" type="" scheme="" />
                <host hostName="epi.prep.com" culture="" type="" scheme="" />
                <host hostName="work.prep.com" culture="" type="" scheme="" />
                <host hostName="all.prep.com" culture="" type="" scheme="" />
                <host hostName="proj.prep.com" culture="" type="" scheme="" />
            </hosts>
            </site>
        </sites>
        </environment>
        <environment environmentType="Production">
        <sites>
            <site id="e8829d0d-4901-4ced-80e2-b052b7d5a8ca" url="http://localhost:49631/">
            <hosts>
                <host hostName="www.prod.com" culture="" type="" scheme="" />
                <host hostName="epi.prod.com" culture="" type="" scheme="" />
                <host hostName="work.prod.com" culture="" type="" scheme="" />
                <host hostName="all.prod.com" culture="" type="" scheme="" />
                <host hostName="proj.prod.com" culture="" type="" scheme="" />
            </hosts>
            </site>
        </sites>
        </environment>
    </dxpConfigurationSection>
