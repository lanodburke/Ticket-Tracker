using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace TicketTracker
{
    public class TicketMasterData
    {
        /*
BM (Bermuda)
BR (Brazil)
BG (Bulgaria)
CA (Canada)
CL (Chile)
CN (China)
CO (Colombia)
CR (Costa Rica)
HR (Croatia)
CY (Cyprus)
CZ (Czech Republic)
DK (Denmark)
DO (Dominican Republic)
EC (Ecuador)
EE (Estonia)
FO (Faroe Islands)
FI (Finland)
FR (France)
GE (Georgia)
DE (Germany)
GH (Ghana)
GI (Gibraltar)
GB (Great Britain)
GR (Greece)
HK (Hong Kong)
HU (Hungary)
IS (Iceland)
IN (India)
IE (Ireland)
IL (Israel)
IT (Italy)
JM (Jamaica)
JP (Japan)
KR (Korea, Republic of)
LV (Latvia)
LB (Lebanon)
LT (Lithuania)
LU (Luxembourg)
MY (Malaysia)
MT (Malta)
MX (Mexico)
MC (Monaco)
ME (Montenegro)
MA (Morocco)
NL (Netherlands)
AN (Netherlands Antilles)
NZ (New Zealand)
ND (Northern Ireland)
NO (Norway)
PE (Peru)
PL (Poland)
PT (Portugal)
RO (Romania)
RU (Russian Federation)
LC (Saint Lucia)
SA (Saudi Arabia)
RS (Serbia)
SG (Singapore)
SK (Slovakia)
SI (Slovenia)
ZA (South Africa)
ES (Spain)
SE (Sweden)
CH (Switzerland)
TW (Taiwan)
TH (Thailand)
TT (Trinidad and Tobago)
TR (Turkey)
UA (Ukraine)
AE (United Arab Emirates)
UY (Uruguay)
VE (Venezuela)

Classifications: Music, Sports, Film, Art & Theatre
     */
        public async static Task<List<Event>> GetEventsByCountryId(string countryCode)
        {
            var http = new HttpClient();
            var respone = await http.GetAsync("https://app.ticketmaster.com/discovery/v2/events.json?apikey=5AdNWJcac0sUjTXt0rQY5lnGJio8OvvN&size=200&countryCode=" + countryCode);
            var result = await respone.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));

            var data = (RootObject)serializer.ReadObject(ms);

            var events = new List<Event>();

            for (int i = 0; i < data._embedded.events.Count(); i++)
            {
                string name = data._embedded.events[i].name;
                BitmapImage image = null;

                // 10 images for each event
                for (int j = 0; j < 10; j++)
                {
                    if (data._embedded.events[i].images[j].height.Equals(576)
                        && data._embedded.events[i].images[j].width.Equals(1024))
                    {
                        image = new BitmapImage(new Uri(data._embedded.events[i].images[j].url));
                        j = 10;
                    } 
                }

                string id = data._embedded.events[i].id;
                string venueName = data._embedded.events[i]._embedded.venues[0].name;
                Console.WriteLine(id);

                events.Add(new Event { id = id, name = name, image = image,
                    venueName = venueName});
            }
            return events;
        }

        public async static Task<List<Event>> GetEventsByClassifcation(string classifcation)
        {
            var http = new HttpClient();
            var respone = await http.GetAsync("https://app.ticketmaster.com/discovery/v2/events.json?apikey=5AdNWJcac0sUjTXt0rQY5lnGJio8OvvN&size=200&classificationName" + classifcation);
            var result = await respone.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));

            var data = (RootObject)serializer.ReadObject(ms);

            var events = new List<Event>();

            for (int i = 0; i < data._embedded.events.Count(); i++)
            {
                string name = data._embedded.events[i].name;
                Console.WriteLine(name);
                BitmapImage image = null;

                // 10 images for each event
                for (int j = 0; j < 10; j++)
                {
                    if (data._embedded.events[i].images[j].height.Equals(576)
                        && data._embedded.events[i].images[j].width.Equals(1024))
                    {
                        image = new BitmapImage(new Uri(data._embedded.events[i].images[j].url));
                        j = 10;
                    }
                }
                string id = data._embedded.events[i].id;
                string venueName = data._embedded.events[i]._embedded.venues[0].name;
                Console.WriteLine(id);

                events.Add(new Event
                {
                    id = id,
                    name = name,
                    image = image,
                    venueName = venueName
                });
            }
            return events;
        }
}

    [DataContract]
    public class Image
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
    public class Public
    {
        [DataMember]
        public string startDateTime { get; set; }

        [DataMember]
        public bool startTBD { get; set; }

        [DataMember]
        public string endDateTime { get; set; }

    }
    [DataContract]
    public class Sales
    {
        [DataMember]
        public Public @public { get; set; }
    }
    [DataContract]
    public class Start
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
    public class Status
    {
        [DataMember]
        public string code { get; set; }
    }
    [DataContract]
    public class Dates
    {
        [DataMember]
        public Start start { get; set; }
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public Status status { get; set; }
        [DataMember]
        public bool spanMultipleDays { get; set; }
    }
    [DataContract]
    public class Segment
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Genre
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class SubGenre
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Type
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class SubType
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Classification
    {
        [DataMember]
        public bool primary { get; set; }
        [DataMember]
        public Segment segment { get; set; }
        [DataMember]
        public Genre genre { get; set; }
        [DataMember]
        public SubGenre subGenre { get; set; }
        [DataMember]
        public Type type { get; set; }
        [DataMember]
        public SubType subType { get; set; }
        [DataMember]
        public bool family { get; set; }
    }
    [DataContract]
    public class Promoter
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
    }
    [DataContract]
    public class Promoter2
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
    }
    [DataContract]
    public class Self
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Attraction
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Venue
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links
    {
        [DataMember]
        public Self self { get; set; }
        [DataMember]
        public List<Attraction> attractions { get; set; }
        [DataMember]
        public List<Venue> venues { get; set; }
    }
    [DataContract]
    public class City
    {
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Country
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string countryCode { get; set; }
    }
    [DataContract]
    public class Address
    {
        [DataMember]
        public string line1 { get; set; }
    }
    [DataContract]
    public class Location
    {
        [DataMember]
        public string longitude { get; set; }
        [DataMember]
        public string latitude { get; set; }
    }
    [DataContract]
    public class Market
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class Dma
    {
        [DataMember]
        public int id { get; set; }
    }
    [DataContract]
    public class UpcomingEvents
    {
        [DataMember]
        public int _total { get; set; }
        [DataMember]
        public int ticketmaster { get; set; }
    }
    [DataContract]
    public class Ada
    {
        [DataMember]
        public string adaPhones { get; set; }
        [DataMember]
        public string adaCustomCopy { get; set; }
        [DataMember]
        public string adaHours { get; set; }
    }
    [DataContract]
    public class Self2
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links2
    {
        [DataMember]
        public Self2 self { get; set; }
    }
    [DataContract]
    public class Venue2
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
        public City city { get; set; }
        [DataMember]
        public Country country { get; set; }
        [DataMember]
        public Address address { get; set; }
        [DataMember]
        public Location location { get; set; }
        [DataMember]
        public List<Market> markets { get; set; }
        [DataMember]
        public List<Dma> dmas { get; set; }
        [DataMember]
        public UpcomingEvents upcomingEvents { get; set; }
        [DataMember]
        public Ada ada { get; set; }
        [DataMember]
        public Links2 _links { get; set; }
    }
    [DataContract]
    public class Twitter
    {
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class Itune
    {
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class Lastfm
    {
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class Facebook
    {
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class Wiki
    {
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class Musicbrainz
    {
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class Homepage
    {
        [DataMember]
        public string url { get; set; }
    }
    [DataContract]
    public class ExternalLinks
    {
        [DataMember]
        public List<Twitter> twitter { get; set; }
        [DataMember]
        public List<Itune> itunes { get; set; }
        [DataMember]
        public List<Lastfm> lastfm { get; set; }
        [DataMember]
        public List<Facebook> facebook { get; set; }
        [DataMember]
        public List<Wiki> wiki { get; set; }
        [DataMember]
        public List<Musicbrainz> musicbrainz { get; set; }
        [DataMember]
        public List<Homepage> homepage { get; set; }
    }
    [DataContract]
    public class Image2
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
    public class Segment2
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Genre2
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class SubGenre2
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Type2
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class SubType2
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Classification2
    {
        [DataMember]
        public bool primary { get; set; }
        [DataMember]
        public Segment2 segment { get; set; }
        [DataMember]
        public Genre2 genre { get; set; }
        [DataMember]
        public SubGenre2 subGenre { get; set; }
        [DataMember]
        public Type2 type { get; set; }
        [DataMember]
        public SubType2 subType { get; set; }
        [DataMember]
        public bool family { get; set; }
    }
    [DataContract]
    public class UpcomingEvents2
    {
        [DataMember]
        public int _total { get; set; }
    }
    [DataContract]
    public class Self3
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links3
    {
        [DataMember]
        public Self3 self { get; set; }
    }
    [DataContract]
    public class Attraction2
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
        public ExternalLinks externalLinks { get; set; }
        [DataMember]
        public List<Image2> images { get; set; }
        [DataMember]
        public List<Classification2> classifications { get; set; }
        [DataMember]
        public UpcomingEvents2 upcomingEvents { get; set; }
        [DataMember]
        public Links3 _links { get; set; }
    }
    [DataContract]
    public class Embedded2
    {
        [DataMember]
        public List<Venue2> venues { get; set; }
        [DataMember]
        public List<Attraction2> attractions { get; set; }
    }
    [DataContract]
    public class Event
    {
        public string venueName { get; set; }
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
        public List<Image> images { get; set; }
        [DataMember]
        public Sales sales { get; set; }
        [DataMember]
        public Dates dates { get; set; }
        [DataMember]
        public List<Classification> classifications { get; set; }
        [DataMember]
        public Promoter promoter { get; set; }
        [DataMember]
        public List<Promoter2> promoters { get; set; }
        [DataMember]
        public string pleaseNote { get; set; }
        [DataMember]
        public Links _links { get; set; }
        [DataMember]
        public Embedded2 _embedded { get; set; }
    }
    [DataContract]
    public class Embedded
    {
        [DataMember]
        public List<Event> events { get; set; }
    }
    [DataContract]
    public class First
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Self4
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Next
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Last
    {
        [DataMember]
        public string href { get; set; }
    }
    [DataContract]
    public class Links4
    {
        [DataMember]
        public First first { get; set; }
        [DataMember]
        public Self4 self { get; set; }
        [DataMember]
        public Next next { get; set; }
        [DataMember]
        public Last last { get; set; }
    }
    [DataContract]
    public class Page
    {
        [DataMember]
        public int size { get; set; }
        [DataMember]
        public int totalElements { get; set; }
        [DataMember]
        public int totalPages { get; set; }
        [DataMember]
        public int number { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Embedded _embedded { get; set; }
        [DataMember]
        public Links4 _links { get; set; }
        [DataMember]
        public Page page { get; set; }
    }
}