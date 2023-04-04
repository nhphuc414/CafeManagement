using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BUS_Shifts
    {
        private static BUS_Shifts instance;

        public static BUS_Shifts Instance
        {
            get { if (instance == null) instance = new BUS_Shifts(); return instance; }
            private set
            {
                instance = value;
            }
        }
        public dynamic loadShifts()
        {
            return DAO_Shifts.Instance.loadShifts();
        }
        public bool addShift(TimeSpan startTime, TimeSpan endTime)
        {

            return DAO_Shifts.Instance.addShift(startTime, endTime);
        }
    }
}
