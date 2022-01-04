using Revit.interop.Contacts;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RevitComServer
{
    [ComVisible(true)]
    [Guid(Constants.ServerClass)]
    [ComDefaultInterface(typeof(IServer))]
    public sealed class RevitServer : IServer
    {
        static IRevitApp _revitApp ;
        static int _instances;

        public RevitServer()
        {
            Trace.WriteLine($"Connections {++_instances}");
        }

        public bool GetCommnectionStatus()
        {
            return _revitApp != null;
        }

        public IRevitApp GetApp()
        {
            Trace.WriteLine($"Running {nameof(RevitServer)}.{nameof(IServer.GetApp)}");
            return _revitApp;
        }

        public void SetApp(object application)
        {
            Trace.WriteLine($"Running {nameof(RevitServer)}.{nameof(IServer.SetApp)}");
            _revitApp = (IRevitApp)application;
        }
    }
}
