using System.Threading.Tasks;
using FriendOrganizer.Model;
using System;

namespace FriendOrganizer.DataAccess
{
    public interface IAPIClient
    {
        Task<Weather> RunAsync(DateTime dateTime);
    }
}