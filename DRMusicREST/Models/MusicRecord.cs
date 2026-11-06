using System.ComponentModel.DataAnnotations;

namespace DRMusicREST.Models
{
    public class MusicRecord
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; } // Duration in seconds
        public int Year { get; set; }

        public MusicRecord() { }

        public MusicRecord(string title, string artist, int duration, int year)
        {
            Id = 0;
            Title = title;
            Artist = artist;
            Duration = duration;
            Year = year;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Artist: {Artist}, Duration: {Duration} seconds, Year: {Year}";
        }
    }
}
