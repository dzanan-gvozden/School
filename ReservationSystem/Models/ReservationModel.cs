﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace ReservationSystem.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public int Resource { get; set; }
        public string ResourceName { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
    }
}