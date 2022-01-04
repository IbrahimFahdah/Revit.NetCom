
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Autodesk;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Runtime.InteropServices;
using Revit.interop.Contacts;

namespace Revit.interop
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    internal partial class AppSample : IExternalApplication
    {
        IServer server;

        #region IExternalApplication Members

        public Autodesk.Revit.UI.Result OnShutdown(UIControlledApplication application)
        {
            TaskDialog.Show("Revit", "Quit External Application!");
            return Autodesk.Revit.UI.Result.Succeeded;
        }

        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            object obj;
            int hr = Ole32.CoCreateInstance(Constants.ServerClassGuid, IntPtr.Zero, Ole32.CLSCTX_LOCAL_SERVER, typeof(IServer).GUID, out obj);
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            server = (IServer)obj;
            server.SetApp(new RevitApp(application));
            TaskDialog.Show("Revit", application.ControlledApplication.VersionName);

            return Autodesk.Revit.UI.Result.Succeeded;
        }

        #endregion
    }
}
