using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestMvcApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace TestMvcApp.Controllers


{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private List<TestMvcApp.Models.ImageInfo> imageList = new List<TestMvcApp.Models.ImageInfo>
        {
            new TestMvcApp.Models.ImageInfo { id = 1,Ans = "B", Link = "/images/Q1(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 2,Ans = "A", Link = "/images/Q2(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 3,Ans = "C", Link = "/images/Q3(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 4,Ans = "A", Link = "/images/Q4(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 5,Ans = "B", Link = "/images/Q5(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 6,Ans = "B", Link = "/images/Q6(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 7,Ans = "A", Link = "/images/Q7(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 8,Ans = "C", Link = "/images/Q8(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 9,Ans = "A", Link = "/images/Q9(2019).png" },
            new TestMvcApp.Models.ImageInfo { id = 10,Ans = "B",Link = "/images/Q10(2019).png" }
        
        };
            private List<TestMvcApp.Models.SP1ImageInfo> sp1imageList = new List<TestMvcApp.Models.SP1ImageInfo>
        {
            new TestMvcApp.Models.SP1ImageInfo { id = 1,Ans = "B", Link = "/images/Q1SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 2,Ans = "A", Link = "/images/Q2SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 3,Ans = "C", Link = "/images/Q3SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 4,Ans = "A", Link = "/images/Q4SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 5,Ans = "B", Link = "/images/Q5SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 6,Ans = "B", Link = "/images/Q6SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 7,Ans = "A", Link = "/images/Q7SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 8,Ans = "C", Link = "/images/Q8SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 9,Ans = "A", Link = "/images/Q9SP1(2019).png" },
            new TestMvcApp.Models.SP1ImageInfo { id = 10,Ans = "B",Link = "/images/Q10SP1(2019).png" }
        
        };


        public IActionResult Index()
        {
            return View();
        }
        

        // [HttpPost]
public IActionResult Results(Dictionary<int, string> answers)
        {
            // Process the submitted answers and display results
            var correctAnswers = new Dictionary<int, string>
            {
                { 1, "A" },
                { 2, "B" },
                { 3, "B" },
                { 4, "D" },
                { 5, "A" },
                { 6, "A" },
                { 7, "B" },
                { 8, "C" },
                { 9, "D" },
                { 10, "A" }
            };

            var totalQuestions = correctAnswers.Count;
            var correctCount = answers.Count(kv => correctAnswers.ContainsKey(kv.Key) && correctAnswers[kv.Key] == kv.Value);

            var viewModel = new ResultsViewModel
            {
                CorrectCount = correctCount,
                TotalQuestions = totalQuestions,
                Answers = answers,
                CorrectAnswers = correctAnswers
            };

            return View(viewModel); // Return a view to display the results
        }


        public IActionResult RandomImage()
{
    using (var image = GenerateRandomImage())
    {
        using (var memoryStream = new MemoryStream())
        {
            image.SaveAsPng(memoryStream); // Save the image as PNG format
            memoryStream.Seek(0, SeekOrigin.Begin);

            return File(memoryStream.ToArray(), "image/png");
        }
    }
}

        

        private Image<Rgba32> GenerateRandomImage()
        {
            int width = 100;
            int height = 50;

            var image = new Image<Rgba32>(width, height);

            var random = new Random();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pixelColor = new Rgba32(
                        (byte)random.Next(256),   // Red
                        (byte)random.Next(256),   // Green
                        (byte)random.Next(256),   // Blue
                        255                       // Alpha (fully opaque)
                    );

                    image[x, y] = pixelColor;
                }
            }

            return image;
        }

        public IActionResult Privacy()
        {
            return View();
        }
          public IActionResult SP2Question()
        {
            return View(imageList);
        }
         public IActionResult SP1Question()
        {
            return View(sp1imageList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
