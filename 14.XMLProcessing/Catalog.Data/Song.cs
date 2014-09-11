namespace CatalogData
{
    public class Song
    {
        public string Title { get; set; }

        public double Duration { get; set; }

        public override string ToString()
        {
            return string.Format(" Title: {0} Duration: {1} minutes ", this.Title, this.Duration);
        }
    }
}
