using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWeb.Models
{
    public class Flight
    {
        [Display(Name = "ID")]
        public int FlightId { get; set; }
        [Display(Name = "Departure Airport")]
        public string DepartureAirport { get; set; }
        [Display(Name = "Arrival Airport")]
        public string ArrivalAirport { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime DepartureTime { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}