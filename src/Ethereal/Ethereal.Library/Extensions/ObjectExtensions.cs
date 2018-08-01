using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Ethereal.Library.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert an object to a dictionary.
        /// </summary>
        /// <param name="source">The object to convert.</param>
        /// <param name="bindingAttr">
        /// An optional set of flags to determine which object properties to include in the conversion.
        /// </param>
        /// <returns>A dictionary representation of <paramref name="source"/>.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="source"/> is null.
        /// </exception>
        [DebuggerStepThrough]
        public static IDictionary<string, object> AsDictionary(
            this object source,
            BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance
            )
        {
            Invariant.IsNotNull(source, nameof(source));

            return source.GetType().GetProperties(bindingAttr).ToDictionary(
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
        }
    }
}
