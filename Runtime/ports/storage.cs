
using models.outputs;

namespace ports
{
    public interface IStorage
    {
        void Download();
        void Upload();
        FileMetadata GetFileInfo();
    }
}