using System.Threading.Tasks;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Adapters.Repositories.Storage
{
    public interface IStorageRepositories
    {
        Task<FileMetadata> GetFileInfo(string fileName);
        Task Download(string fileName);
    }
}