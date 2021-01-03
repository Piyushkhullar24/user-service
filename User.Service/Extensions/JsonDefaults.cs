using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Service.Extensions
{
    /// <summary>
    /// Standard JSON settings
    /// </summary>
    public static class JsonDefaults
    {
        /// <summary>
        /// Static settings with default behavior.
        /// </summary>
        public static JsonSerializerSettings SerializerSettings { get; } = CreateDefault();

        /// <summary>
        /// Configure default behavior for any JsonSerializerSettings.
        /// </summary>
        /// <param name="settings"></param>
        public static void ConfigureSerializerSettings(this JsonSerializerSettings settings)
        {
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.Converters.Add(new StringEnumConverter());
            settings.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
        }

        private static JsonSerializerSettings CreateDefault()
        {
            var settings = new JsonSerializerSettings();
            ConfigureSerializerSettings(settings);
            return settings;
        }
    }
}
