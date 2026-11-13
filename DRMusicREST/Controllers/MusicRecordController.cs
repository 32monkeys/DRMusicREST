using DRMusicREST.Interfaces;
using DRMusicREST.Models;
using DRMusicREST.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRMusicREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicRecordController : ControllerBase
    {
        private readonly IRepository<MusicRecord> _musicRecordRepository;

        public MusicRecordController(IRepository<MusicRecord> musicRecordDbRepo)
        {
            _musicRecordRepository = musicRecordDbRepo;
        }
        // GET: api/<MusicRecordController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
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
        [Authorize(Roles = "Admin,User")]
        public ActionResult<MusicRecord> Get(int id)
        {
            var musicRecord = _musicRecordRepository.GetById(id);
            if (musicRecord == null)
            {
                return NotFound("Music record not found.");
            }
            return Ok(musicRecord);
        }

        // POST api/<MusicRecordController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public ActionResult Post([FromBody] MusicRecord value)
        {
            try
            {
                _musicRecordRepository.Add(value);
                return Created($"api/musicrecord/{value.Id}", value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<MusicRecordController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public ActionResult<MusicRecord> Put(int id, [FromBody] MusicRecord value)
        {
            var updatedRecord = _musicRecordRepository.Update(id, value);
            if (updatedRecord == null)
            {
                return BadRequest("Failed to update music record.");
            }
            return Ok(updatedRecord);
        }

        // DELETE api/<MusicRecordController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public ActionResult<MusicRecord> Delete(int id)
        {
            return _musicRecordRepository.Delete(id);
        }
    }
}
