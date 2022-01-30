using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using XamarinFormsAdvancedTemplate.Extensions;
using XamarinFormsAdvancedTemplate.Models;

namespace XamarinFormsAdvancedTemplate.Services.Apple
{
    public class AppleService : IAppleService
    {
        public readonly string _appleSourcePath = string.Empty;

        public AppleService(IConfiguration configuration)
        {
            var appleSource = configuration.GetSection("AppleSource");
            _appleSourcePath =
                $"{ Assembly.GetAssembly(typeof(App)).GetName().Name }."+
                $"{ appleSource["FolderPath"] }."+
                $"{ appleSource["FileName"] }";
        }

        public Task<DataResult<List<Models.Apple>>> GetApplesAsync()
        {
            var sourceData = _appleSourcePath.ReadTextFromResource(false);

            if (string.IsNullOrEmpty(sourceData))
            {
                return Task.FromResult(new DataResult<List<Models.Apple>>(dataError: "No source for apples"));
            }

            var apples = JsonConvert.DeserializeObject<List<Models.Apple>>(sourceData);
            return Task.FromResult(new DataResult<List<Models.Apple>>(apples, apples.Count));
        }
    }
}