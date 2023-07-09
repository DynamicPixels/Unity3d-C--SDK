using System.Net.Http;
using System.Threading.Tasks;

namespace ports.utils
{
    public interface IWebRequest
    {
        Task<TY> SendRequest<T, TY>(HttpMethod method, string url, T bodyO);
    }
}