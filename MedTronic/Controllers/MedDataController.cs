using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedTronic.Models;
using MedTronic.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MedTronic.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class MedDataController : Controller
    {
        GenericRepository repository;
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public MedDataController(GenericRepository gr)
        {
            this.repository = gr;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [Route("api/MedData/GetTSList")]
        public IEnumerable<TeacherStudentLinkModel> GetTeacherStudents()
        {
            return repository.getTeacherStudents();
        }

        [Route("api/MedData/GetStocksList")]
        public IEnumerable<StockPriceModel> GetStocksList()
        {
            return repository.getStocks();
        }


        [Route("api/TeacherList/PutTeacher")]
        [HttpPost]
        public ActionResult<IEnumerable<TeacherModel>> PutTeacher([FromBody] TeacherModel tmi)
        {
            return repository.PutTeacher(tmi);
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
