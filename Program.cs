using System;
using OpenQA.Selenium;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        string command = "N";

        while (command != "Y")
        {
            Console.WriteLine("Where are you flying from?");
            string departure = Console.ReadLine();

            Console.WriteLine("Where are you flying to");
            string arrival = Console.ReadLine();

            Console.WriteLine("when do you want to leave MMM dd, yyyy");
            string departureDate = Console.ReadLine();
            departureDate = DateTime.Parse(departureDate).ToString("MMM dd, yyyy");

            Console.WriteLine("# of adults");
            var adultsInput = Console.ReadLine();
            int adults = int.Parse(adultsInput);

            IWebDriver driver = new BrowserDriver("chrome").GetDriver();
            FlightController fc = new FlightController();

            driver.Url = fc.urlGenerator("frontier", departure, arrival, departureDate, adults);

            fc.SearchForElementsByCss(driver, "#flight-section-container", 10);

            System.Threading.Thread.Sleep(2000);    // for raising accuracy

            List<Flight> flightlist = fc.GetFlights(driver, ".ibe-flight-info-container .ibe-flight-info");

            fc.printFlights(flightlist);

            Console.WriteLine("Thanks for using our system, close now? (Y/N)");
            command = Console.ReadLine(); //if Y close the program
        }
    }



}

