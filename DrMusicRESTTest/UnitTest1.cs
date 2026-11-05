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
            _musicRecordsRepo = new MusicRecordRepository(includeSampleData: false);
            // for db test use dummy table
        }

        [Fact]
        public void GetAllMusicRecords_ShouldReturnListOfMusicRecords()
        {
            //Arrange
            //var expected = new List<MusicRecord>
            //{
            //    new MusicRecord { Id = 1, Title = "Album 1", Artist = "Artist 1", Year = 2020, Duration = 60 },
            //    new MusicRecord { Id = 2, Title = "Album 2", Artist = "Artist 2", Year = 2021, Duration = 45 },
            //    new MusicRecord { Id = 3, Title = "Album 3", Artist = "Artist 3", Year = 2022, Duration = 50 }
            //};

            //Act
            var actual = _musicRecordsRepo.GetAll();


            //Assert
            Assert.IsType<List<MusicRecord>>(actual);
            //Assert.Equal(expected.Count, actual.Count());
        }

        [Fact]
        public void AddRecord_ValidInput()
        {
            // Arrange
            var expected = new List<MusicRecord>
            {
                new MusicRecord { Title = "Album 1", Artist = "Artist 1", Year = 2020, Duration = 60 },
                new MusicRecord { Title = "Album 2", Artist = "Artist 2", Year = 2021, Duration = 45 },
                new MusicRecord { Title = "Album 3", Artist = "Artist 3", Year = 2022, Duration = 50 }
            };

            // Act
            _musicRecordsRepo.Add(expected[0]);
            _musicRecordsRepo.Add(expected[1]);
            _musicRecordsRepo.Add(expected[2]);

            var actual = _musicRecordsRepo.GetAll();
            // Assert
            Assert.Equal(actual.Count(), expected.Count());
        }

        [Fact]
        public void AddRecord_InvalidInput_ShouldThrowException()
        {
            // Arrange
            var invalidRecord = new MusicRecord { Title = "", Artist = "Artist 1", Year = 2020, Duration = 60 };
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _musicRecordsRepo.Add(invalidRecord));
        }

        [Fact]
        public void DeleteRecord()
        {
            // arrange
            var expeted = new MusicRecord {Id= 0, Title = "Album 1", Artist = "Artist 1", Year = 2020, Duration = 60 };


            // act
            var actuel = _musicRecordsRepo.Delete(0);

            // assert
            Assert.Equal(expeted, actuel);


        }



    }

    
}
