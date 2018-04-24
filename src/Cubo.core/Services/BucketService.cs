using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cubo.Core.Repositories;
using Cubo.Core.Domain;

namespace Cubo.Core.Services
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _bucketRepository;
        public BucketService(IBucketRepository bucketRepository)
        {
            _bucketRepository = bucketRepository;
        }

        public async Task<BucketDTO> GetAsync(string name)
        {
            var bucket = await _bucketRepository.GetOrFailAsync(name);

            return new BucketDTO();
        }


        public async Task<IEnumerable<string>> GetNameAsync()
        => await _bucketRepository.GetNamesAsync();

        public async Task AddAsync(string name)
        {
            var bucket = await _bucketRepository.GetAsync(name);

            if (bucket != null)
            {
                throw new Exception($"Bucket: '{name}' already exists");
            }

            bucket = new Bucket(Guid.NewGuid(), name);
            await _bucketRepository.AddAsync(bucket);
        }

        public async Task RemoveAsync(string name)
        => await _bucketRepository.RemoveAsync(name);
    }
}