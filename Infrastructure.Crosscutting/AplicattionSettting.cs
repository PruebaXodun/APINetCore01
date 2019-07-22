using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Crosscutting
{
    public class AplicattionSettting
    {
        public string AplicationVersion { get; set; }
        public string ConnectionString { get; set; }
        public string Environment { get; set; }
    }
}
