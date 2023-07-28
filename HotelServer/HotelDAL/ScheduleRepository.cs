using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL
{
    public class ScheduleRepository : IScheduleRepository
    {
        public readonly HotelContext context;
        public ScheduleRepository(HotelContext context)
        {
            this.context = context;
        }

        //get schedual for next 3 days
        public List<Schedule> GetScheduleForNextThreeDays()
        {
            try
            {
                return context.Schedules.
                Where(x => x.Date.Date <= DateTime.Today.Date.AddDays(3) && x.Date.Date >= DateTime.Today.Date)
               .ToList();
                //return context.Schedules.ToList();
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("GetScheduleForNextThreeDays", ex.Message);
                return null;
            }

        }

        //add plan to schedual
        public bool AddPlan(Schedule schedule)
        {
            try
            {
                context.Schedules.Add(schedule);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("AddPlan", ex.Message);
                return false;
            }

        }

        //update plan details
        public bool UpdatePlan(int planId, Schedule schedule)
        {
            try
            {
                Schedule scheduleToUpdate = context.Schedules.FirstOrDefault(x => x.EventId == planId);
                if (scheduleToUpdate != null)
                {
                    scheduleToUpdate.Date = schedule.Date;
                    scheduleToUpdate.Time = schedule.Time;
                    scheduleToUpdate.Description = schedule.Description;
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("UpdatePlan", ex.Message);
                return false;
            }
        }

        //delete plan
        public bool DeletePlan(int planId)
        {
            try
            {
                Schedule scheduleToDelete = context.Schedules.FirstOrDefault(x => x.EventId == planId);
                if (scheduleToDelete != null)
                {
                    context.Schedules.Remove(scheduleToDelete);
                    context.SaveChanges();
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                EmailManager email = new EmailManager();
                email.SendErrorEmail("DeletePlan", ex.Message);
                return false;
            }
        }


    }
}
