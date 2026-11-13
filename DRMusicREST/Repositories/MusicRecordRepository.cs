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
                Add(new MusicRecord("Album 1", "Artist 1", 60, 2020));
                Add(new MusicRecord("Album 2", "Artist 2", 45, 2021));
                Add(new MusicRecord("Album 3", "Artist 3", 50, 2022));
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

        public MusicRecord Delete(int id)
        {

            MusicRecord ToBeDeleted = _musicRecords.FirstOrDefault(x => x.Id == id);
            if (ToBeDeleted != null)
            {
                _musicRecords.Remove(ToBeDeleted);
                return ToBeDeleted;
            }
            throw new ArgumentException($"No record found with Id {id}");
        }

        public IEnumerable<MusicRecord> GetAll()
        {
            return _musicRecords;
        }
        
        public MusicRecord GetById(int id)
        {
            return _musicRecords.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException($"No record found with Id {id}");
        }

        public MusicRecord Update(int id, MusicRecord obj)
        {
            MusicRecord existingRecord = _musicRecords.FirstOrDefault(x => x.Id == id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"No record found with Id {id}");
            }

            existingRecord.Title = obj.Title;
            existingRecord.Artist = obj.Artist;
            existingRecord.Year = obj.Year;
            existingRecord.Duration = obj.Duration;

            return obj;
        }
    }
}
