using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Storage;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Adapters.Services.Storage
{
    public class StorageService: IStorage
    {
        private StorageRepository _repository;

        public StorageService()
        {
            _repository = new StorageRepository();
        }


        public void Download()
        {
            throw new System.NotImplementedException();
        }

        public async Task<FileMetaForUpload> UploadAsync<TInput>(TInput param) where TInput : FileMetaForUpload
        {
            var result = await this._repository.UploadFile(param);

            return result;
        }



        public Task<FileMetadata> GetFileInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}