# Out-of-process COM Server to acess Revit from .Net Core App

This is a proof of concept to demonstrates a way to create an out-of-process COM server in .NET Framework to acess Revit from .Net Core App

## Solution content
- RevitComServer: the .Net Framework com server.
- Revit.interop.Contacts: Com interfaces.
- Revit.interop: Revit external command to start the server and pass the Revit app to the com server to access by other apps.
- ManagedCoreClient: .Net core app to test access to the Revit app via the com server.

## Prerequisites

- You need to have a Revit app installed.
- You need to build the solution and register the com server.

## Com server registeration
- In Admin mode, use Tlbexp.exe to build the type library for Revit.interop.Contacts.dll and copy to the server bin. You can use the following command to build the tlb file.
```Tlbexp.exe "[DllDir]Revit.interop.Contacts.dll /out:"[RevitServerBinDir]\Revit.interop.Contacts.tlb""```
- In Admin mode, register the server using the following command
```[Path]\RevitComServer.exe /regserver```