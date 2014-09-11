namespace CatalogData
{
    public class CatalogGenerator
    {
        private const int AlbumsPerCollectionCount = 10;

        private static RandomDataGenerator generator;

        public CatalogGenerator(RandomDataGenerator dataGenerator)
        {
            generator = dataGenerator;
        }

        public Catalog CreateCatalog()
        {
            return new Catalog()
            {
                Albums = generator.GenerateAlbums(AlbumsPerCollectionCount)
            };
        }
    }
}
