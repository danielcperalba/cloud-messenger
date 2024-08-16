using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMessenger.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Bio { get; set; }
        public string Status { get; set; }
        public ICollection<Guild> Guilds { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
