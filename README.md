# Ticket-Tracker

Universal Windows Application(UWP) that lets users search events in their country and sort them by genre. This is a college project for the Mobile Applications Development module at GMIT.

## Requirements

* Well-designed UI that is fit for purpose and provides a good user experience.

* Uses local/roaming storage for storing data and/or settings that are necessary for or
enhance this user experience.
* Demonstrates appropriate use of the sensors/hardware available on UWP capable devices
  * Accelerometer, gyroscope, location services, sound, network service (connect to
server for data), camera, multi touch gestures

* The app must be more than a simple information app. It must have interactivity as part of
the design.

## Design Decisions

The App is using Ticketmaster's API to search events by countryCode and classificationName. 
The API also provides an event details endpoint where you can pass in an event ID and get back the 
details of the event in JSON. 
If you would like to read the documentation regarding the API you 
can do so [here](https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/).

I also used Ticketmaster's API explorer tool to help me understand how the API works and what endpoints there are. 
The API explorer allows you to pass in different parameters to query the API with so you can see what results you get back.
You can use the API explorer yourself by visting this link [here](https://developer.ticketmaster.com/api-explorer/).

The MainPage is a GridView of all the events in your country, there is a SplitView Pane on the left with two ComboBoxes that allow 
you to filter the events by Country or Event type. 

When you click on a event it will bring you to a new page where the event details will be displayed. 
I used the Frame.Navigate method and the OnNavigatedTo method to pass parameters between the two pages. 

When the EventDetailPage is loaded it makes an API call to Ticketmaster's event details endpoint. The page has two Pivot items; Details and Map.
The Details page displays the event image, event name, venue name, start date, event info, venue info and a link to buy the tickets off of ticketmasters website.

            Countries.Add(new Tuple<string, string>("CA", "Canada"));
            Countries.Add(new Tuple<string, string>("AU", "Australia"));
            Countries.Add(new Tuple<string, string>("AT", "Austria"));
            Countries.Add(new Tuple<string, string>("BE", "Belgium"));
            Countries.Add(new Tuple<string, string>("DK", "Denmark"));
            Countries.Add(new Tuple<string, string>("FR", "France"));
            Countries.Add(new Tuple<string, string>("GB", "Great Britain"));
            Countries.Add(new Tuple<string, string>("LU", "Luxembourg"));
            Countries.Add(new Tuple<string, string>("MX", "Mexico"));
            Countries.Add(new Tuple<string, string>("NL", "Netherlands"));
            Countries.Add(new Tuple<string, string>("NZ", "New Zealand"));
            Countries.Add(new Tuple<string, string>("NO", "Norway"));
            Countries.Add(new Tuple<string, string>("PL", "Poland"));
            Countries.Add(new Tuple<string, string>("PT", "Portugal"));
            Countries.Add(new Tuple<string, string>("ES", "Spain"));
            Countries.Add(new Tuple<string, string>("SE", "Sweden"));
            Countries.Add(new Tuple<string, string>("CH", "Switzerland"));

## Supported Countries
| Country Code   | Country |
| :--| :---------------|
| US | United States   |
| IE | Ireland         |
| CA | Canada          |
| AU | Australia       |
| AT | Austria         |
| BE | Belgium         |
| DK | Denmark         |
| FR | France          |
| GB | Great Britain   |

## Demonstration



## Getting Started

To run the application on your local machine you will need to have Visual Studio 2017 installed. 
The App will not run on Visual Studio 2015.

* First you will need to clone the repository

  ```
  git clone https://github.com/lanodburke/Ticket-Tracker.git
  ```
  
* After cloning the repo, change directory to the Ticket-Tracker folder.

  ```
  cd Ticket-Tracker
  ```

* In the Ticket-Tracker folder you will see the file TicketTracker.sln, run the file and open it with Visual Studio 2017.

## Built With. Install the neccessary packages if you are prompted to do so.

* [Ticketmaster API](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Donal Burke** - [lanodburke](https://github.com/lanodburke)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
