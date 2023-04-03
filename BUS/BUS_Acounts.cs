using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BUS_Acounts
    {
        private static BUS_Acounts instance;

        public static BUS_Acounts Instance 
        {
            get { if (instance == null) instance = new BUS_Acounts(); return instance; }
            private set
            {
                instance = value;

            }
        }
        public bool loginAccount(string username,string password)
        {
            return DAO_Accounts.Instance.loginAccount(username,password);
        }
        public bool addAccount(string username, string password, string DisplayName=null)
        {
            if (username == null || password == null) 
            {
                throw new Exception("You must enter username and password");
            }
            username = username.Trim();
            if (username.Contains(" ")) throw new Exception("Username contains spaces");
            return DAO_Accounts.Instance.addAccount(username,password,DisplayName);
        }
        public bool removeAccount(string username) { return DAO_Accounts.Instance.removeAccount(username); }
        public dynamic loadAccounts() { return DAO_Accounts.Instance.loadAccounts(); }

    }
}
