using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsAdvancedTemplate.Models;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Settings
{
    public class SettingsService : ISettingsService
    {
        public AppSettings Settings { get; } = new AppSettings();

        public SettingsService(IConfiguration configuration)
        {
            configuration.Bind(Settings);
        }

        public bool ContainsKey(string key) =>
            Xamarin.Forms.Application.Current.Properties.ContainsKey(key);

        public Task AddOrUpdateValueAsync<T>(string key, T value, bool serialize = false)
        {
            if (serialize)
                Xamarin.Forms.Application.Current.Properties[key] = JsonConvert.SerializeObject(value);
            else Xamarin.Forms.Application.Current.Properties[key] = value;

            try
            {
                return Xamarin.Forms.Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to save: " + key, " Message: " + ex.Message);
                return Task.CompletedTask;
            }
        }

        public Task AddOrUpdateValuesAsync<T>(Dictionary<string, T> keyValues, bool serialize = false)
        {
            if (keyValues == null) return Task.CompletedTask;

            foreach (var item in keyValues)
            {
                var key = item.Key;
                var value = item.Value;

                if (serialize)
                    Xamarin.Forms.Application.Current.Properties[key] = JsonConvert.SerializeObject(value);
                else Xamarin.Forms.Application.Current.Properties[key] = value;
            }

            try
            {
                return Xamarin.Forms.Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Unable to save or update values within this dict" + keyValues,
                    " Message: " + ex.Message);
                return Task.CompletedTask;
            }
        }

        public T GetValueOrDefault<T>(string key, T defaultValue = default, bool deserialize = false)
        {
            T value = defaultValue;
            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(key))
            {
                var data = Xamarin.Forms.Application.Current.Properties[key];
                if (deserialize) value = JsonConvert.DeserializeObject<T>((string)data);
                else value = (T)data;
            }
            return value;
        }

        public T GetApplicationResourceOrDefault<T>(string key, T defaultValue = default)
        {
            T value = defaultValue;
            if (Xamarin.Forms.Application.Current.Resources.ContainsKey(key))
                value = (T)Xamarin.Forms.Application.Current.Resources[key];
            return null != value ? value : defaultValue;
        }

        public List<T> GetValuesOrDefaults<T>(string[] keys, T defaultValue = default, bool deserialize = false)
        {
            var list = new List<T>();
            for (var i = 0; i < keys.Length; i++)
                list.Add(GetValueOrDefault(keys[i], defaultValue, deserialize));
            return list;
        }

        public Task RemoveValueAsync(string key)
        {
            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(key))
            {
                Xamarin.Forms.Application.Current.Properties.Remove(key);

                try
                {
                    return Xamarin.Forms.Application.Current.SavePropertiesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to save: " + key, " Message: " + ex.Message);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }

        public Task RemoveValuesAsync(string[] keys)
        {
            if (keys == null) return Task.CompletedTask;

            foreach (var item in keys)
            {
                if (Xamarin.Forms.Application.Current.Properties.ContainsKey(item))
                    Xamarin.Forms.Application.Current.Properties.Remove(item);
            }

            try
            {
                return Xamarin.Forms.Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Unable to save or update values within this list " + keys,
                    " Message: " + ex.Message);
                return Task.CompletedTask;
            }
        }
    }
}