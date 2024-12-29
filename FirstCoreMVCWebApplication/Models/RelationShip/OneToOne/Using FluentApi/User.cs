namespace FirstCoreMVCWebApplication.Models.RelationShip.OneToOne.Using_FluentApi
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Passport Passport { get; set; }  // Navigation property
    }
}
