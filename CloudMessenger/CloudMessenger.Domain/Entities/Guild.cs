using CloudMessenger.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMessenger.Domain.Entities
{
    public sealed class Guild : Entity
    {
        public string Name { get; private set; }

        public Guild(string name)
        {
            ValidateDomain(name);
        }
        public Guild(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<User> Users { get; set; }
        public ICollection<Channel> Channels { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Name = name;
        }

    }
}
