using System;
using System.Threading.Tasks;
using GameService.Client.Sdk.Repositories.Synchronise;

namespace GameService.Client.Sdk.Services.Synchronise
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
            return _repository.GetServerTime();
        }
    }
}