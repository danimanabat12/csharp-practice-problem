using System;

namespace BookingApp{
  class Ticket {
    // Properties for Ticket class based on the specification
    public string ticketId;
    public string ticketType; 
    public double ticketPrice; 
    public int ticketAvailability; 
    // Added the ticketTotal property in order to store the total tickets available. 
    // This will help us in finding how many tickets has been booked.
    public int ticketTotal;

    // Empty constructor 
    public Ticket() {
      this.ticketId = "";
      this.ticketType = "";
      this.ticketPrice = 0.0; 
      this.ticketAvailability = 0;
      this.ticketTotal = 0;
    }
    // Parameterized constructor
    public Ticket (string ticketId, string ticketType, double ticketPrice, int ticketTotal, int ticketAvailability) {
      this.ticketId = ticketId; 
      this.ticketType = ticketType; 
      this.ticketPrice = ticketPrice; 
      this.ticketTotal = ticketTotal;
      this.ticketAvailability = ticketAvailability;
    }
  }
}