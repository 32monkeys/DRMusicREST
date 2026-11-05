using DRMusicREST.Interfaces;
using DRMusicREST.Models;

namespace DRMusicREST.Repositories
{
    public class MusicRecordRepository : IRepository<MusicRecord>
    {
        private static int _nextId;
        private readonly List<MusicRecord> _musicRecords;
        public MusicRecordRepository(bool includeSampleData = true)
        {
            _nextId = 0;
            _musicRecords = new List<MusicRecord>();
            if (includeSampleData)
            {
                Add(new MusicRecord("Album 1", "Artist 1", 2020, 60));
                Add(new MusicRecord("Album 2", "Artist 2", 2021, 45));
                Add(new MusicRecord("Album 3", "Artist 3", 2022, 50));
            }
        }
        public MusicRecord Add(MusicRecord obj)
        {
            if (obj is null)
            {
                return null;
            }
            obj.Id = _nextId++;
            _musicRecords.Add(obj);
            return obj;
        }

        public MusicRecord Delete(MusicRecord obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MusicRecord> GetAll()
        {
            return _musicRecords;
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
