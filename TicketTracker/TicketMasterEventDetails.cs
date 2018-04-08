using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerData
{
    class TicketMasterEventDetails
    {

    }

    public class Image
    {
        public string ratio { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool fallback { get; set; }
    }

    public class Public
    {
        public DateTime startDateTime { get; set; }
        public bool startTBD { get; set; }
        public DateTime endDateTime { get; set; }
    }

    public class Sales
    {
        public Public @public { get; set; }
    }

    public class Start
    {
        public string localDate { get; set; }
        public string localTime { get; set; }
        public DateTime dateTime { get; set; }
        public bool dateTBD { get; set; }
        public bool dateTBA { get; set; }
        public bool timeTBA { get; set; }
        public bool noSpecificTime { get; set; }
    }

    public class Status
    {
        public string code { get; set; }
    }

    public class Dates
    {
        public Start start { get; set; }
        public string timezone { get; set; }
        public Status status { get; set; }
        public bool spanMultipleDays { get; set; }
    }

    public class Segment
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Genre
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SubGenre
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Type
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SubType
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Classification
    {
        public bool primary { get; set; }
        public Segment segment { get; set; }
        public Genre genre { get; set; }
        public SubGenre subGenre { get; set; }
        public Type type { get; set; }
        public SubType subType { get; set; }
        public bool family { get; set; }
    }

    public class Promoter
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Promoter2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Attraction
    {
        public string href { get; set; }
    }

    public class Venue
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public List<Attraction> attractions { get; set; }
        public List<Venue> venues { get; set; }
    }

    public class City
    {
        public string name { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string countryCode { get; set; }
    }

    public class Address
    {
        public string line1 { get; set; }
    }

    public class Location
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class Market
    {
        public string id { get; set; }
    }

    public class Dma
    {
        public int id { get; set; }
    }

    public class Twitter
    {
        public string handle { get; set; }
    }

    public class Social
    {
        public Twitter twitter { get; set; }
    }

    public class BoxOfficeInfo
    {
        public string phoneNumberDetail { get; set; }
    }

    public class GeneralInfo
    {
        public string generalRule { get; set; }
        public string childRule { get; set; }
    }

    public class UpcomingEvents
    {
        public int _total { get; set; }
        public int ticketmaster { get; set; }
    }

    public class Ada
    {
        public string adaPhones { get; set; }
        public string adaCustomCopy { get; set; }
        public string adaHours { get; set; }
    }

    public class Self2
    {
        public string href { get; set; }
    }

    public class Links2
    {
        public Self2 self { get; set; }
    }

    public class Venue2
    {
        public string name { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public bool test { get; set; }
        public string url { get; set; }
        public string locale { get; set; }
        public string postalCode { get; set; }
        public string timezone { get; set; }
        public City city { get; set; }
        public Country country { get; set; }
        public Address address { get; set; }
        public Location location { get; set; }
        public List<Market> markets { get; set; }
        public List<Dma> dmas { get; set; }
        public Social social { get; set; }
        public BoxOfficeInfo boxOfficeInfo { get; set; }
        public string parkingDetail { get; set; }
        public string accessibleSeatingDetail { get; set; }
        public GeneralInfo generalInfo { get; set; }
        public UpcomingEvents upcomingEvents { get; set; }
        public Ada ada { get; set; }
        public Links2 _links { get; set; }
    }

    public class Musicbrainz
    {
        public string id { get; set; }
    }

    public class Homepage
    {
        public string url { get; set; }
    }

    public class ExternalLinks
    {
        public List<Musicbrainz> musicbrainz { get; set; }
        public List<Homepage> homepage { get; set; }
    }

    public class Image2
    {
        public string ratio { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool fallback { get; set; }
    }

    public class Segment2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Genre2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SubGenre2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Type2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class SubType2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Classification2
    {
        public bool primary { get; set; }
        public Segment2 segment { get; set; }
        public Genre2 genre { get; set; }
        public SubGenre2 subGenre { get; set; }
        public Type2 type { get; set; }
        public SubType2 subType { get; set; }
        public bool family { get; set; }
    }

    public class UpcomingEvents2
    {
        public int _total { get; set; }
        public int ticketmaster { get; set; }
    }

    public class Self3
    {
        public string href { get; set; }
    }

    public class Links3
    {
        public Self3 self { get; set; }
    }

    public class Attraction2
    {
        public string name { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public bool test { get; set; }
        public string url { get; set; }
        public string locale { get; set; }
        public ExternalLinks externalLinks { get; set; }
        public List<Image2> images { get; set; }
        public List<Classification2> classifications { get; set; }
        public UpcomingEvents2 upcomingEvents { get; set; }
        public Links3 _links { get; set; }
    }

    public class Embedded
    {
        public List<Venue2> venues { get; set; }
        public List<Attraction2> attractions { get; set; }
    }

    public class RootObject
    {
        public string name { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public bool test { get; set; }
        public string url { get; set; }
        public string locale { get; set; }
        public List<Image> images { get; set; }
        public Sales sales { get; set; }
        public Dates dates { get; set; }
        public List<Classification> classifications { get; set; }
        public Promoter promoter { get; set; }
        public List<Promoter2> promoters { get; set; }
        public string pleaseNote { get; set; }
        public Links _links { get; set; }
        public Embedded _embedded { get; set; }
    }
}
