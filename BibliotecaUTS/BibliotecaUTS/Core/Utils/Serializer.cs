using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BibliotecaUTS.Core
{
    public class Serializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings();

        static Serializer()
        {
            Settings.Formatting = Formatting.None;
            //#if DEBUG
            //            _settings.Formatting = Formatting.Indented;
            //#else
            //            _settings.Formatting = Formatting.None;
            //#endif
            Settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //_settings.Converters.Add(new JavaScriptDateTimeConverter());
            //_settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            //_settings.PreserveReferencesHandling = PreserveReferencesHandling.All;
        }

        public static string Serialize(object obj)
        {
            var result = string.Empty;
            try
            {
                if (obj != null)
                {
                    result = JsonConvert.SerializeObject(obj, Settings);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return result;
        }

        public static HtmlString SerializeHtml(object obj)
        {
            return new HtmlString(Serialize(obj));
        }
    }
}