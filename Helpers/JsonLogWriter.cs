using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Destiny2.Helpers
{
  class JsonLogWriter : ITraceWriter
  {
    private readonly ILogger _logger;

    public TraceLevel LevelFilter => TraceLevel.Verbose;

    public JsonLogWriter(ILogger<JsonLogWriter> logger)
    {
      _logger = logger;
    }

    public void Trace(TraceLevel level, string message, Exception ex)
    {
        if(ex != null)
        {
            _logger.LogError(ex, message);
            return;
        }

        switch(level)
        {
            case TraceLevel.Error:
            {
                _logger.LogError(message);
                break;
            }
            case TraceLevel.Warning:
            {
                _logger.LogWarning(message);
                break;
            }
            case TraceLevel.Info:
            {
                _logger.LogInformation(message);
                break;
            }
            case TraceLevel.Verbose:
            {
                _logger.LogDebug(message);
                break;
            }
        }
    }
  }
}