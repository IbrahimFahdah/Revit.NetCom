using Revit.interop.Contacts;
using RevitComServer;
using RevitComServer.COMRegistration;
using System;
using System.Diagnostics;
using System.IO;

namespace OutOfProcCOM
{
    class Program
    {
        private static readonly string exePath = Path.Combine(AppContext.BaseDirectory, "RevitComServer.exe");

#if EMBEDDED_TYPE_LIBRARY
        private static readonly string tlbPath = exePath;
#else
        private static readonly string tlbPath = Path.Combine(AppContext.BaseDirectory, Constants.TypeLibraryName);
#endif

        static void Main(string[] args)
        {
            using (var consoleTrace = new ConsoleTraceListener())
            {
                Trace.Listeners.Add(consoleTrace);
            }

            if (args.Length == 1)
            {
                string regCommandMaybe = args[0];
                if (regCommandMaybe.Equals("/regserver", StringComparison.OrdinalIgnoreCase) || regCommandMaybe.Equals("-regserver", StringComparison.OrdinalIgnoreCase))
                {
                    // Register local server and type library
                    LocalServer.Register(Constants.ServerClassGuid, exePath, tlbPath);
                    return;
                }
                else if (regCommandMaybe.Equals("/unregserver", StringComparison.OrdinalIgnoreCase) || regCommandMaybe.Equals("-unregserver", StringComparison.OrdinalIgnoreCase))
                {
                    // Unregister local server and type library
                    LocalServer.Unregister(Constants.ServerClassGuid, tlbPath);
                    return;
                }
            }

            using (var server = new LocalServer())
            {
                server.RegisterClass<RevitServer>(Constants.ServerClassGuid);
                server.Run();
            }
        }
    }
}
