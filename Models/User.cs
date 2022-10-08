namespace doxygen_documentation_example.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public long Followers { get; set; }
        public string Area { get; set; }
        public string Bio { get; set; }
    }
}
