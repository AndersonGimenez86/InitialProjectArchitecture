namespace AG.PaymentApp.Infrastructure.Crosscutting.IoC.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Resolving visual studio issue https://github.com/microsoft/vstest/issues/2008
    /// </summary>
    public static class AssemblyExtension
    {
        public static IEnumerable<Assembly> GetUserAssemblies(this AppDomain appDomain)
        {
            return appDomain.GetAssemblies()
                .Where(assembly =>
                {
                    var fullName = assembly.FullName;
                    return !(fullName.StartsWith("System.") || fullName.StartsWith("Microsoft."));
                });
        }
    }
}