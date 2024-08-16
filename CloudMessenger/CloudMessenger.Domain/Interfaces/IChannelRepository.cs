using CloudMessenger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMessenger.Domain.Interfaces
{
    public interface IChannelRepository
    {
        Task<IEnumerable<Channel>> GetGuildsAsync();
        Task<Channel> GetById(int? id);
        Task<Channel> Create(Channel channelId);
        Task<Channel> Update(Channel channelId);
        Task<Channel> Remove(Channel channelId);
    }
}
