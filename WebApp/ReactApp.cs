using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Manifest = System.Collections.Generic.Dictionary<string, string>;

namespace WebApp
{
    public static class ReactApp
    {
        // TODO: Read from web.config?
        private const string BuildFolder = "my-react-app/build";

        // In DEBUG, file is read every request to accomodate fresh JS builds.
        // In RELEASE, file is read only once for performance.
#if DEBUG
        public static Manifest AssetManifest => ReadAssetManifest();
#else
        public static readonly Manifest AssetManifest = ReadAssetManifest();
#endif

        private static Manifest ReadAssetManifest()
        {
            var request = HttpContext.Current.Request;

            var manifestPath = Path.Combine(
                request.PhysicalApplicationPath,
                BuildFolder,
                "asset-manifest.json"
            );

            var assetRoot = Path.Combine(
                request.ApplicationPath,
                BuildFolder
            );

            var json = File.ReadAllText(manifestPath);
            var manifest = JsonConvert.DeserializeObject<Manifest>(json);

            return manifest.ToDictionary(
                pair => pair.Key,
                pair =>
                {
                    var assetPath = Path.Combine(assetRoot, pair.Value);
                    return assetPath.Replace("\\", "/");
                }
            );
        }
    }
}