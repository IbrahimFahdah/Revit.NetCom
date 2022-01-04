using Autodesk.Revit.UI;
using Revit.interop.Contacts;
using System.Runtime.InteropServices;

namespace Revit.interop
{
    /// <summary>
    /// A wrapper around Revit UIControlledApplication
    /// </summary>
    [ComVisible(true)]
    public class RevitApp : IRevitApp
    {
        private UIControlledApplication application;

        public RevitApp(UIControlledApplication application)
        {
            this.application = application;
        }

        public string VersionName
        {
            get
            {
                return application.ControlledApplication.VersionName;
            }

            set => throw new System.NotImplementedException();
        }
    }
}