
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;



namespace KolpackiRWypozyczalnia.Infrastracture
{
    public static class SessionHelper
    {
        private static object value;

        public static void SetObjectAsJson(this ISession session, string key, object value , object value1)
        {
            session.SetObjectAsJson(key, JsonConverter.SerializeObject(value));
        }
        public static void GetObjectFromJson<T>(this ISession session, string key, object value)
        {
            var value = session.GetString(key);
            return  value ==null ? default(T): JsonConverter.DeserializeObject <T>(value);
        }

        internal static object GetObjectAsJson<T>(ISession session, string cartKey)
        {
            throw new NotImplementedException();
        }

        internal static object GetObjectFromJson<T>(ISession session, string cartKey)
        {
            throw new NotImplementedException();
        }
    }
}
