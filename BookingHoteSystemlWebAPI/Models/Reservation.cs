//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingHoteSystemlWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int ID { get; set; }
        public Nullable<int> Resroom_number { get; set; }
        public Nullable<int> Resguest_id { get; set; }
        public string Booking_Name { get; set; }
    
        public virtual Guest Guest { get; set; }
    }
}