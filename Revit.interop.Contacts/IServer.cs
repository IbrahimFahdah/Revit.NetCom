using System;
using System.Runtime.InteropServices;

namespace Revit.interop.Contacts
{
    [ComVisible(true)]
    [Guid(Constants.ServerInterface)]
    public interface IServer
    {
        bool GetCommnectionStatus();

        void SetApp(object application);

        IRevitApp GetApp();
    }
}
