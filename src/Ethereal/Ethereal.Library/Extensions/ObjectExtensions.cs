using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Ethereal.Library.Extensions
{
    public static class ObjectExtensions
    {
        [DebuggerStepThrough]
        public static IDictionary<string, object> AsDictionary(
            this object self,
            BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance
            )
        {
            return self.GetType().GetProperties(bindingAttr).ToDictionary(
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(self, null)
            );
        }
    }
}
