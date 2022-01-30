using System.IO;
using System.Reflection;

namespace XamarinFormsAdvancedTemplate.Extensions
{
    public static class AssetExtensions
    {
        private static readonly Assembly _mainAssembly;

        static AssetExtensions()
        {
            _mainAssembly = Assembly.GetAssembly(typeof(App));
        }

        public static string GetAsset(this string assetPath) =>
            $"{ _mainAssembly?.GetName().Name }.Assets.{ assetPath }";

        /// <summary>
        /// Returns embedded resource as a stream.
        /// </summary>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="useAssetsFolder">Pass true if you want to use relative paths from Assets folder,
        /// else pass false. Default is true.</param>
        /// <returns></returns>
        public static Stream GetStreamFromResource(this string resourcePath,
            bool useAssetsFolder = true) =>
                _mainAssembly.GetManifestResourceStream(
                    useAssetsFolder ? resourcePath.GetAsset() : resourcePath);

        /// <summary>
        /// Reads string from embedded resource.
        /// </summary>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="useAssetsFolder">Pass true if you want to use relative paths from Assets folder,
        /// else pass false. Default is true.</param>
        /// <returns></returns>
        public static string ReadTextFromResource(this string resourcePath,
            bool useAssetsFolder = true)
        {
            var stream = resourcePath.GetStreamFromResource(useAssetsFolder);
            using var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}