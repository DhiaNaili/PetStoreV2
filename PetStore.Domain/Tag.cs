namespace PetStore.Domain
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; } 

    }
}
