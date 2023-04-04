using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BUS_Employees
    {
        private static BUS_Employees instance;

        public static BUS_Employees Instance
        {
            get { if (instance == null) instance = new BUS_Employees(); return instance; }
            private set
            {
                instance = value;

            }
        }
        public dynamic loadEmployees()
        {
            return DAO_Employees.Instance.loadEmployees();
        }
        public bool addEmployee(string name, string role, string salary, string number ,string idShift)
        {
            name = Utils.Utils.NormalizeStringName(name);
            role = Utils.Utils.NormalizeString(role);
            salary = Utils.Utils.NormalizeString(salary);
            number = Utils.Utils.NormalizeString(number);
            if (name=="" || role=="" || salary=="" || number =="")
            {
                throw new Exception("Ban phai dien du thong tin");
            }
            return DAO_Employees.Instance.addEmployee(name, role, decimal.Parse(salary), number, int.Parse(idShift));
        }
        public bool updateEmployee(string id,string name, string role, string salary, string number, string idShift)
        {
            name = Utils.Utils.NormalizeStringName(name);
            role = Utils.Utils.NormalizeString(role);
            salary = Utils.Utils.NormalizeString(salary);
            number = Utils.Utils.NormalizeString(number);
            if (name == "" || role == "" || salary == "" || number == "")
            {
                throw new Exception("Ban phai dien du thong tin");
            }
            return DAO_Employees.Instance.updateEmployee(int.Parse(id),name, role, decimal.Parse(salary), number, int.Parse(idShift));
        }
        public bool deleteEmployee(string id)
        {
            return DAO_Employees.Instance.deleteEmployee(int.Parse(id));
        }

    }
}
