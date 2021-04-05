using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace FileSync
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Log.Logger = InitializeLogging();
      }
      catch (Exception ex)
      {
        Log.Fatal(ex, "An unhandled exception has occured in the FileSync process");
      }
      finally
      {
        Log.CloseAndFlush(); 
      }
      
    }

    private static ILogger InitializeLogging()
    {
      var configuration = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", false, true)
                             .Build();

      var logger = new LoggerConfiguration()
                      .ReadFrom.Configuration(configuration)
                      .CreateLogger();

      return logger;
    }
  }
}
