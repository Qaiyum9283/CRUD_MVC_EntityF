using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SMS_Qaiyum
{
    public class JsonHelper
    {
        public static JsonSerializerSettings JsonSerializerSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore, // Handle circular references
                    Formatting = Formatting.None // Adjust formatting as needed (e.g., Formatting.Indented for pretty-print)
                };
            }
        }
    }
}