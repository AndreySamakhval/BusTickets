using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Service
    {
        public void InitDB()
        {
            using (var DB = new BusTicketsContext())
            {
                var stop1 = DB.Stops.First(x => x.Id == 1);
                var stop2 = DB.Stops.First(x => x.Id == 2);
                var stop3 = DB.Stops.First(x => x.Id == 3);
                Voyage v1 = new Voyage
                {
                    VoyageName = "Minsk - Brest",
                    VoyageNumber = "123",
                    DepartureDateTime = new DateTime(2016, 11, 20, 01, 30, 00),
                    ArrivalDateTime = new DateTime(2016, 11, 20, 04, 30, 00),
                    DepartureStop = stop1,
                    ArriveStop = stop2,
                    DepartureStopId = stop1.Id,
                    ArivalStopId = stop2.Id,
                    TravelTime = new TimeSpan(3,0,0),
                     NumberOfSeets = 100,
                      TicketCost=100
                };
                Voyage v2 = new Voyage
                {
                    VoyageName = "Minsk - Grodno",
                    VoyageNumber = "124",
                    DepartureDateTime = new DateTime(2016, 11, 20, 01, 00, 00),
                    ArrivalDateTime = new DateTime(2016, 11, 20, 04, 30, 00),
                    DepartureStop = stop1,
                    ArriveStop = stop3,
                    DepartureStopId = stop1.Id,
                    ArivalStopId = stop3.Id,
                    TravelTime = new TimeSpan(3, 30, 0),
                    NumberOfSeets = 100,
                    TicketCost = 150
                };

                DB.Voyages.Add(v1);
                DB.Voyages.Add(v2);
                DB.SaveChanges();

            }
        }
    }
}
