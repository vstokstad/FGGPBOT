// FGGPBOTPictureService.cs2020Vilhelm Stokstad

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace app {
    public static class  PictureService {
        private static readonly HttpClient _http = new HttpClient();
        

        public static async Task<Stream> GetCatPictureAsync(){
            HttpResponseMessage? resp = await _http.GetAsync("https://cataas.com/cat");
            return await resp.Content.ReadAsStreamAsync();
        }
    }
}