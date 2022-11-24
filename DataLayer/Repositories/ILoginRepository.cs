using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILoginRepository:IDisposable
    {
        IEnumerable<AdminLogin> GetAll();
        AdminLogin GetAdminById(int id);
        bool InsertAdmin(AdminLogin admin);
        bool UpdateAdmin(AdminLogin admin);
        bool DeleteAdmin(AdminLogin admin);
        bool DeleteAdmin(int id);
        bool IsUserExists(string username, string password);
        void Save();
    }
}
