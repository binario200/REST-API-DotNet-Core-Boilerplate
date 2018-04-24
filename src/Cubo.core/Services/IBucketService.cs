using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cubo.Core.Services
{
    public interface IBucketService
    {
        Task<BucketDTO> GetAsync(string name);
        Task<IEnumerable<string>> GetNameAsync();
        Task AddAsync(string name);
        Task RemoveAsync(string name);
    }
}