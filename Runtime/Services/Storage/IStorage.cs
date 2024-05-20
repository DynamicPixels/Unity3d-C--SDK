using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;

namespace DynamicPixels.GameService.Services.Storage
{
    public interface IStorage
    {
        // private IStorageRepositories _repository;

        void Download();
        Task<FileMetadata> GetFileInfo();
        public Task<FileMetaForUpload> UploadAsync<TInput>(TInput param) where TInput : FileMetaForUpload;

    }
}