namespace CatalogData
{
    using System.Collections.Generic;

    public class Catalog
    {
        public ICollection<Album> Albums { get; set; }

        public override string ToString()
        {
            return "Catalog \n " + string.Join("\n", this.Albums);
        }
    }
}
