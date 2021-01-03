using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace User.Service.Extensions
{
    /// <summary>
    /// Extension methods for HttpContent.
    /// </summary>
    public static class HttpContentExtensions
    {
        /// <summary>
        /// Returns a Task that will yield an object of the specified type <typeparamref name="T" /> from the content instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json, JsonDefaults.SerializerSettings);
            return value;
        }
    }
}

