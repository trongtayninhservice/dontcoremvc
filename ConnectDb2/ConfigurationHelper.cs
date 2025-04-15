using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConnectDb2
{
    public static class ConfigurationHelper
    {
        public static string GetConnectionString()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(currentDirectory)?.FullName ?? currentDirectory;
        //D:\daitovn\111Research\dotnet\dotnetcoremvc\dontcoremvc\ConnectDb2\ConfigurationHelper.cs
        var config = new ConfigurationBuilder()
                .SetBasePath(parentDirectory + "\\ConnectDb2")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}