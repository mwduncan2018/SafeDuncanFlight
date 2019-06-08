using DemoWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DemoWeb.ViewModels
{
    public class WatchListEntryViewModel
    {
        public WatchListEntryViewModel() { }
        public WatchListEntryViewModel(WatchListEntry watchListEntry)
        {
            WatchListEntryId = watchListEntry.WatchListEntryId;
            Bounty = watchListEntry.Bounty.ToString("C", CultureInfo.CurrentCulture);
            FirstName = watchListEntry.FirstName;
            LastName = watchListEntry.LastName;
        }

        [Display(Name = "Watch List Entry ID")]
        public int WatchListEntryId { get; set; }
        [Display(Name = "Bounty")]
        public string Bounty { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}