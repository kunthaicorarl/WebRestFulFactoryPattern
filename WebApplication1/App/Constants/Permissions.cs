using System.Collections.Generic;

namespace WebRestFulFactoryPattern.App.Constants
{
public static class Permissions
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
    }
        public static string GeneratePermissionsForMethod(string module,string method)
        {
            return $"Permissions.{module}.{method}";
        }

        public static class Products
    {
        public const string View = "Permissions.Products.View";
        public const string Create = "Permissions.Products.Create";
        public const string Edit = "Permissions.Products.Edit";
        public const string Delete = "Permissions.Products.Delete";
    }
    public static class Logs
    {
            public const string View = "Permissions.Logs.View";
            public const string Create = "Permissions.Logs.Create";
            public const string Edit = "Permissions.Logs.Edit";
            public const string Delete = "Permissions.Logs.Delete";
    }

    }
}