using System.Threading.Tasks;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Adapters.Services.Storage
{
    public interface IStorage
    {
       // private IStorageRepositories _repository;

        void Download();
        Task<FileMetadata> GetFileInfo();
        public Task<FileMetaForUpload> UploadAsync<TInput>(TInput param) where TInput : FileMetaForUpload;
        
    }
}