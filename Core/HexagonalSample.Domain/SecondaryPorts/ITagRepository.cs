using HexagonalSample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexagonalSample.Domain.SecondaryPorts
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int id);
        Task CreateAsync(Tag tag);
        Task UpdateAsync(Tag tag);
        Task DeleteAsync(Tag tag);
    }
}
