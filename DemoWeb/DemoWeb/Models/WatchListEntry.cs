using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWeb.Models
{
    public class WatchListEntry : IEquatable<WatchListEntry>
    {
        public WatchListEntry() { }
        public WatchListEntry(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        [Display(Name = "Watch List Entry ID")]
        public int WatchListEntryId { get; set; }
        [Display(Name = "Bounty")]
        public int Bounty { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool Equals(WatchListEntry other)
        {
            return (FirstName == other.FirstName && LastName == other.LastName);
        }
    }
}