using ExampleCompanyApp.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace TeknoMarketim.MvcUI.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;



        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ApiGateway");

            // API'deki endpoint ismin neyse onu yaz (genelde "products")
            var response = await client.GetAsync("products");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                // API'den gelen veriyi senin CustomResponseDto kalıbına döküyoruz
                var result = JsonConvert.DeserializeObject<CustomReponseDto<List<ProductDto>>>(jsonData);

                return View(result.Data);
            }

            return View(new List<ProductDto>());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var client = _httpClientFactory.CreateClient("ApiGateway");

            // Ürünü JSON formatına çeviriyoruz
            var jsonData = JsonConvert.SerializeObject(productDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            // API'ye POST isteği atıyoruz
            var response = await client.PostAsync("products", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Başarılıysa listeye geri dön
            }

            return View(productDto); // Hata varsa sayfada kal
        }

    }
}


