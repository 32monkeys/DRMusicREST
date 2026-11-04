using DRMusicREST.Repositories;
using Xunit;
using DRMusicREST.Models;
using DRMusicREST.Interfaces;



namespace DrMusicRESTTest
{
    public class UnitTest1
    {
        private readonly MusicRecordRepository _musicRecordsRepo;

        public UnitTest1()
        {
            _musicRecordsRepo = new MusicRecordRepository(includeSampleData: true);
            // for db test use dummy table
        }

        [Fact]
        public void GetAllMusicRecords_ShouldReturnListOfMusicRecords()
        {
            //Arrange
            var expected = new List<MusicRecord>
            {
                new MusicRecord { Id = 1, Title = "Album 1", Artist = "Artist 1", Year = 2020, Duration = 60 },
                new MusicRecord { Id = 2, Title = "Album 2", Artist = "Artist 2", Year = 2021, Duration = 45 },
                new MusicRecord { Id = 3, Title = "Album 3", Artist = "Artist 3", Year = 2022, Duration = 50 }
            };

            //Act
            var actual = _musicRecordsRepo.GetAll();

            //Assert
            Assert.IsType<List<MusicRecord>>(actual);
            Assert.Equal(expected.Count, actual.Count());
        }
    }
}
