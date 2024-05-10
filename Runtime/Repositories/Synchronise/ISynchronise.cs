using System;
using System.Threading.Tasks;

namespace GameService.Client.Sdk.Repositories.Synchronise
{
    public interface ISynchroniseRepositories
    {
        public Task<DateTime> GetServerTime();
    }
}