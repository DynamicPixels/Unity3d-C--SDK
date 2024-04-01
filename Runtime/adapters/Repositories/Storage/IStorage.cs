using System.Threading.Tasks;
using models.outputs;

namespace adapters.repositories.storage
{
    public interface IStorageRepositories
    {
        Task<FileMetadata> GetFileInfo(string fileName);
        Task Download(string fileName);
    }
}