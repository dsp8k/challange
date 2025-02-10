// See https://aka.ms/new-console-template for more information
while (true)
{
    // asking the user for input
    Console.Write("Enter a future time (HH:mm) or type 'exit' to quit: ");
    string input = Console.ReadLine();

    // if the user wants to exit
    if (input.Trim().ToLower() == "exit")
    {
        break;
    }



    

    // Spliting the input into hours and minutes
    string[] timeParts = input.Split(':');
    if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hours) && int.TryParse(timeParts[1], out int minutes))
    {
        // Validate hours and minutes
        if (hours >= 0 && hours < 24 && minutes >= 0 && minutes < 60)
        {
            DateTime now = DateTime.Now;
            DateTime targetTime = new DateTime(now.Year, now.Month, now.Day, hours, minutes, 0);

            // Check if the time has already passed
            if (targetTime <= now)
            {
                Console.WriteLine("The time has already passed. Try again.\n");
                continue;
            }

            Console.WriteLine($"Countdown started for {targetTime:HH:mm}\n");

            // Start countdown loop
            while (true)
            {
                TimeSpan remaining = targetTime - DateTime.Now;

                // If countdown reaches zero, break the loop
                if (remaining.TotalSeconds <= 0)
                {
                    Console.WriteLine("Time reached!\n");
                    break;
                }

                // Display the remaining time in minutes and seconds
                Console.Write($"Time remaining: {remaining.Minutes} minutes {remaining.Seconds} seconds\r");
                Thread.Sleep(1000); // Wait for 1 second before updating
            }
        }
        else
        {
            Console.WriteLine("Invalid time format. Please enter a valid time in HH:mm format.\n");
        }
    }
    else
    {
        Console.WriteLine("Invalid time format. Please enter a valid time in HH:mm format.\n");
    }
}
