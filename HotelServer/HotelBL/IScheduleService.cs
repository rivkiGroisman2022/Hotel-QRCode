﻿using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBL
{
    public interface IScheduleService
    {
        List<Schedule> GetSchedule();
    }
}
