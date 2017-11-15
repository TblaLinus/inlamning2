using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.DataAccess
{
    public interface IAPIClient
    {
        Task<Weather> RunAsync();
    }
}