using System.Threading.Tasks;
using models.inputs;
using System;
namespace ports
{
    public interface ISynchronise
    {
        public Task<DateTime> GetServerTime();
    }
}