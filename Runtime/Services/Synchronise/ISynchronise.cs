using System;
using System.Threading.Tasks;

namespace DynamicPixels.GameService.Services.Synchronise
{
    public interface ISynchronise
    {
        public Task<DateTime> GetServerTime();
    }
}