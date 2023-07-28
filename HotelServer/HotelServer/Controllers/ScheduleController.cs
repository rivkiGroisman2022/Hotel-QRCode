using HotelBL;
using HotelDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        public IScheduleService scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        //get schedule for next days
        [HttpGet("GetSchedule")]
        public List<Schedule> GetSchedule()
        {
            return scheduleService.GetSchedule();
        }

    }
}
