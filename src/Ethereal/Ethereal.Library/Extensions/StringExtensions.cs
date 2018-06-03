using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Web;

namespace Ethereal.Library.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        public static string AttributeEncode(this string self)
        {
            return HttpUtility.HtmlAttributeEncode(self);
        }

        [DebuggerStepThrough]
        public static string HtmlDecode(this string self)
        {
            return HttpUtility.HtmlDecode(self);
        }

        [DebuggerStepThrough]
        public static string HtmlEncode(this string self)
        {
            return HttpUtility.HtmlEncode(self);
        }

        [DebuggerStepThrough]
        public static T ToEnum<T>(this string self, T defaultValue) where T : struct, IComparable, IFormattable
        {
            var value = defaultValue;

            if (!string.IsNullOrWhiteSpace(self))
            {
                Enum.TryParse(self, true, out value);
            }

            return value;
        }

        [DebuggerStepThrough]
        public static Guid ToGuid(this string self)
        {
            var result = Guid.Empty;

            if (self != null && self.Length == 22)
            {
                var encoded = string.Concat(self.Replace("-", "+").Replace("_", "/"), "==");

                try
                {
                    var base64 = Convert.FromBase64String(encoded);

                    result = new Guid(base64);
                }
                catch (FormatException)
                {
                }
            }

            return result;
        }

        [DebuggerStepThrough]
        public static string UrlDecode(this string self)
        {
            return HttpUtility.UrlDecode(self);
        }

        [DebuggerStepThrough]
        public static string UrlEncode(this string self)
        {
            return HttpUtility.UrlEncode(self);
        }
    }
}
