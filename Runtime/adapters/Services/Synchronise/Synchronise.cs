using System.Threading.Tasks;
using adapters.repositories.synchronise;
using System;

namespace adapters.services.synchronise
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