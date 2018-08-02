using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstHotel.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AirportCode { get; set; }
        public int Id { get; set; }

        public int NoOfRooms { get; set; }
 
    }
}