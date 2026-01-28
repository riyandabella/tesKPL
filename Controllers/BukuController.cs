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

        private readonly string filePath = "Data/books.json";

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
        public ActionResult<Buku> GetBukuById(int idBuku, Buku buku)
        {
            var books = ReadJson();

            if (idBuku < 0 || idBuku > books.Count)
            {
                return NotFound();
            }

            var data = books.FirstOrDefault(m => m.id == idBuku);

            if (data == null)
            {
                return NotFound();
            }
            return data;
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
        public ActionResult<List<Buku>> EditBuku(int id, Buku buku)
        {
            var books = ReadJson();

            if (id < 0 || id > books.Count)
            {
                return NotFound();
            }

            books[id] = buku;
            WriteJson(books);

            return ReadJson();
        }


        [HttpDelete("{id}")]
        public ActionResult<List<Buku>> HapusBuku(int id)
        {
            var books = ReadJson();

            if (id < 0 || id > books.Count)
            {
                return NotFound();
            }

            books.RemoveAt(id);
            return ReadJson();
        }
    }
}
