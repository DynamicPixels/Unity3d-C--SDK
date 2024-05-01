using System;
using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Repositories.Synchronise;

namespace GameService.Client.Sdk.Adapters.Services.Synchronise
{
    public class SynchroniseService : ISynchronise
    {
        private ISynchroniseRepositories _repository;

        public SynchroniseService()
        {
            _repository = new SynchroniseRepository();
        }

        public Task<DateTime> GetServerTime()
        {
            return this._repository.GetServerTime();
        }
    }
}