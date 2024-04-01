using System;
using System.Threading.Tasks;

namespace adapters.repositories.synchronise
{
    public interface ISynchroniseRepositories
    {
        public Task<DateTime> GetServerTime();
    }
}