using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Accounts
    {
        private static DAO_Accounts instance;

        public static DAO_Accounts Instance
        {
            get { if (instance == null) instance = new DAO_Accounts(); return instance; }
            private set
            {
                instance = value;

            }
        }
        public bool loginAccount(string username,string password)
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                if (db.Accounts.FirstOrDefault(u=>u.Username== username) == null)
                {
                    return false;
                }
                return db.Accounts.FirstOrDefault(u=>u.Password== password).Password== password;    
            }
        }
  
        public bool addAccount(string username,string password,string DisplayName =null)
        {
            using(CafeManagementEntities db = new CafeManagementEntities())
            {
                    if (db.Accounts.FirstOrDefault(u => u.Username == username).Username == username)
                    {
                        throw new Exception("The username is already used.");
                    }
                    var account = new Account
                    {
                        Username = username,
                        Password = password,
                        DisplayName = DisplayName
                    };
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return true;
            }
        }
        public bool removeAccount(string username)
        {
            using(var db = new CafeManagementEntities())
            {
                if (db.Accounts.FirstOrDefault(u => u.Username == username) != null)
                {
                    db.Accounts.Remove(db.Accounts.FirstOrDefault(u => u.Username == username));
                    db.SaveChanges();
                    return true;
                }
                else throw new Exception("Username not found");
            }
        }
        public dynamic loadAccounts()
        {
            using(CafeManagementEntities db= new CafeManagementEntities())
            {
                return db.Accounts.Select(p => new
                {
                    p.Username,
                    p.AccountType.Type
                }).ToList() ;
            }
        }
    }
}
