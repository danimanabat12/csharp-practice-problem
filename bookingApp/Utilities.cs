using System;

namespace BookingApp{
  class Utilities {

    // Allows the user to input a string
    public string inputString (string keyword) {
      string var;
      while (true) {
          Console.Write($"Enter {keyword}: ");
          var = Console.ReadLine();
          if(var == "") {
            Console.WriteLine("Empty input for ticket id is detected. Press any key to try again.");
            Console.ReadKey();
          }
          else break;
      }
      return var;
    }

    // Allows the user to input a value for a variable with double data type
    public double inputDouble (string keyword) {
      double var;
      while (true) {
        Console.Write($"Enter {keyword}: ");
        try {
          var = Double.Parse(Console.ReadLine());
          break; 
        } catch {
          Console.WriteLine($"Invalid input for {keyword} is detected. Press any key to try again.");
          Console.ReadKey();
        }
      }
      return var;
    }

    // Allows the user to input an int value
    public int inputInt (string keyword) {
      int var;
      while (true) {
        Console.Write($"Enter {keyword}: ");
        try {
          var = Int32.Parse(Console.ReadLine());
          break; 
        } catch {
          Console.WriteLine($"Invalid input for {keyword} is detected. Press any key to try again.");
          Console.ReadKey();
        }
      }
      return var;
    }

    // Allows the useer to check whether an id exists on a list of Ticket objects.
    public bool ExistingInTickets(string id, List<Ticket> list) {
      foreach (Ticket detail in list) {
        if (detail.ticketId == id) return true;
      }
      return false;
    }

    // Allows the user to check if a ticken really exists in the master list of tickets. Return the ticket if they exist. Else, return null.
    public Ticket GetTicketById(string id, List<Ticket> list) {
      foreach (Ticket currentTicket in list) {
        if (currentTicket.ticketId == id) return currentTicket;
      }
      return null;
    }

    // Allows the user to update the availability of the tickets.
    public void updateTicketAvailability(List<Ticket> list, Ticket ticket) {
      for (int i = 0; i < list.Count(); i++) {
        if (list[i].ticketId == ticket.ticketId) {
          list[i] = ticket;
        }
      }
    }
  }
}