using Microsoft.AspNetCore.Mvc;
using tpmodul9_2211104011.Models;
using System.Collections.Generic;
using tpmodul9_2211104011.Models;

namespace MahasiswaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Althafia", Nim = "2211104011" },
            new Mahasiswa { Nama = "maria", Nim = "2211104008" },
            new Mahasiswa { Nama = "lintang", Nim = "2211104009" }
        };

        // GET /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return Ok(mahasiswaList);
        }

        // GET /api/mahasiswa/{index}
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetByIndex(int id)
        {
            if (id < 0 || id >= mahasiswaList.Count)
                return NotFound("Mahasiswa tidak ditemukan.");

            return Ok(mahasiswaList[id]);
        }

        // POST /api/mahasiswa
        [HttpPost]
        public ActionResult Add([FromBody] Mahasiswa newMahasiswa)
        {
            mahasiswaList.Add(newMahasiswa);
            return Ok("Mahasiswa berhasil ditambahkan.");
        }

        // DELETE /api/mahasiswa/{index}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= mahasiswaList.Count)
                return NotFound("Mahasiswa tidak ditemukan.");

            mahasiswaList.RemoveAt(id);
            return Ok("Mahasiswa berhasil dihapus.");
        }
    }
}