# Xamarin.Forms Advanced Template v3.0
Xamarin.Forms template for Visual Studio. Packed with [AppHosting](https://github.com/SnowPowerCore/AppHosting) library + some must-haves for every developer.

**Introducing third version: featuring AppHosting library!** 
(if you wish to review previous version, navigate to the [releases/v2](https://github.com/SnowPowerCore/Xamarin-Forms-Advanced-Template/tree/releases/v2) branch).

Feel free to contribute or create issues for this project.

### Description

Zip file is a template package. It contains:
* **[AppHosting](https://github.com/SnowPowerCore/AppHosting)** `(full-fledged dependency container with Xamarin.Forms integration)`
* **Async commands** `(via AsyncAwaitBestPractices.MVVM library)`
* **Helpers** `(event-to-command behaviour, image resource, translate)`
* **Resources** `(with small amount of pre-installed common labels)`
* **Utility & cross-platform services**
* **Better API management** `(via Refit library)`
* **Base page view**
* **Xamarin.Forms Shell & Legacy Tabbed Page** `(Tabbed page by default)`
* **Ripple effects** `(via XamEffects library)`
* **Task loader mechanism & view** `(via Sharpnado.TaskLoaderView library)`
* **Analytics & diagnostics** `(via AppCenter libraries)`
* **Image better handling** `(via glidex.forms library on Android & Xamarin.Forms.Nuke library on iOS)`
* **Android & iOS pre-configured projects**
* **Startup tracing & LLVM enabled for Android**

### Installation

Place **.zip** file from this repo's latest release into the *`%userprofile%\Documents\Visual Studio 2019\Templates\ProjectTemplates`* folder. Open **Visual Studio**, select **"Create new"** option and search for `Xamarin Forms Advanced Template.` Scroll down to see the template.
If you're not using VS for Windows, or prefer another IDE, please, consider cloning this repo instead.

### In-depth overview

> **[AppHosting](https://github.com/SnowPowerCore/AppHosting)** `(full-fledged dependency container with Xamarin.Forms integration)`

Featuring brand new library that's going to help you structure your Xamarin.Forms mobile architecture in a better way.

***

> **Async commands** `(via AsyncAwaitBestPractices.MVVM library)`

Async commands let you avoid using `async void` in your code and provide some useful additional setup elements. Read more [here](https://github.com/brminnick/AsyncAwaitBestPractices).

***

> **Helpers** `(event-to-command behaviour, image resource, translate, viewmodel locator)`

Some useful helpers to let you build more fluent & productive app.

`EventToCommandBehaviour` helps you to bind a command from your viewmodel to a control, that doesn't support commanding interface directly.

`ImageResource` will find and consume the image from shared "Assets" folder (you should provide the right path, e.g. *`[ProjectName].Assets.[ImageName].[ImageExtension]`*).

`Translate` lets you get translated string by the key from your `AppResources.`

`ViewModelLocator` is intended for wiring your page with desired viewmodel. It's better to consume all of the helpers from the `XAML` code.

***

> **Resources** `(with small amount of pre-installed common labels)`

Pre-configured resources folder. `AppResources.resx` is language neutral. You should add `AppResources.[TwoLetterLanguageISOCode].resx` in order to provide translation (add new file into the same folder where you have `AppResources.resx` defined).

***

> **Utility & cross-platform services**

Common application services. They may make your life as a developer a little easier.

`AppQuit` is a service for handling application quit. It is **Android** only.

`Keyboard` is a service for hiding keyboard on demand.

`Localize` is a service for providing ability to change language of your application, again, on demand.

`Toast` is a service for displaying toast messages.

`Application`, `ApplicationInfrastructure` and `ApplicationTracking` are services for handling respective application parts. `Application` service is just a convenient aggregator.

`Analytics` is a service for tracking errors and events inside of your app with the help of **AppCenter**.

`Language` is a service for managing in-app languages & cultures.

`Message` is a service which displays different types of dialogs with different content.

`Settings` is a service for storing & managing in-app key-values.

***

> **Better API management** `(via Refit library)`

This library is great for declaring API. Read more [here](https://github.com/reactiveui/refit).

***

> **Base page view**

Base page view. You have to set viewmodel using `ViewModelType` property (pass a type).

***

> **Xamarin.Forms Shell & Legacy Tabbed Page** `(Tabbed page by default)`

Choose the preferred way of navigation and use it along with `AppHosting` integration.

***

> **Ripple effects** `(via XamEffects library)`

Read more [here](https://github.com/mrxten/XamEffects).

***

> **Task loader mechanism & view** `(via Sharpnado.TaskLoaderView library)`

Amazing way to keep your `ViewModel` clean and fresh. Read more [here](https://github.com/roubachof/Sharpnado.TaskLoaderView).

***

> **Analytics & diagnostics** `(via AppCenter libraries)`

AppCenter tracks analytics & diagnostics data. Read more [here](https://docs.microsoft.com/en-us/appcenter/dashboard/).

***

> **Image better handling** `(via glidex.forms library on Android & Xamarin.Forms.Nuke library on iOS)`

Read more [here](https://github.com/roubachof/Xamarin.Forms.Nuke).

***

> **Android & iOS pre-configured projects**

Android & iOS have already been pre-configured to use `AppHosting` library & provide native services. Also, Android has a slightly edited `.csproj` file for better performance.

***

> **Startup tracing & LLVM enabled for Android**

Startup tracing is a feature for decreasing application startup time with a small side effect on APK size. Read more [here](https://devblogs.microsoft.com/xamarin/faster-startup-times-with-startup-tracing-on-android/). You can also setup custom profile for further improvements by yourself. Read more [here](https://devblogs.microsoft.com/xamarin/faster-android-startup-times-with-startup-tracing/). LLVM is an optimizing compiler. Read about it [here](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/release-prep/?tabs=windows#llvm-optimizing-compiler). Linker behaviour is set to "Sdk Assemblies Only".
