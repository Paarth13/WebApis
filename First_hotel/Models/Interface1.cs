using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstHotel.Models
{
    public interface ICommonFuncs
    {
         List<Hotel> GetDisplay();
         Response GetById(int id);
        Response PostAddItem(Hotel hots);

        Response BookHotel(int id, int rooms);

        Response DeleteHotel(int id);
    }
}
