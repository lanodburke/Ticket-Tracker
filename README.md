# Ticket-Tracker

Universal Windows Application(UWP) that lets users search events in their country and sort them by genre. This is a college project for the Mobile Applications Development module at GMIT.

## Demonstration

![Alt Text](https://media.giphy.com/media/1mgPnZpm30IIorrh9t/giphy.gif)

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
| LU | Luxembourg      |
| MX | Mexico          |
| NL | Netherlands     |
| NZ | New Zealand     |
| NO | Norway          |
| PL | Poland          |
| PT | Portugal        |
| ES | Spain           |
| SE | Sweden          |
| CH | Switzerland     |

## Built With.

* [Ticketmaster API](https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/) - The API used
* [UWP](https://docs.microsoft.com/en-us/windows/uwp/) - Universal Windows Platform
* [JSON2CSHARP](http://json2csharp.com/) - JSON to C# convertor

## Authors

* **Donal Burke** - [lanodburke](https://github.com/lanodburke)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
