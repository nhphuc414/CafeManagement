using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Employees
    {
        private static DAO_Employees instance;

        public static DAO_Employees Instance
        {
            get { if (instance == null) instance = new DAO_Employees(); return instance; }
            private set
            {
                instance = value;

            }
        }
        public dynamic loadEmployees()
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                return db.Employees.Select(e => new
                {
                    e.Id,
                    e.EmployeeName,
                    e.Number,
                    e.Salary,
                    e.IdShift,
                    e.Shift.StartTime,
                    e.Shift.EndTime
                }).ToList();
            }
        }
        public bool addEmployee(string name, string role, decimal salary, string number, int idShift)
        {
            using(CafeManagementEntities db = new CafeManagementEntities())
            {
                if (db.Employees.FirstOrDefault(e => e.EmployeeName.ToLower()==name.ToLower() && e.Number == number && e.IdShift==idShift)!=null)
                {
                    throw new Exception("Da co nhan vien nay");
                }
                db.Employees.Add(new Employee
                {
                    EmployeeName=name,
                    Number=number,
                    Salary=salary,
                    Role=role,
                    IdShift=idShift
                });
                return true;
            }
        }
        public bool updateEmployee(int id,string name, string role, decimal salary, string number, int idShift)
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                Employee emp = db.Employees.Find(id);
                emp.Salary = salary;
                emp.EmployeeName= name;
                emp.Number = number;
                emp.IdShift = idShift; 
                emp.Role = role;
                db.SaveChanges();
                return true;
            }
        }
        public bool deleteEmployee(int id)
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                db.Employees.Remove(db.Employees.Find(id));
                db.SaveChanges();
                return true;
            }
        }

    }
}