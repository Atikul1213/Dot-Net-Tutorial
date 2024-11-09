namespace FirstCoreMVCWebApplication.Models.EFCoreRelationShip
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public ICollection<BookPublisher> BookPublisher { get; set; }
    }
}
