using HotelDAL;
using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public class ScheduleService : IScheduleService
    {

        public IScheduleRepository scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }


        public List<Schedule> GetSchedule()
        {
            return scheduleRepository.GetScheduleForNextThreeDays();
        }
    }
}
