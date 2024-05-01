using System;
using System.Threading.Tasks;

namespace GameService.Client.Sdk.Adapters.Repositories.Synchronise
{
    public interface ISynchroniseRepositories
    {
        public Task<DateTime> GetServerTime();
    }
}