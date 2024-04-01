using System.Threading.Tasks;
using models.inputs;
using System;

namespace adapters.services.synchronise
{
    public interface ISynchronise
    {
        public Task<DateTime> GetServerTime();
    }
}