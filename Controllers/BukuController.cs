using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using tesKPL.Models;

namespace tesKPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : ControllerBase
    {

        public string filePath = "Data/books.json";

        public List<Buku> ReadJson()
        {
           if (!System.IO.File.Exists(filePath))
            {
                return new List<Buku>();
            }

            var json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Buku>>(json) ?? new List<Buku>();
        }

        public void WriteJson(List<Buku> buku)
        {
            var json = JsonSerializer.Serialize(buku, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
        }

        [HttpGet]
        public ActionResult<List<Buku>> GetBuku()
        {
            return ReadJson();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Buku>> GetBukuById(int id, Buku buku)
        {
            if (id < 0)
            {
                return NotFound("pastikan id benar");
            }

            return ReadJson(buku[id]);
        }

        [HttpPost]
        public ActionResult<List<Buku>> TambahBuku(Buku buku)
        {
            var books = ReadJson();
            books.Add(buku);
            WriteJson(books);

            return ReadJson();
        }

        [HttpPut("{id}")]


        [HttpDelete("{id}")]
        public ActionResult<List<Buku>> HapusBuku(int id)
        {
            if ()
            var books = ReadJson();
            books.RemoveAt(id);
            return ReadJson();
        }
    }
}
