using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ExtentionMethods
{
    public static class ConfigurationMethods
    {
        public static bool IsLoaded(this IConfiguration config)
        {
            return config.AsEnumerable().Any();
        } 
    }
}
