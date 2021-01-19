using System;

namespace DXPEnviromentSupport.Configuration
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