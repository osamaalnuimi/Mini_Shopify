namespace Mini_Shopify.Entities.Models
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
