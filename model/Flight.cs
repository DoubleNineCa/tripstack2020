
class Flight
{
    string departure;
    string arrival;

    string departureTime;

    string arrivalTime;

    string flightNumber;

    string fare;

    string flightType;

    public Flight()
    {

    }
    public Flight(string departure, string arrival, string departureTime, string arrivalTime, string flightNumber, string fare, string flightType)
    {
        this.departure = departure;
        this.arrival = arrival;
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime;
        this.flightNumber = flightNumber;
        this.fare = fare;
        this.flightType = flightType;
    }

    public string getDeparture()
    {
        return this.departure;
    }

    public string getDepartureTime()
    {
        return this.departureTime;
    }

    public string getArrival()
    {
        return this.arrival;
    }

    public string getArrivalTime()
    {
        return this.arrivalTime;

    }

    public string getFlightNumber()
    {
        return this.flightNumber;
    }

    public string getFare()
    {
        return this.fare;
    }

    public string getFlightType()
    {
        return this.flightType;
    }
}