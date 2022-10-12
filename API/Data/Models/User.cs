using doxygen_documentation_example.Validators;
using FluentValidation.Results;

namespace doxygen_documentation_example.Data.Models
{
    /// <summary>
    /// Base User class
    /// Used as a model for the objects of type User
    /// </summary>
    public class User : IAggregateRoot
    {
        //public User()
        //{
        //    IsValid();
        //}
        /// <summary>
        /// The ID of the User
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The actual Name of the User
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The actual e-mail of the User
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The personal web page of the User
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// The amount of followers of the User
        /// </summary>
        public long Followers { get; set; }
        /// <summary>
        /// The address of the User
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// A short description of the User
        /// </summary>
        public string Bio { get; set; }

        public User() { }

        public User(string name, string email, string webSite, long followers, string area, string bio)
        {
            Id = new Guid().ToString();
            Name = name;
            Email = email;
            WebSite = webSite;
            Followers = followers;
            Area = area;
            Bio = bio;
        }

        //public ValidationResult IsValid()
        //{
        //    ValidationResult result = new UserValidator().Validate(this);
        //    return result;
        //}
    }
}
