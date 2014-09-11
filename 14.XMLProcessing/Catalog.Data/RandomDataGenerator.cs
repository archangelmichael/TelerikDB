namespace CatalogData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMOPQRSTUVWXYZabcdrfghijklmnopqrstuvwxyz";

        private const string Digits = "0123456789";
        
        private Random generator = new Random();

        public RandomDataGenerator()
        {
        }

        public int GenerateRandomNumber(int max)
        {
           return this.generator.Next(1, max);
        }

        public string GenerateName()
        {
            int length = this.generator.Next(5, 10);
            StringBuilder name = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                name.Append(Letters[this.generator.Next(0, Letters.Length - 1)]);
            }

            return name.ToString();
        }

        public int GenerateReleaseYear(int start, int end)
        {
            int years = end - start;
            int releaseYear = start + this.generator.Next(0, years);
            return releaseYear;
        }
        
        public IList<Song> GenerateSongs()
        {
            int count = this.generator.Next(0, 10);
            var listOfSongs = new List<Song>();
            for (int i = 0; i < count; i++)
            {
                listOfSongs.Add(new Song() { Title = this.GenerateName(), Duration = this.generator.Next(2, 10) });
            }

            return listOfSongs;
        }

        public ICollection<Album> GenerateAlbums(int count)
        {
            ICollection<Album> albums = new List<Album>();
            for (int i = 0; i < count; i++)
            {
                albums.Add(new Album()
                    {
                        Name = this.GenerateName(),
                        Artist = this.GenerateName(),
                        Year = this.GenerateReleaseYear(2007, DateTime.Now.Year),
                        Producer = this.GenerateName(),
                        Price = this.GenerateRandomNumber(100),
                        Songs = this.GenerateSongs()
                    });
            }

            return albums;
        }
    }
}
