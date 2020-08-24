# Xamarin Forms Advanced Template v.2
Xamarin.Forms template. Packed with the most useful things for the developer.
**Updated to second version - please, read description**.

### Description

Zip file is a template package. It contains:
* **AppSettings.json** `(for constants & useful data, retrieve easily with IConfiguration)`
* **Microsoft Extensions** `(Host, DI, Logging)`
* **Helpers** `(event-to-command behaviour, image resource, translate, viewmodel locator)`
* **Async commands** `(via AsyncAwaitBestPractices.MVVM library)`
* **Resources** `(with small amount of common info)`
* **Utility & crossplatform services**
* **Better API management** `(via Refit library)`
* **Base viewmodel**
* **Base page view**
* **Xamarin.Forms Shell**
* **Ripple effects & attached commands** `(via XamEffects library)`
* **Analytics & diagnostics** `(via AppCenter libraries)`
* **Image better handling** `(via glidex.forms library on Android & Xamarin.Forms.Nuke library on iOS)`
* **Modified **`App.xaml.cs`** file**
* **Startup (configure) file**
* **Android & iOS preconfigured projects**
* **Startup tracing & LLVM enabled for Android**

### Installation

Place **.zip** file from this repo into the *`%userprofile%\Documents\Visual Studio 2019\Templates\ProjectTemplates`* folder. Open **Visual Studio**, select **"Create new"** option and search for `Xamarin Forms Advanced Template.` Scroll down to see the template.

### In-depth overview

> **AppSettings.json** `(for constants & useful data, retrieve easily with IConfiguration)`

You can store any setting or public data within this .json file. There are two files, each will be used in a particular mode - debug & release. Retrieve data from injecting IConfiguration into any place of the code.

> **Microsoft Extensions** `(Host, DI, Logging)`

Host from the [Microsoft.Extensions.Hosting](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host) provides ability to store dependencies & other settings. You register new dependencies and retrieve them via [Microsoft.Extensions.DependencyInjection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection). Optionally, setup logging using [Microsoft.Extensions.Logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/).

> **Helpers** `(event-to-command behaviour, image resource, translate, viewmodel locator)`

Some useful helpers to let you build more fluent & productive app.

`EventToCommandBehaviour` helps you to bind a command from your viewmodel to a control, that doesn't support commanding interface directly.

`ImageResource` will find and consume the image from shared "Assets" folder (you should provide the right path, e.g. *`[ProjectName].Assets.[ImageName].[ImageExtension]`*).

`Translate` lets you get translated string by the key from your `AppResources.`

`ViewModelLocator` is intended for wiring your page with desired viewmodel. It's better to consume all of the helpers from the `XAML` code.

> **Async commands** `(via AsyncAwaitBestPractices.MVVM library)`

Async commands let you avoid using `async void` in your code and provide some useful additional setup elements. Read more [here](https://github.com/brminnick/AsyncAwaitBestPractices).

> **Resources** `(with small amount of common info)`

Pre-configured resources folder. `AppResources.resx` is language neutral. You should add `AppResources.[TwoLetterLanguageISOCode].resx` in order to provide translation.

> **Utility & crossplatform services**

Common application services. They may make your life as a developer a little easier.

`AppQuit` is a service for handling application quit. It is **Android** only.

`Keyboard` is a service for hiding keyboard on demand.

`Localize` is a service for providing ability to change language of your application, again, on demand.

`Toast` is a service for displaying toast messages.

`Analytics` is a service for tracking errors and events inside of your app with the help of **AppCenter**.

`Language` is a service for managing in-app languages & cultures.

`Message` is a service which displays different types of dialogs with different content.

`Navigation` is a service which is intended to be used throughout the application as a navigation provider. Right now it depends on another `Shell` service because of this template contains `AppShell` (Xamarin.Forms Shell).

`Settings` is a service for storing & managing in-app key-values.

`Shell` is a service for Xamarin.Forms Shell navigation execution.

> **Better API management** `(via Refit library)`

This library is great for declaring API. Read more [here](https://github.com/reactiveui/refit).

> **Base page view**

Base page view. You have to set viewmodel using `ViewModelType` property (pass a type).

> **Base viewmodel**

Base viewmodel with INotifyPropertyChanged implementation.

> **Xamarin.Forms Shell**

A new, modern way to organize & structure application navigation. Read more [here](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/).

> **Ripple effects & attached commands** `(via XamEffects library)`

Read more [here](https://github.com/mrxten/XamEffects).

> **Analytics & diagnostics** `(via AppCenter libraries)`

AppCenter tracks analytics & diagnostics data. Read more [here](https://docs.microsoft.com/en-us/appcenter/dashboard/).

> **Image better handling** `(via glidex.forms library on Android & Xamarin.Forms.Nuke library on iOS)`

Read more [here](https://github.com/roubachof/Xamarin.Forms.Nuke).

> **Modified **`App.xaml.cs`** file**

`App.xaml.cs` with a little setup. `Services` store static property is present here. Also, contains some adjustments with keyboard & other services.

> **Startup (configure) file**

`Startup.cs` is an entry point for your app. You should retrieve shared `App` class from `Init` method inside your platform-specific class and provide a collection of native services implementation. Also, here you register all your dependencies & routes (for Xamarin.Forms Shell).

> **Android & iOS preconfigured projects**

Android & iOS have already been preconfigured to use `Startup` class & provide native services. Also, Android has a slightly edited   `.csproj` file for a better performance.

> **Startup tracing & LLVM enabled for Android**

Startup tracing is a feature for decreasing application startup time with a small side effect on APK size. Read more [here](https://devblogs.microsoft.com/xamarin/faster-startup-times-with-startup-tracing-on-android/). You can also setup custom profile for further improvements by yourself. Read more [here](https://devblogs.microsoft.com/xamarin/faster-android-startup-times-with-startup-tracing/). LLVM is an optimizing compiler. Read about it [here](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/release-prep/?tabs=windows#llvm-optimizing-compiler). Linker behaviour is set to "Sdk Assemblies Only".
