using System;
using System.Collections.Generic;
using System.Text;

namespace HanJie.CSLCN.Models.Common
{
    public class AppSettings
    {
        public Logging Logging { get; set; }

        public string AllowedHosts { get; set; }
        public string ConnectionString { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }

    }

    public class LogLevel
    {
        public string Default { get; set; }
    }
}
