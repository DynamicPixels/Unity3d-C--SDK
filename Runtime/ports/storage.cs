
using System.Threading.Tasks;
using models.outputs;

namespace ports
{
    public interface IStorage
    {
        void Download();
        Task<FileMetadata> GetFileInfo();
    }
}