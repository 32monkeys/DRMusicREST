using DRMusicREST.Interfaces;
using DRMusicREST.Models;
using DRMusicREST.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DRMusicREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordController : ControllerBase
    {
        private readonly IRepository<MusicRecord> _musicRecordRepository;

        public MusicRecordController(IRepository<MusicRecord> musicRecordRepository)
        {
            _musicRecordRepository = musicRecordRepository;
        }
        // GET: api/<MusicRecordController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<MusicRecord>> Get()
        {
            IEnumerable<MusicRecord> musicRecords = _musicRecordRepository.GetAll();
            if (musicRecords == null)
            {
                return NotFound("No music records found.");
            }
            return Ok(musicRecords);
        }

        // GET api/<MusicRecordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicRecordController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicRecordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicRecordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
