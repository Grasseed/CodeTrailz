using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TreeForSuccess.Utilities
{
    public static class JsonSettings
    {
        // JSON 中文設定不轉換Unicode
        public static JsonSerializerOptions GetJsonSettings()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            return options;
        }
    }
}