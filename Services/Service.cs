using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class Service
    {
        public void AddStop(StopViewModel stop)
        {           
            using(var DB = new BusTicketsContext())
            {
                var addStop = DB.Stops.Add(new Stop { Name = stop.Name, Description = stop.Description, Status = stop.Status });
                DB.SaveChanges();
               
            }
            
        }

        public List<StopViewModel> GetStops()
        {
            var stops = new List<StopViewModel>(); 
            using (var DB=new BusTicketsContext())
            {
                stops = DB.Stops.Select(x => new StopViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status
                }).ToList();
            }
            return stops;
        }

        public List<StopViewModel> GetStops(string name)
        {
            var stops = new List<StopViewModel>();
            using (var DB = new BusTicketsContext())
            {
                stops = DB.Stops.Where(x=>x.Name.Contains(name)).Select(x => new StopViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Status = x.Status
                }).ToList();
            }
            return stops;
        }

        public List<StopInfoViewModel> GetStopInfo(int id)
        {
            var stopInfo = new List<StopInfoViewModel>();

            using(var DB = new BusTicketsContext())
            {
              var  stopArrival = DB.Voyages.Where(x => x.ArivalStopId == id)
                    .Select(x => new StopInfoViewModel
                    {
                        Name = x.VoyageName,
                        Number = x.VoyageNumber,
                        Arrival = x.ArrivalDateTime.ToString()
                        //Departure = x.DepartureDateTime.ToString()
                    }).ToList();

                var stopDeparture = DB.Voyages.Where(x => x.DepartureStopId == id)
                    .Select(x => new StopInfoViewModel
                    {
                        Name = x.VoyageName,
                        Number = x.VoyageNumber,                        
                        Departure = x.DepartureDateTime.ToString()
                    }).ToList();

                stopInfo.AddRange(stopArrival);
                stopInfo.AddRange(stopDeparture);
            }

            return stopInfo;
        }

        public List<VoyageViewModel> SearchVoyages(SearchVoyageViewModel searchVoyage)
        {
            var result = new List<VoyageViewModel>();
            var d = searchVoyage.Date;
            var d1 = searchVoyage.Date.AddDays(1);
            using (var DB = new BusTicketsContext())
            {
                 result = DB.Voyages.Where(x => x.DepartureStopId == searchVoyage.DepartureId
               && x.ArivalStopId == searchVoyage.ArriveId
               && x.DepartureDateTime>d&&x.DepartureDateTime<d1)
                .Select(x => new VoyageViewModel
                {
                    Id = x.Id,
                    Name = x.VoyageName,
                    Number = x.VoyageNumber,
                    TravelTime = x.TravelTime,
                    Departure = x.DepartureDateTime,
                    Arrival = x.ArrivalDateTime,
                    NumberSeats = x.NumberOfSeets,
                    OneTicketCost = x.TicketCost
                }).ToList();
            }

            return result;
        }

        public VoyageViewModel GetVoyage(int id)
        {
            VoyageViewModel voyage;

            using (var DB = new BusTicketsContext())
            {
               var result = DB.Voyages.First(x => x.Id == id);
                voyage = new VoyageViewModel {
                    Id = result.Id,
                    Name = result.VoyageName,
                    Number = result.VoyageNumber,
                    TravelTime = result.TravelTime,
                    Departure = result.DepartureDateTime,
                    Arrival = result.ArrivalDateTime,
                    NumberSeats = result.NumberOfSeets,
                    OneTicketCost = result.TicketCost
                };
            }

                return voyage;
        }

        public int NewOrder(int voyageId)
        {
            int id;

            using (var DB = new BusTicketsContext())
            {
                Order order = new Order { VoyageId = voyageId, Status = "open" };
                var newOrder = DB.Orders.Add(order);
                DB.SaveChanges();
                id = newOrder.Id;
            }

            return id;
        }

        public int NewTicket(TicketViewModel ticket)
        {
            int id;
            using (var DB = new BusTicketsContext())
            {
                var newTicket = DB.Tickets.Add(new Ticket
                {
                    OrderId = ticket.OrderId,
                    PassengerDocumentNumber = ticket.DocumentNumber,
                    PassengerName = ticket.PassengerName,
                    SeetNumber = ticket.NumberSeet,
                    Status = "reserved"
                });
                DB.SaveChanges();
                id = newTicket.Id;
            }
            return id;
        }

        public TicketInfoViewModel TicketInfo (int id)
        {
            TicketInfoViewModel ticketInfo;
            using (var DB = new BusTicketsContext())
            {
                ticketInfo = DB.Tickets.Where(x => x.Id == id).Select(x => new TicketInfoViewModel
                {
                    OrderId = x.OrderId,
                    DocumentNumber = x.PassengerDocumentNumber,
                    PassengerName = x.PassengerName,
                    NumberSeet = x.SeetNumber,
                    Status = x.Status
                }).Single();
                var voyageId = DB.Orders.Find(ticketInfo.OrderId).VoyageId;
                var voyage = DB.Voyages.Find(voyageId);
                ticketInfo.VoyageName = voyage.VoyageName;
                ticketInfo.VoyageNumeber = voyage.VoyageNumber;
                ticketInfo.Departure = voyage.DepartureDateTime;
            }

            return ticketInfo;
        }

        public void UpdateOrder(int id, string status)
        {
            using (var DB = new BusTicketsContext())
            {
                var order = DB.Orders.Find(id);
                order.Status = status;
                DB.SaveChanges();
            }
        }





        public void InitDB()
        {
            using (var DB = new BusTicketsContext())
            {
                var stop1 = DB.Stops.First(x => x.Id == 1);
                var stop2 = DB.Stops.First(x => x.Id == 2);
                var stop3 = DB.Stops.First(x => x.Id == 10);
                Voyage v1 = new Voyage
                {
                    VoyageName = "Minsk - Gomel",
                    VoyageNumber = "15",
                    DepartureDateTime = new DateTime(2016, 11, 20, 10, 30, 00),
                    ArrivalDateTime = new DateTime(2016, 11, 20, 15, 30, 00),
                    DepartureStop = stop1,
                    ArriveStop = stop3,
                    DepartureStopId = stop1.Id,
                    ArivalStopId = stop3.Id,
                    TravelTime = new TimeSpan(5,0,0),
                     NumberOfSeets = 100,
                      TicketCost=200
                };
                Voyage v2 = new Voyage
                {
                    VoyageName = "Brest - Minsk",
                    VoyageNumber = "21",
                    DepartureDateTime = new DateTime(2016, 11, 20, 14, 00, 00),
                    ArrivalDateTime = new DateTime(2016, 11, 20, 18, 30, 00),
                    DepartureStop = stop2,
                    ArriveStop = stop1,
                    DepartureStopId = stop2.Id,
                    ArivalStopId = stop1.Id,
                    TravelTime = new TimeSpan(4, 30, 0),
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
