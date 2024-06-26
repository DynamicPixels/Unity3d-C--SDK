
using System.Threading.Tasks;
using models.outputs;
using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services.leaderboard;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.services.storage
{
    public interface IStorage
    {
       // private IStorageRepositories _repository;

        void Download();
        Task<FileMetadata> GetFileInfo();
        public Task<FileMetaForUpload> UploadAsync<TInput>(TInput param) where TInput : FileMetaForUpload;
        
    }
}