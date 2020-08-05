using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Lib
{
    public static class JSONHelper
    {
        // From https://www.cnblogs.com/owenzh/p/11022238.html

        /// <summary>
        /// 把对象转换为JSON字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>JSON字符串</returns>
        public static string ObjectToJSON(object obj)
        {
            if (obj == null) return null;
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 把Json文本转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json_string"></param>
        /// <returns></returns>
        public static T JSONToObject<T>(string json_string)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json_string);
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
