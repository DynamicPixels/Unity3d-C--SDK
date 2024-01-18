using System.Threading.Tasks;
using adapters.repositories;
using models.outputs;
using adapters.repositories.storage;
using ports;
using ports.utils;
using System;
using UnityEngine;
namespace adapters.services.storage
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
            Debug.Log("input: "+param);
            var result = await this._repository.UploadFile(param);

            return result;
        }



        public Task<FileMetadata> GetFileInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}