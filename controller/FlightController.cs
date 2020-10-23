using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

class FlightController
{
    public IWebElement SearchForElementsByCss(IWebDriver driver, string selector, int timeInSecond)
    {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSecond))
            .Until
            (drv => drv.FindElement(By.CssSelector(selector)));
    }

    public List<Flight> GetFlights(IWebDriver driver, string selector)
    {
        List<Flight> flightList = new List<Flight>();

        var flights = driver.FindElements(By.CssSelector(selector));

        foreach (var flight in flights)
        {
            string departure = (flight.FindElement(By.CssSelector(".depart-station-name"))).Text;
            string departureTime = (flight.FindElement(By.CssSelector(".ibe-flight-select-time"))).Text;

            string arrival = (flight.FindElement(By.CssSelector(".ibe-flight-time-arrive .ibe-color-gray"))).Text;
            string arrivalTime = (flight.FindElement(By.CssSelector(".ibe-flight-time-arrive .ibe-flight-select-time"))).Text;

            string flightNumber = (flight.FindElement(By.CssSelector(".ibe-flight-duration-flightslink"))).Text;

            string fare = (flight.FindElement(By.CssSelector(".ibe-farebox-fare-select"))).Text;

            string flightType = (flight.FindElement(By.CssSelector(".ibe-flight-duration-stops"))).Text;

            flightList.Add(new Flight(departure, arrival, departureTime, arrivalTime, flightNumber, fare, flightType));
        }

        return flightList;
    }

    public void printFlights(List<Flight> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("no flights found for today");
            return;
        }
        else
        {
            Console.WriteLine("===================================== FLIGHT LIST =====================================");
            foreach (Flight flight in list)
            {
                Console.WriteLine($"[{flight.getFlightNumber()}] {flight.getDeparture()} --> {flight.getArrival()} ({flight.getDepartureTime()} ---({flight.getFlightType()})---> {flight.getArrivalTime()}) --> {flight.getFare()}");
            }
            Console.WriteLine("========================================= END =========================================");
        }

    }

    public string urlGenerator(string carrier, string departure, string arrival, string departureDate, int adults)
    {
        if (carrier.Equals("frontier"))
        {
            return $"https://booking.flyfrontier.com//Flight/InternalSelect?o1={departure}&d1={arrival}&dd1= {departureDate}&ADT={adults}";
        }

        return "";
    }
}