using LaunchPadAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaunchPadAPI.Services
{
    public interface ILaunchPadService
    {
        Task<IEnumerable<LaunchPad>> GetLaunchPads(string baseUri, int limit, int offset);
    }
}
