using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProjectManagementApp.DAL.Entities
{
    public class User: EntityBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<Membership> Teams { get; set; } = new List<Membership>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<UserLog> Logs { get; set; } = new List<UserLog>();

        private string password;
        public string Password
        {
            get => password;
            set => password = Encrypt(value);
        }

        protected string Encrypt(string data)
        {
            using (SHA512 shaM = new SHA512Managed())
            {
                var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(data));
                return System.Text.Encoding.UTF8.GetString(hash);
            }
        }
    }
}
