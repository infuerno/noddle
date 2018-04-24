using System;
using System.Collections.Generic;

namespace Noddle.Web.Models
{

    // https://developers.google.com/calendar/concepts/events-calendars

    // FROM GOOGLE CALENDAR API
    // A calendar is a collection of related events, along with additional metadata such as summary, 
    // default time zone, location, etc. 
    // Each calendar is identified by an ID which is an email address. 
    // Calendars can have multiple owners.
    public class Calendar
    {

    }

    // FROM GOOGLE CALENDAR API
    // An event is an object associated with a specific date or time range. 
    // Events are identified by an ID that is unique within a calendar. 
    // Besides a start and end date-time, events contain other data such as summary, description, location, status, reminders, attachments, etc.

    // An event has a start date and a duration and / or an end date, and maybe a recurrence
    // e.g. choir practice every Thursday 7:00 to 9:00
    // this will be shown on the Daily View, Weekly View etc
    public abstract class Event
    {
        // can be specified, but otherwise will be generated
        public string Id { get; set; }
        public string Status { get; set; }
        public string HtmlLink { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        //public bool IsClockDisplayed { get; set; } = true;

        //public Image Image { get; set; }
        //public Colour Colour { get; set; }
        //public Sound Sound { get; set; }
        //public Place Location { get; set; }
    }

    public class RecurringEvent
    {
        public List<SingleEvent> GetOccurrences()
        {
            throw new NotImplementedException();
        }
    }

    public class SingleEvent
    {

    }

    // A reminder
    public class Reminder {
    	public int Id {get; set;}
    }

    // TODO do we need this class - will be exactly the same as reminder
    public class RandomReminder : Reminder {

    }

    // this class will have lots of rules on it
    public class Schedule {
    	public DateTime DisplayDateFrom { get; set; }
		public DateTime DisplayDateTo { get; set; }
		public bool IsAlwaysDisplayed { get; set; }
		public DateTime DisplayTimeFrom { get; set; }
		public DateTime DisplayTimeTo { get; set; }
		public string DisplayFrequency { get; set; } // Daily; Weekly; Monthly / Yearly
		public int DisplayFrequencyStep { get; set; } // 1 for every day, every week; 2 for every other day; every other week
		public string DisplayFrequencyWeekday { get; set; } // e.g. Mon, Tues etc - Weekly or Monthly / Yearly with SpecificWeekday
		public string DisplayFrequencyMonth { get; set; } // e.g. Jan, Feb etc - Monthly / Yearly only
		public string DisplayFrequencyDayOfMonth { get; set; } // e.g. 1st, 2nd etc - Monthly / Yearly only
		public string DisplayFrequencySpecificWeekday { get; set; } // e.g. 1st, 2nd, 3rd, 4th, Last
		public string DisplayFrequencyDescription { get; } // calculated from other display fields

    }

}

// how do we represent this kind of model in the database