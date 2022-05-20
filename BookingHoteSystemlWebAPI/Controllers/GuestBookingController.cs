using BookingHoteSystemlWebAPI.Models;
using BookingHoteSystemlWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookingHoteSystemlWebAPI.Controllers
{
    public class GuestBookingController : ApiController
    {
        private HotelBookingsystemEntities5 db = new HotelBookingsystemEntities5();
         
        Guest guest = new Guest();
        public async Task<IHttpActionResult> PostNewBooking(GuestRversation  guestRversation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guests.Add( new Guest
            {
                City=guestRversation.City,
                Country=guestRversation.Country,
                Name=guestRversation.Name
            }
                );
            db.Reservations.Add(new Reservation

            {
                Booking_Name = guestRversation.Booking_Name,
                Resroom_number =guestRversation.Resroom_number,
                Resguest_id = guest.Guest_ID

            }

             ); ;

            try
            {
                await db.SaveChangesAsync();
                
            }
            catch (DbUpdateException)
            {
                
            }

            return CreatedAtRoute("DefaultApi", new { id = guestRversation.Resroom_number }, guestRversation);
        }
        List<GuestRversation>  guestRversations = new List<GuestRversation>();
        List<GuestRversation> guestRversations1 = new List<GuestRversation>();
        public IHttpActionResult GetRoomooking()
        {
            List<Guest>  guest = db.Guests.ToList();
            List<Reservation>  reversation = db.Reservations.ToList();
            //foreach (var item in guest)
            //{
            //    guestRversations.Add(
            //        new GuestRversation
            //        {
            //             Name = item.Name,
            //             City = item. City,
            //             Country = item.Country ,
            //             Phone = item. Phone,
            //             Resroom_number=reversation[i]
            //        }
            //        );
                
            //}
            for (int i =0;i<reversation.Count;i++)
            {
                guestRversations.Add(new GuestRversation
                {
                    Name = guest[i].Name,
                    City = guest[i].City,
                    Country = guest[i].Country,
                    Phone = guest[i].Phone,
                    Resroom_number = (int)reversation[i].Resroom_number
                });
            }
            
            //foreach (var item in reversation)
            //{
            //    guestRversations.Add(
            //        new GuestRversation
            //        {
            //             Resroom_number= (int)item.Resroom_number,
            //        }
            //        );
                
            //}
            

            //foreach(var item in guestRversations)
            //{
            //    if(item.Resroom_number!=0)
            //    {
            //        guestRversations1.Add(
            //            new GuestRversation
            //            {
            //                Country=item.Country,
            //                Name=item.Name,
            //                Resroom_number=item.Resroom_number,
            //                Phone=item.Phone,
            //                City=item.City
            //            }
            //           );
            //    }
            //}
            return Ok<List<GuestRversation>>(guestRversations);
        }
    }
}
