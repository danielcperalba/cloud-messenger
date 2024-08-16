using CloudMessenger.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMessenger.Domain.Entities
{
    public sealed class Channel : Entity
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Channel(string name, string type)
        {
            ValidateDomain(name, type);
        }

        public Channel(int id, string name, string type)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, type);
        }

        public void Update(string name, string type, int guildId)
        {
            ValidateDomain(name, type);
            GuildId = guildId;
        }

        private void ValidateDomain(string name, string type)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(type),
                "Invalid channel type. Please, define a type.");

            Name = name;
            Type = type;
        }


        public int GuildId { get; set; }
        public Guild Guild { get; set; }
        public ICollection<User> Members { get; set; }

        
        }
    }
}
