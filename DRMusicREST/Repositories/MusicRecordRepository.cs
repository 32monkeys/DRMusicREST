using DRMusicREST.Interfaces;
using DRMusicREST.Models;

namespace DRMusicREST.Repositories
{
    public class MusicRecordRepository : IRepository<MusicRecord>
    {

        private readonly List<MusicRecord> _musicRecords = new List<MusicRecord>()
        {
            new MusicRecord { Id = 1, Title = "Album 1", Artist = "Artist 1", Year = 2020, Duration = 60 },
            new MusicRecord { Id = 2, Title = "Album 2", Artist = "Artist 2", Year = 2021, Duration = 45 },
            new MusicRecord { Id = 3, Title = "Album 3", Artist = "Artist 3", Year = 2022, Duration = 50 }
        };
        public MusicRecord Add(MusicRecord obj)
        {
            throw new NotImplementedException();
        }

        public MusicRecord Delete(MusicRecord obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MusicRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public MusicRecord GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MusicRecord Update(int id, MusicRecord obj)
        {
            throw new NotImplementedException();
        }
    }
}
