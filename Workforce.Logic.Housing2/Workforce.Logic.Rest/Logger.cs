using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce.Logic.Rest
{
  public class Logger
  {
    private static readonly log4net.ILog log = LogHelper.GetLogger();//log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public void LoggerMethod()
    {
      log.Error("This is an error message");
    }

    public void InfoLog()
    {
      log.Info("This is information");
    }

    public void WarningLog()
    {
      log.Warn("This is a warning message");
    }

    public void FatalLog()
    {
      log.Fatal("This is a fatal log message");
    }
  }
}