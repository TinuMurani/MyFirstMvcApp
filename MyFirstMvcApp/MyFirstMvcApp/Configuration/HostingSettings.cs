using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Configuration
{
    public class HostingSettings
    {
        public string HostingProviderName { get; set; }
        public string BaseUrl { get; set; }
        public string SqlServerAddress { get; set; }
    }
}
