using adapters.repositories;
using models.outputs;
using adapters.repositories.storage;
using ports;
using ports.utils;

namespace adapters.services.storage
{
    public class StorageService: IStorage
    {
        private StorageRepository _repository;

        public StorageService()
        {
        }


        public void Download()
        {
            throw new System.NotImplementedException();
        }

        public void Upload()
        {
            throw new System.NotImplementedException();
        }

        public FileMetadata GetFileInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}