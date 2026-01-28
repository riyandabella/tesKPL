using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using tesKPL.Models;

namespace BukuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BukuController : ControllerBase
    {
        private readonly string filePath = "Data/books.json";

        private List<Buku> ReadBooks()
        {
            if (!System.IO.File.Exists(filePath))
                return new List<Buku>();

            var json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Buku>>(json)
                   ?? new List<Buku>();
        }

        private void WriteBooks(List<Buku> books)
        {
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            System.IO.File.WriteAllText(filePath, json);
        }

        [HttpGet]
        public ActionResult<List<Buku>> GetAll()
        {
            return Ok(ReadBooks());
        }

        [HttpGet("{id}")]
        public ActionResult<Buku> GetBukuById(int id, Buku buku)
        {
            var books = ReadBooks();

            if (id < 0 || id > books.Count)
            {
                return NotFound();
            }

            var data = books.FirstOrDefault(m => m.judul == buku.judul);

            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpPut("{id}")]
        public ActionResult<Buku> Put(int id, Buku books)
        {
            var buku = ReadBooks();

            if (id < 0 || id >= buku.Count)
                return NotFound("Movie tidak ditemukan");

            buku[id] = books;
            WriteBooks(buku);

            return Ok(buku);
        }

        [HttpPost]
        public ActionResult Add(Buku books)
        {
            if (books == null)
                return BadRequest("Data movie tidak valid");

            var buku = ReadBooks();
            buku.Add(books);
            WriteBooks(buku);

            return Ok("Movie berhasil ditambahkan");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var buku = ReadBooks();

            if (id < 0 || id >= buku.Count)
                return NotFound("Movie tidak ditemukan");

            buku.RemoveAt(id);
            WriteBooks(buku);

            return Ok("Movie berhasil dihapus");
        }

    }
}