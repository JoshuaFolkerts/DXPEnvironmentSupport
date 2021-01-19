using System;

namespace DXPEnvironmentSupport.Configuration
{
    [Flags]
    public enum DXPEnviromentType
    {
        Local,

        Integration,

        PreProduction,

        Production
    }
}