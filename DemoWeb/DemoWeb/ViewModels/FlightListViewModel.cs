using DemoWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWeb.ViewModels
{
    public class FlightListViewModel
    {
        public FlightListViewModel() { }
        public FlightListViewModel(Flight flight, bool watchList)
        {
            FlightId = flight.FlightId;
            DepartureAirport = flight.DepartureAirport;
            ArrivalAirport = flight.ArrivalAirport;
            DepartureTime = flight.DepartureTime;
            ArrivalTime = flight.ArrivalTime;
            FirstName = flight.FirstName;
            LastName = flight.LastName;
            WatchList = watchList;
        }

        [Display(Name = "Watch List?")]
        public bool WatchList { get; set; }
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