using System.Collections.Generic;
using System.Threading.Tasks;
using Project.API.Models;

namespace Project.API.Data.IRepository
{
    public interface IAccountRepository
    {
         void Add<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         Task<bool> SaveAll();
         Task<IEnumerable<Account>> GetAccounts();
         Task<Account> GetAccount(int id);
         Task<IEnumerable<Music_type>> GetMusicType();
         Task<Music_type> GetMusicType(int id);
         Task<Music_type_account> AccountMusic(int userid, int musicid);
    }
}