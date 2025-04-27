using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_103022300158.Controllers
{
    [Route("api/mahasiswa")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa("Hafizryandin Haykal M", "103022300158"),
            new Mahasiswa("Muhammad Fathir Rizky Salam", "103022300009"),
            new Mahasiswa("Hafidz Naufal Pradana", "103022300163"),
            new Mahasiswa("Haidar Zahran Haryono", "103022330140"),
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(mahasiswaList);
        }

        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int id)
        {
            if (id < 0 || id >= mahasiswaList.Count)
                return NotFound();

            return Ok(mahasiswaList[id]);
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null)
                return BadRequest("Data mahasiswa tidak boleh kosong.");

            mahasiswaList.Add(newMahasiswa);

            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { id = mahasiswaList.Count - 1 }, newMahasiswa);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMahasiswa(int id)
        {
            if (id < 0 || id >= mahasiswaList.Count)
                return NotFound();

            mahasiswaList.RemoveAt(id);
            return NoContent();
        }
    }
}