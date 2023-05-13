using System;

namespace BookingApp{
  class TicketBooking {

    private List<Ticket> tickets;

    public TicketBooking(List<Ticket> tickets) {
      this.tickets = tickets;
    }
    // Instantiates a Utilities object.
    private static Utilities utilities = new Utilities();

    // Booking tickets method.
    public void BookTicket() {
      Console.Clear();
      string ticketId;
      int ticketsToBook;
      Ticket ticket;
      while (true) {
          ticketId = utilities.inputString("ticket id");

          // Check first if the ticket even exists. If not, prompt the user again to enter a ticket that does exist.
          ticket = utilities.GetTicketById(ticketId, tickets);
          if (ticket == null) {
            Console.WriteLine("Inputted ticket id does not exists. Press any key to try again.");
            Console.ReadKey();
          }
          else break;
      }
      // Prompt the user to enter the number of ticket they want to book.
      ticketsToBook = utilities.inputInt("number of tickets to book");
      // Check if the ticketsToBook is still available.
      if (ticketsToBook <= ticket.ticketAvailability) {
        Console.Write("Tickets have been booked");
        ticket = new Ticket(ticket.ticketId, ticket.ticketType, ticket.ticketPrice, ticket.ticketTotal, ticket.ticketAvailability - ticketsToBook);
        utilities.updateTicketAvailability(tickets, ticket);
      }
      // If not available, inform the user as well as the current ticket available.
      else {
        Console.WriteLine($"Booking cannot be processed. Current ticket available: {ticket.ticketAvailability}");
      }
      Console.ReadKey();
      return;
    }

    // Cancelling tickets method.
    public void CancelTicket() {
      Console.Clear();
      string ticketId;
      int ticketsToCancel;
      Ticket ticket;
      while (true) {
          // Prompts the user to enter the ticket id.
          ticketId = utilities.inputString("ticket id");
          // Checks if the ticket really exists. If not, it will prompt the user to enter a valid ticket id.
          ticket = utilities.GetTicketById(ticketId, tickets);
          if (ticket == null) {
            Console.WriteLine("Inputted ticket id does not exists. Press any key to try again.");
            Console.ReadKey();
          }
          else break;
      }
      // Prompts the user to enter the number of ticket they want to cancel
      ticketsToCancel = utilities.inputInt("number of tickets to cancel");
      // Check if the number of ticket that a user want to cancel coincides with the total number of booked tickets.
      if (ticketsToCancel <= ticket.ticketTotal - ticket.ticketAvailability) {
        Console.WriteLine("Tickets has been cancelled");
        ticket = new Ticket(ticket.ticketId, ticket.ticketType, ticket.ticketPrice, ticket.ticketTotal, ticket.ticketAvailability + ticketsToCancel);
        utilities.updateTicketAvailability(tickets, ticket);
      }
      // If it violates the rules, inform the user.
      else {
        Console.WriteLine($"Canceling cannot be processed. Overall booked tickets: {ticket.ticketTotal - ticket.ticketAvailability}, you are trying to cancel {ticketsToCancel}.");
      }
      Console.ReadKey();
    }

    // Print ticket details method
    public void CheckTicketDetails() {
      Console.Clear();
      string ticketId;
      Ticket ticket;
      while (true) {
          // Prompts the user to enter the ticket id.
          ticketId = utilities.inputString("ticket id");
          // Check if the ticket exists.
          ticket = utilities.GetTicketById(ticketId, tickets);
          if (ticket == null) {
            Console.WriteLine("Inputted ticket id does not exists. Press any key to try again.");
            Console.ReadKey();
          }
          else break;
      }
      // If the ticket exists, we print the necessary details.
      Console.WriteLine("\nTicket info");
      Console.WriteLine("============");
      Console.WriteLine($"Ticket id: {ticket.ticketId}");
      Console.WriteLine($"Ticket type: {ticket.ticketType}");
      Console.WriteLine($"Ticket price: {ticket.ticketPrice}");
      Console.WriteLine($"Ticket availability: {ticket.ticketAvailability}\n");

      Console.WriteLine("Press any key to continue");
      Console.ReadKey();
    }
  }
}