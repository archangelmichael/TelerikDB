namespace CatalogData
{
    using System.Collections.Generic;

    public class Album
    {
        private string albumData = 
            "********* Album Name: {0} \n By: {1} Release Date: {2} \n Producer: {3} \n Price: {4} USD \n Songs: \n {5} \n ***********";

        public string Name { get; set; }

        public string Artist { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public ICollection<Song> Songs { get; set; }

        public override string ToString()
        {
            return string.Format(
                this.albumData,
                this.Name,
                this.Artist,
                this.Year,
                this.Producer,
                this.Price,
                string.Join(" \n ", this.Songs));
        }
    }
}
