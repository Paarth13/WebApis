using System;
using FirstHotel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;

namespace FirstHotel.Controllers
{
    public class HotelController : ApiController,ICommonFuncs
    {
        
        static int _count = 3;
        static List<Hotel> hotellist = new List<Hotel>
        {
            new Hotel{Id=1,Name="Saiyan Paradise",Address="Planet Saiyan",AirportCode="PS",NoOfRooms=10},
            new Hotel{Id=2,Name="Namekian Paradise",Address="Planet Namek",AirportCode="PN",NoOfRooms=100}
        };

        public List<Hotel> GetDisplay()
        {
            return hotellist;
        }

        public Response GetById(int id)
        {
            var hotl = hotellist.FirstOrDefault((p) => p.Id == id);
            if (hotl != null)
                return new Response()
                {
                    selectedHotel = hotl,
                    type=new Error()
                    {
                        _code=200,
                        _errorMessage="SUCCESSFUL"
                    }
                };
            else
                return new Response()
                {
                    selectedHotel = hotl,
                    type = new Error()
                    {
                        _code = 404,
                        _errorMessage = "NOT FOUND"
                    }
                }; ;
                       
        }

        

        public Response PostAddItem(Hotel hots)
        {
            if (hots != null)
            {
                hots.Id = ++_count;
                hotellist.Add(hots);
                return new Response()
                {
                    selectedHotel = null,
                    type = new Error()
                    {
                        _code = 200,
                        _errorMessage = "Succesful Addition"

                    }
                };
        }
        
            else
            {
        return new Response()
        {
            selectedHotel = null,
            type = new Error()
            {
                _code = 500,
                _errorMessage = "Error Occured"

            }
        };
        }
        }


        [HttpPut]

        public Response BookHotel(int id,[FromBody]int rooms)
        {
            var hotel = hotellist.FirstOrDefault((htl) => htl.Id == id);
            if(hotel.NoOfRooms-rooms>=0)
            {
                hotel.NoOfRooms -= rooms;
                return new Response()
                {
                    selectedHotel = null,
                type=new Error()
                {
                    _code=200,
                    _errorMessage="Succesful Booking"
                }
                };
            }

            else
            {
                return new Response()
                {
                    selectedHotel = null,
                    type = new Error()
                    {
                        _code = 500,
                        _errorMessage = "Booking not possible. Rooms unavailable"

                    }
                };
            }
        }


        public Response DeleteHotel(int id)
        {
            Hotel hotel = null;
                hotel = hotellist.FirstOrDefault((htl) => htl.Id == id);
            if(hotel!=null)
            {
                hotellist.Remove(hotel);
                return new Response()
                {
                    selectedHotel = null,
                    type = new Error()
                    {
                        _code = 200,
                        _errorMessage = "Deletion Succesful"
                    }
                };
            }
            else
            {
                return new Response()
                {
                    selectedHotel = null,
                    type = new Error()
                    {
                        _code = 500,
                        _errorMessage = "Booking not possible. Rooms unavailable"

                    }
                };
            }
            
        }


    }

}
