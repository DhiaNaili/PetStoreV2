namespace PetStore.Domain
{
    public class Pet

    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoriesId { get; set; }
        public Category Categories { get; set; }
        public string Status { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
