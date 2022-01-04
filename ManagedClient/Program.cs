
using Revit.interop.Contacts;
using System;
using System.Runtime.InteropServices;

namespace ManagedClient
{
    class Program
    {
        static void Main(string[] _)
        {
            // Option 1 to connect to the out-of-process server
            Type t = Type.GetTypeFromCLSID(Constants.ServerClassGuid);
            var server = (IServer)Activator.CreateInstance(t);

            // Option 1 to connect to the out-of-process server
            //object obj;
            //int hr = Ole32.CoCreateInstance(Constants.ServerClassGuid, IntPtr.Zero, Ole32.CLSCTX_LOCAL_SERVER, typeof(IServer).GUID, out obj);
            //if (hr < 0)
            //{
            //    Marshal.ThrowExceptionForHR(hr);
            //}
            //var server = (IServer)obj;

            if (server.GetCommnectionStatus())
            {
                // We can connect to revit so get Revit version
                Console.WriteLine($"\u03C0 = {server.GetApp().VersionName}");
            }
            else
            {
                // Something went wrong. Maybe revit is not running. 
                Console.WriteLine($"Failed to connect to Revit. Revit is not running or your are running the app in VS Debug mode.");
            }
            Console.ReadLine();
        }
    }
}
