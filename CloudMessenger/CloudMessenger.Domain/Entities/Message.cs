using CloudMessenger.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMessenger.Domain.Entities
{
    public class Message : Entity
    {
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }

        public Message(string content)
        {
            ValidateDomain(content);
        }

        public Message(int id, string content)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
        }

        public void Update(string content, int channelId)
        {
            ValidateDomain(content);
            ChannelId = channelId;
        }

        private void ValidateDomain(string content)
        {
            DomainExceptionValidation.When(name.Length > 200,
                "Invalid content, content too big");

            Content = content;
        }


        public int ChannelId { get; set; }
        public Channel Channel { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
