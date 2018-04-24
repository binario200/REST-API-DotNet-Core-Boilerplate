using System.Collections.Generic;
using System.Threading.Tasks;
using Cubo.Core.Domain;

namespace Cubo.Core.Repositories
{
    public interface IBucketRepository
    {
        // CQS command and query separation
        Task<Bucket> GetAsync(string name);
        Task<IEnumerable<string>> GetNamesAsync();
        Task AddAsync(Bucket bucket);
        Task UpdateAsync(Bucket bucket);
        Task RemoveAsync(string name);        
    }
}