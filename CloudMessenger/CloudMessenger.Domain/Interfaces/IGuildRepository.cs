using CloudMessenger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMessenger.Domain.Interfaces
{
    public interface IGuildRepository
    {
        Task<IEnumerable<Guild>> GetGuilds();
        Task<Guild> GetById(int? id);
        Task<Guild> Create(Guild guild);
        Task<Guild> Update(Guild guild);
        Task<Guild> Remove(Guild guild);
    }
}
