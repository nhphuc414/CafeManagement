using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Shifts
    {
        private static DAO_Shifts instance;

        public static DAO_Shifts Instance
        {
            get { if (instance == null) instance = new DAO_Shifts(); return instance; }
            private set
            {
                instance = value;
            }
        }
        public dynamic loadShifts()
        {
            using (CafeManagementEntities db = new CafeManagementEntities())
            {
                return db.Shifts.Select(s => new
                {
                    s.Id,
                    s.StartTime,
                    s.EndTime
                }).ToList();
            }
        }
        public bool addShift(TimeSpan startTime, TimeSpan endTime)
        {
            using (var context = new CafeManagementEntities())
            {
                // Kiểm tra xem giờ bắt đầu và kết thúc của ca làm mới có trùng với các ca làm đã có trong CSDL hay không
                List<Shift> workSchedules = context.Shifts.ToList();
                foreach (Shift existingWorkSchedule in workSchedules)
                {
                    if ((startTime >= existingWorkSchedule.StartTime && startTime < existingWorkSchedule.EndTime) ||
                        (endTime > existingWorkSchedule.StartTime && endTime <= existingWorkSchedule.EndTime))
                    {
                        throw new Exception("Giờ bắt đầu và kết thúc của ca làm trùng với một ca làm đã có trong CSDL.");
                    }
                }
                // Thêm ca làm mới vào CSDL
                context.Shifts.Add(new Shift
                {
                    StartTime = startTime,
                    EndTime = endTime
                });
                context.SaveChanges();
                return true;
            }
        }
        public bool updateShift(int id, TimeSpan startTime, TimeSpan endTime)
        {
            using (var db= new CafeManagementEntities())
            {
                List<Shift> workSchedules = db.Shifts.ToList();
                foreach (Shift existingWorkSchedule in workSchedules)
                {
                    if ((startTime >= existingWorkSchedule.StartTime && startTime < existingWorkSchedule.EndTime) ||
                        (endTime > existingWorkSchedule.StartTime && endTime <= existingWorkSchedule.EndTime))
                    {
                        throw new Exception("Giờ bắt đầu và kết thúc của ca làm trùng với một ca làm đã có trong CSDL.");
                    }
                }
                Shift sh= db.Shifts.FirstOrDefault(s => s.Id == id);
                sh.StartTime = startTime; 
                sh.EndTime = endTime;
                db.SaveChanges();
                return true;
            }
        }
        public bool deleteShift(int id)
        {
           using(var db=new CafeManagementEntities())
            {
                db.Shifts.Remove(db.Shifts.Find(id));
                return true;
            }
        }
    }
}
