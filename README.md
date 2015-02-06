# XFEto
Xamarin.Forms for Eto

The repositiory hold an initial port of Xamarin Forms to the cross platform UI framework Eto.
This "port" is still incomplete (it's about 90% there) and is not ready for production use of any kind.

What's here:

- Harness.Platform.Support : A set of convenience and support code used to port XF to Eto.
- Xamarin.Platform.Loader : A shim for XF used to implement unsupported platforms. It exposes XF internals to nonfriend assemblies.
- Xamarin.Forms.Platform.Net : Implementations of XF platform components that can be shared with all full framework platforms.
- Xamarin.Forms.EtoForms : Support classes and Controls for Eto. This includes controls available in Eto that don't have an analog in XF.
- Xamarin.Forms.Platform.EtoForms : The XF platform for Eto.
- NuProj projects for creating Nuget Packages (Harness.Platform.Support, Xamarin.Forms.EtoForms, Xamarin.Forms.Shim)

What does it need:

- Tests : There are none.
- The remaining unimplemented renderers for Eto
- Documentation : There is very little inline documentation.

Licensed under Apache 2.0, so enjoy.

