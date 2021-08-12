using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqBase
    {

        /// <summary>
        /// Возвращает строку параметров для GET-запроса, собранную из всех свойст классам, 
        /// помеченных атрибутом JsonProperty.
        /// Если параметры отсутствуют, то возвращается пустая строка,
        /// в противно случае возвращается строка, начинающаяся с символа "?"
        /// Например: "?instrument=LTC-BTC&amp;from=2018-03-15T09:00&amp;till=2018-03-15T11:00"
        /// </summary>
        /// <returns></returns>
        public string ToGetParams()
        {

            var parDic = new Dictionary<string, string>();
            var jToken = JToken.FromObject(this);

            string ConvertToStr(object o)
            {
                if (!(o is JValue val)) return null;

                if (!JTYPES_FOR_GET_REQUESTS.Contains(val.Type) || val.Value == null) return null;
                var strVal = val.Type == JTokenType.Date ? ((DateTime)val.Value).ToString("yyyy-MM-ddTHH:mm:ssZ") : val.ToString(Formatting.None);
                if (val.Type == JTokenType.String)
                {
                    strVal = strVal.Substring(1, strVal.Length - 2);
                }

                return strVal;
            }

            foreach (var prop in jToken.Children())
            {
                if (prop.Type != JTokenType.Property) continue;

                var item = (JProperty) prop;
                if (item.Value.Type == JTokenType.Array)
                {
                    var lst = new List<string>();

                    foreach (var arrItem in item.Value.Children())
                    {
                        var str = ConvertToStr(arrItem);
                        if (str != null) lst.Add(str);
                    }

                    if (lst.Any()) parDic[item.Name] = string.Join(",", lst);
                    continue;
                }

                var strProp = ConvertToStr(item.Value);
                if (strProp!= null) parDic[item.Name] = strProp;
            }

            if (parDic.Any())
            {
                return "?" + string.Join("&", parDic.Select(x => $"{x.Key}={HttpUtility.UrlEncode(x.Value)}"));
            }

            return string.Empty;
        }

        private static readonly JTokenType[] JTYPES_FOR_GET_REQUESTS = {JTokenType.Integer, JTokenType.Float, JTokenType.String, JTokenType.Boolean, JTokenType.Date};
    }
}
