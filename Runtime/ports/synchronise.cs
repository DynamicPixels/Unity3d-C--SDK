using System.Threading.Tasks;
using models.inputs;

namespace ports
{
    public interface ISynchronise
    {
        public Task<long> GetServerTime();
    }
}