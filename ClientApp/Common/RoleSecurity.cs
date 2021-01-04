using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientApp.Common
{
    public class RoleSecurity
    {
        private static Dictionary<int, string> ROLE_ = new Dictionary<int, string>()
        {
            {1,"Admin"},
            {2,"Company"},
            {3,"Customer"}
        };
        public static string GetValue(int? TKey)
        {
            return ROLE_.FirstOrDefault(x => x.Key == TKey).Value;
        }
        public static int GetKey(string TValue)
        {
            return ROLE_.FirstOrDefault(x => x.Value == TValue).Key;
        }
    }
}