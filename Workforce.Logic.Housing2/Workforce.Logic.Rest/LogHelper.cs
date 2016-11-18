using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Workforce.Logic.Rest
{
  public class LogHelper
  {
    public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
    {
      return log4net.LogManager.GetLogger(filename);
    }

    public static void SendError(log4net.ILog log,Exception ex)
    {
      if (ex.InnerException != null)
      {
        var error = "The error is this: " + ex.InnerException.ToString();
        log.Error(error);
      }
      else
      {
        var error = "The error is this: " + ex;
        log.Error(error);
      }
    }

  }
}