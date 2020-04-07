# Xamarin Forms Advanced Template
Xamarin.Forms template. Packed with the most useful things for the developer.

### Description

Zip file is a template package. It contains:
* **Microsoft Extensions** `(Host, DI, Logging)`
* **Helpers** `(event-to-command behaviour, image resource, translate, viewmodel locator)`
* **Async commands** `(via AsyncAwaitBestPractices.MVVM library)`
* **Resources** `(with small amount of common info)`
* **Utility & crossplatform services**
* **Better API management** `(via Refit library)`
* **Base viewmodel**
* **Xamarin.Forms Shell**
* **Material Design** `(via XF.Material library)`
* **Ripple effects & attached commands** `(via XamEffects library)`
* **Analytics & diagnostics** `(via AppCenter libraries)`
* **Image better handling** `(via glidex.forms library on Android & Xamarin.Forms.Nuke library on iOS)`
* **Modified **`App.xaml.cs`** file**
* **Startup (configure) file**
* **Android & iOS preconfigured projects**
* **Startup tracing & LLVM enabled for Android**

### Installation

Place **.zip** file from this repo to *`%userprofile%\Documents\Visual Studio 2019\Templates\ProjectTemplates`* folder. Open **Visual Studio**, select **"Create new"** option and search for `Xamarin Forms Advanced Template.` Scroll down to see the template.

### In-depth overview

> **Microsoft Extensions** `(Host, DI, Logging)`

Host from the [Microsoft.Extensions.Hosting](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host) provides ability to store dependencies & other settings. You register new dependencies and retrieve them via [Microsoft.Extensions.DependencyInjection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection). Optionally, setup logging using [Microsoft.Extensions.Logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/).

> **Helpers** `(event-to-command behaviour, image resource, translate, viewmodel locator)`

Some useful helpers to let you build more fluent & productive app. `EventToCommandBehaviour` helps you to bind a command from your viewmodel to a control, that doesn't support commanding interface directly. `ImageResource` will find and consume the image from shared "Assets" folder (you should provide the right path, e.g. *`[ProjectName].Assets.[ImageName].[ImageExtension]`*). `Translate` lets you get translated string by the key from your `AppResources.` `ViewModelLocator` is intended for wiring your page with desired viewmodel. It's better to consume all of the helpers from the `XAML` code.
