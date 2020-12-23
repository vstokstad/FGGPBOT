// FGGPBOTPictureService.cs2020Vilhelm Stokstad

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace fggpbot {
    public class PictureService {
        private readonly HttpClient _http;

        public PictureService(HttpClient http){
            _http = http;
        }

        public async Task<Stream> GetCatPictureAsync(){
            HttpResponseMessage? resp = await _http.GetAsync("https://cataas.com/cat");
            return await resp.Content.ReadAsStreamAsync();
        }
    }
}