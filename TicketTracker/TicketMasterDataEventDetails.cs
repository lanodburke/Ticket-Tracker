using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace TicketTracker
{
    class TicketMasterDataEventDetails
    {
        public async static Task<RootObject1> GetEventDetails(string eventId)
        {
            var http = new HttpClient();
            var respone = await http.GetAsync("https://app.ticketmaster.com/discovery/v2/events/" + eventId + ".json?apikey=5AdNWJcac0sUjTXt0rQY5lnGJio8OvvN");
            var result = await respone.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject1));

            var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));

            var data = (RootObject1)serializer.ReadObject(ms);

            RootObject1 rootObject1;

            string name = data.name;
            BitmapImage image = new BitmapImage(new Uri(data.images[4].url));
            string eventInfo = data.pleaseNote;
            Location2 loc = new Location2();

            GeneralInfo venueInfo = data._embedded.venues[0].generalInfo;
            string venuName = data._embedded.venues[0].name;
            Address2 address = data._embedded.venues[0].address;
            string longitude = data._embedded.venues[0].location.longitude;
            string latitude = data._embedded.venues[0].location.latitude;

            loc.longitude = longitude;
            loc.latitude = latitude;

            rootObject1 = new RootObject1 { name = name, image = image, eventInfo = eventInfo, address = address, longitude = longitude, latitude = latitude, venueName = venuName };

            return rootObject1;
        }
    }



    [DataContract]
    public class Image3
    {
        [DataMember]
        public string ratio { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int width { get; set; }
        [DataMember]
        public int height { get; set; }
        [DataMember]
        public bool fallback { get; set; }
    }

    [DataContract]
    public class Public2
    {
        [DataMember]
        public string startDateTime { get; set; }
        [DataMember]
        public bool startTBD { get; set; }
        [DataMember]
        public string endDateTime { get; set; }
    }

    [DataContract]
    public class Sales2
    {
        [DataMember]
        public Public2 @public { get; set; }
    }

    [DataContract]
    public class Start2
    {
        [DataMember]
        public string localDate { get; set; }
        [DataMember]
        public string localTime { get; set; }
        [DataMember]
        public string dateTime { get; set; }
        [DataMember]
        public bool dateTBD { get; set; }
        [DataMember]
        public bool dateTBA { get; set; }
        [DataMember]
        public bool timeTBA { get; set; }
        [DataMember]
        public bool noSpecificTime { get; set; }
    }

    [DataContract]
    public class Status2
    {
        [DataMember]
        public string code { get; set; }
    }

    [DataContract]
    public class Dates2
    {
        [DataMember]
        public Start2 start { get; set; }
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public Status2 status { get; set; }
        [DataMember]
        public bool spanMultipleDays { get; set; }
    }

    [DataContract]
    public class Segment3
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Genre3
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class SubGenre3
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Type3
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class SubType3
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Classification3
    {
        [DataMember]
        public bool primary { get; set; }
        [DataMember]
        public Segment3 segment { get; set; }
        [DataMember]
        public Genre3 genre { get; set; }
        [DataMember]
        public SubGenre3 subGenre { get; set; }
        [DataMember]
        public Type type { get; set; }
        [DataMember]
        public SubType3 subType { get; set; }
        [DataMember]
        public bool family { get; set; }
    }

    [DataContract]
    public class Promoter3
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
    }

    [DataContract]
    public class Promoter4
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
    }

    [DataContract]
    public class Self5
    {
        [DataMember]
        public string href { get; set; }
    }

    [DataContract]
    public class Attraction3
    {
        [DataMember]
        public string href { get; set; }
    }

    [DataContract]
    public class Venue3
    {
        [DataMember]
        public string href { get; set; }
    }

    [DataContract]
    public class Links5
    {
        [DataMember]
        public Self5 self { get; set; }
        [DataMember]
        public List<Attraction3> attractions { get; set; }
        [DataMember]
        public List<Venue3> venues { get; set; }
    }

    [DataContract]
    public class City2
    {
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Country2
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string countryCode { get; set; }
    }

    [DataContract]
    public class Address2
    {
        public string line1 { get; set; }
    }

    [DataContract]
    public class Location2
    {
        [DataMember]
        public string longitude { get; set; }
        [DataMember]
        public string latitude { get; set; }
    }

    [DataContract]
    public class Market2
    {
        [DataMember]
        public string id { get; set; }
    }

    [DataContract]
    public class Dma2
    {
        [DataMember]
        public int id { get; set; }
    }

    [DataContract]
    public class Twitter2
    {
        [DataMember]
        public string handle { get; set; }
    }

    [DataContract]
    public class Social
    {
        [DataMember]
        public Twitter2 twitter { get; set; }
    }

    [DataContract]
    public class BoxOfficeInfo
    {
        [DataMember]
        public string phoneNumberDetail { get; set; }
    }

    [DataContract]
    public class GeneralInfo
    {
        [DataMember]
        public string generalRule { get; set; }
        [DataMember]
        public string childRule { get; set; }
    }

    [DataContract]
    public class UpcomingEvents3
    {
        [DataMember]
        public int _total { get; set; }
        [DataMember]
        public int ticketmaster { get; set; }
    }

    [DataContract]
    public class Ada3
    {
        [DataMember]
        public string adaPhones { get; set; }
        [DataMember]
        public string adaCustomCopy { get; set; }
        [DataMember]
        public string adaHours { get; set; }
    }

    [DataContract]
    public class Self6
    {
        [DataMember]
        public string href { get; set; }
    }

    [DataContract]
    public class Links6
    {
        [DataMember]
        public Self6 self { get; set; }
    }

    [DataContract]
    public class Venue4
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public bool test { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string locale { get; set; }
        [DataMember]
        public string postalCode { get; set; }
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public City2 city { get; set; }
        [DataMember]
        public Country2 country { get; set; }
        [DataMember]
        public Address2 address { get; set; }
        [DataMember]
        public Location2 location { get; set; }
        [DataMember]
        public List<Market2> markets { get; set; }
        [DataMember]
        public List<Dma2> dmas { get; set; }
        [DataMember]
        public Social social { get; set; }
        [DataMember]
        public BoxOfficeInfo boxOfficeInfo { get; set; }
        [DataMember]
        public string parkingDetail { get; set; }
        [DataMember]
        public string accessibleSeatingDetail { get; set; }
        [DataMember]
        public GeneralInfo generalInfo { get; set; }
        [DataMember]
        public UpcomingEvents3 upcomingEvents { get; set; }
        [DataMember]
        public Ada3 ada { get; set; }
        [DataMember]
        public Links5 _links { get; set; }
    }

    [DataContract]
    public class Musicbrainz3
    {
        [DataMember]
        public string id { get; set; }
    }

    [DataContract]
    public class Homepage2
    {
        [DataMember]
        public string url { get; set; }
    }

    [DataContract]
    public class ExternalLinks2
    {
        [DataMember]
        public List<Musicbrainz3> musicbrainz { get; set; }
        [DataMember]
        public List<Homepage2> homepage { get; set; }
    }

    [DataContract]
    public class Image4
    {
        [DataMember]
        public string ratio { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int width { get; set; }
        [DataMember]
        public int height { get; set; }
        [DataMember]
        public bool fallback { get; set; }
    }

    [DataContract]
    public class Segment4
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Genre4
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class SubGenre4
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Type4
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class SubType4
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Classification4
    {
        [DataMember]
        public bool primary { get; set; }
        [DataMember]
        public Segment3 segment { get; set; }
        [DataMember]
        public Genre3 genre { get; set; }
        [DataMember]
        public SubGenre3 subGenre { get; set; }
        [DataMember]
        public Type3 type { get; set; }
        [DataMember]
        public SubType3 subType { get; set; }
        [DataMember]
        public bool family { get; set; }
    }

    [DataContract]
    public class UpcomingEvents4
    {
        [DataMember]
        public int _total { get; set; }
        [DataMember]
        public int ticketmaster { get; set; }
    }

    [DataContract]
    public class Self7
    {
        [DataMember]
        public string href { get; set; }
    }

    [DataContract]
    public class Links7
    {
        [DataMember]
        public Self7 self { get; set; }
    }

    [DataContract]
    public class Attraction4
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public bool test { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string locale { get; set; }
        [DataMember]
        public ExternalLinks2 externalLinks { get; set; }
        [DataMember]
        public List<Image3> images { get; set; }
        [DataMember]
        public List<Classification3> classifications { get; set; }
        [DataMember]
        public UpcomingEvents3 upcomingEvents { get; set; }
        [DataMember]
        public Links5 _links { get; set; }
    }

    [DataContract]
    public class Embedded3
    {
        [DataMember]
        public List<Venue4> venues { get; set; }
        [DataMember]
        public List<Attraction3> attractions { get; set; }
    }

    [DataContract]
    public class RootObject1
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string venueName { get; set; }
        public string eventInfo { get; set; }
        public Address2 address { get; set; }
        public GeneralInfo genInfo { get; set; }
        public Location2 location { get; set; }
        public BitmapImage image { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public bool test { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string locale { get; set; }
        [DataMember]
        public List<Image3> images { get; set; }
        [DataMember]
        public Sales2 sales { get; set; }
        [DataMember]
        public Dates2 dates { get; set; }
        [DataMember]
        public List<Classification3> classifications { get; set; }
        [DataMember]
        public Promoter3 promoter { get; set; }
        [DataMember]
        public List<Promoter4> promoters { get; set; }
        [DataMember]
        public string pleaseNote { get; set; }
        [DataMember]
        public Links5 _links { get; set; }
        [DataMember]
        public Embedded3 _embedded { get; set; }
    }
}
