using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class LoginRepository : ILoginRepository
    {
        MyCMSContext db;
        public LoginRepository(MyCMSContext context)
        {
            this.db = context;
        }

        public IEnumerable<AdminLogin> GetAll()
        {
            return db.AdminLogins;
        }
        public AdminLogin GetAdminById(int id)
        {
            return db.AdminLogins.Find(id);
        }

        public bool InsertAdmin(AdminLogin admin)
        {
            try
            {
                db.AdminLogins.Add(admin);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateAdmin(AdminLogin admin)
        {
            try
            {
                db.Entry(admin).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool DeleteAdmin(AdminLogin admin)
        {
            try
            {
                db.Entry(admin).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteAdmin(int id)
        {
            try
            {
                var admin = GetAdminById(id);
                DeleteAdmin(admin);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool IsUserExists(string username, string password)
        {
            return db.AdminLogins.Any(u => u.UserName == username && u.Password == password);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}
