using System.Threading.Tasks;
using models.outputs;
using ports;

namespace adapters.repositories.storage
{
    public class StorageRepository: IStorageRepositories
    {
        public Task<FileMetadata> GetFileInfo(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public Task Download(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}