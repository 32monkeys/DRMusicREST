using DRMusicREST.DBContext;
using DRMusicREST.Interfaces;
using DRMusicREST.Models;

namespace DRMusicREST.Repositories
{
    public class MusicRecordDbRepo : IRepository<MusicRecord>
    {
        private readonly MusicRecordDbContext _context;
        public MusicRecordDbRepo(MusicRecordDbContext context)
        {
            _context = context;
        }

        public MusicRecord Add(MusicRecord obj)
        {
            _context.MusicRecords.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public MusicRecord Delete(int id)
        {
            var obj = _context.MusicRecords.Find(id);
            if (obj != null)
            {
                _context.MusicRecords.Remove(obj);
                _context.SaveChanges();
            }
            return obj;
        }

        public IEnumerable<MusicRecord> GetAll()
        {
            return _context.MusicRecords.ToList();
        }

        public MusicRecord GetById(int id)
        {
            return _context.MusicRecords.Find(id);
        }

        public MusicRecord Update(int id, MusicRecord obj)
        {
            var existingObj = _context.MusicRecords.Find(id);
            if (existingObj != null)
            {
                _context.Entry(existingObj).CurrentValues.SetValues(obj);
                _context.SaveChanges();
            }
            return existingObj;
        }
    }
}
