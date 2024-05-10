using System;
using System.Threading.Tasks;

namespace GameService.Client.Sdk.Services.Synchronise
{
    public interface ISynchronise
    {
        public Task<DateTime> GetServerTime();
    }
}