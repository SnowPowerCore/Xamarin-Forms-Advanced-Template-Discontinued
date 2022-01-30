using Microsoft.Extensions.Logging;
using PropertyChanged;
using Sharpnado.Presentation.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsAdvancedTemplate.Models;
using XamarinFormsAdvancedTemplate.Services.Apple;
using XamarinFormsAdvancedTemplate.Services.Utils.Application;

namespace XamarinFormsAdvancedTemplate.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AppleViewModel
    {
        private readonly IApplicationService _application;
        private readonly IAppleService _apple;

        [DoNotNotify]
        public TaskLoaderNotifier<List<Apple>> ApplesLoader { get; } =
            new TaskLoaderNotifier<List<Apple>>
            {
                Result = new List<Apple>(),
            };

        public Apple SelectedApple { get; set; }

        public AppleViewModel(IApplicationService application,
                              IAppleService apple)
        {
            _application = application;
            _apple = apple;
        }

        public Task ApplesPageAppearingAsync()
        {
            _application.Tracking.ApplicationLogger.Log(LogLevel.Information, "Page's appearing");

            ApplesLoader.Load(LoadApplesAsync);

            return Task.CompletedTask;
        }

        public Task ApplesPageDisappearingAsync()
        {
            _application.Tracking.ApplicationLogger.Log(LogLevel.Information, "Page's disappearing");
            return Task.CompletedTask;
        }

        public Task NavigateToAppleDetailPageAsync(Apple selectedApple)
        {
            SelectedApple = selectedApple;
            return _application.Infrastructure.Navigation.NavigateToPageAsync("appleDetailPage");
        }

        public void HandleException(Exception e)
        {
            _application.Tracking.Analytics.TrackError(e);
            _application.Tracking.ApplicationLogger.Log(LogLevel.Error, e.Message);
        }

        private async Task<List<Apple>> LoadApplesAsync(bool isRefreshing)
        {
            var appleData = await _apple.GetApplesAsync()
                .ConfigureAwait(false);

            var appleError = appleData.GetDataOrErrorCode(out var apples, out _);

            if (!string.IsNullOrEmpty(appleError))
            {
                await _application.Infrastructure.Message
                    .DisplayErrorDescOnlyAsync($"Error while retrieving apples: { appleError }.")
                    .ConfigureAwait(false);
            }

            return apples;
        }
    }
}