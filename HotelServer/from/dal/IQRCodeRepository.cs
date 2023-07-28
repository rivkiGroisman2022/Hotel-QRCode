﻿using HotelDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDAL
{
    public interface IQRCodeRepository
    {
        string GetQRCodeForRoom(int roomNum);
        List<string> GetActiveQRCodesFotCustomer(int roomNum);
    }
}
