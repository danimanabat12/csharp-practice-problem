// Main program
using System;
namespace BookingApp{
  class Program{
    // Stores all the tickets inputted so far
    static List<Ticket> ticketDetails = new List<Ticket>();
    // Instantiate a TicketBooking object for the main program
    static TicketBooking ticketBooking;
    // Instantiate a Utilities object for the main program
    static Utilities utilities = new Utilities();
    static void Main() 
    {
      // Flagging variable for console interface purposes. 
      bool flag = true;
      while(flag) {
        Console.Clear();
        Console.WriteLine("Ticket Booking Application\n");
        Console.WriteLine("[1] Fill in ticket details");
        Console.WriteLine("[2] Ticket booking");
        Console.WriteLine("[0] Exit program");
        Console.Write("\nOption: ");
        string choice = Console.ReadLine();
        switch(choice) {
          case "1": 
            InputTicket();
            break;
          case "2":
            BookTicket();
            break;
          case "0":
            Console.WriteLine("Bye bye!"); 
            flag = false; 
            break; 
          default: 
            Console.WriteLine("Invalid choice. Press any key to try again."); 
            Console.ReadKey();
            break;
        }
      }
    }

    // Method that allows the user to input a new Ticket object. 
    public static void InputTicket() 
    {
      string ticketId;
      string ticketType; 
      double ticketPrice;
      int ticketTotal;

      Console.Clear();
      while (true) {
        // Prompts the user to input their desired ticket id. 
        ticketId = utilities.inputString("ticket id");
        // Prompts the user if the ticket id they entered already exists. Forces them to try again.
        if (utilities.ExistingInTickets(ticketId, ticketDetails)) {
          Console.WriteLine("Inputted ticket id already exists. Press any key to try again.");
          Console.ReadKey();
        }
        else break;
      }
      
      // Prompts the user to enter other necessary properties for a Ticket object.
      ticketType = utilities.inputString("ticket type");
      ticketPrice = utilities.inputDouble("ticket price");
      ticketTotal = utilities.inputInt("ticket count");
      // Creates the new Ticket object, append them to the master list of tickets, then informs the user.
      ticketDetails.Add(new Ticket(ticketId, ticketType, ticketPrice, ticketTotal, ticketTotal));
      Console.WriteLine("Ticket successfully added.\n");
      
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    // Method that allows the user to perform any of the ticketBooking methods. Provides an interface.
    public static void BookTicket() 
    {
      // Initially checks first if the master list of tickets contains at least 1 element. 
      //  Else, we terminate this method in order to force them to enter a ticket first.
      if (ticketDetails.Count == 0) {
        Console.WriteLine("No tickets at the moment. Please try to input tickets first.\n");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        return;
      }
      // Creates a new TicketBooking object, passing the master list of tickets as constructor.
      ticketBooking = new TicketBooking(ticketDetails);

      bool flag = true;
      while(flag) {
        Console.Clear();
        Console.WriteLine("Options:"); 
        Console.WriteLine("[1] Book tickets");
        Console.WriteLine("[2] Cancel tickets");
        Console.WriteLine("[3] Check booking details");
        Console.WriteLine("[0] Back to main interface");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine(); 
        // Switch case based on the user's choice.
        switch (choice) {
          case "1": 
            ticketBooking.BookTicket();
            break;
          case "2": 
            ticketBooking.CancelTicket();
            break;
          case "3":
            ticketBooking.CheckTicketDetails();
            break;
          case "0":
            return;
          default: 
            Console.WriteLine("Invalid choice. Please press any key to try again");
            Console.ReadKey();
            break;
        }
      }
    }

  }
}
