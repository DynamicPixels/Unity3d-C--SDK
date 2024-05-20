using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;

namespace DynamicPixels.GameService.Services.Storage.Repositories
{
    public interface IStorageRepositories
    {
        Task<FileMetadata> GetFileInfo(string fileName);
        Task Download(string fileName);
    }
}