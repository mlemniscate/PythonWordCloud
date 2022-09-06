using Microsoft.AspNetCore.Mvc;
using RunPythonScriptFromCs;

namespace PythonWordcloudAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordCloudController : ControllerBase
    {

        private readonly ILogger<WordCloudController> logger;
        private readonly WordCloudGenerator wordCloudGenerator;

        public WordCloudController(ILogger<WordCloudController> logger,
            WordCloudGenerator wordCloudGenerator
            )
        {
            this.logger = logger;
            this.wordCloudGenerator = wordCloudGenerator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get(string text)
        {
            wordCloudGenerator.GenerateImage(text); 
            Byte[] b = System.IO.File.ReadAllBytes(@"wwwroot/image/persian-example.png");         
            return File(b, "image/jpeg");
        }
    }
}