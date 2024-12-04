using System;
using System.Threading.Tasks;

namespace DynamicPixels.GameService.Services.Synchronise.Repositories
{
    public interface ISynchroniseRepositories
    {
        public Task<DateTime> GetServerTime();
    }
}