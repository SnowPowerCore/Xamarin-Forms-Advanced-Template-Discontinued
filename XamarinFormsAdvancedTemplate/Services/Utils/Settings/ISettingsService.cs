using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsAdvancedTemplate.Models;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Settings
{
    public interface ISettingsService
    {
        AppSettings Settings { get; }

        bool ContainsKey(string key);

        T GetValueOrDefault<T>(string key, T defaultValue = default, bool deserialize = false);

        List<T> GetValuesOrDefaults<T>(string[] keys, T defaultValue = default, bool deserialize = false);

        T GetApplicationResourceOrDefault<T>(string key, T defaultValue = default);

        Task AddOrUpdateValueAsync<T>(string key, T value, bool serialize = false);

        Task AddOrUpdateValuesAsync<T>(Dictionary<string, T> keyValues, bool serialize = false);

        Task RemoveValueAsync(string key);

        Task RemoveValuesAsync(string[] keys);
    }
}