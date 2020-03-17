using System.Threading.Tasks;
using Lemon.UserCenter.Domain;

namespace Lemon.UserCenter.Application
{
    public interface IUserService
    {
         Task<UserData> Create(UserData data);
    }
}