while (true)
{
    // Asking the user for input
    System.Console.Write("Enter a future time (h:mm AM/PM) or type 'exit' to quit: ");
    string input = System.Console.ReadLine();

    // If the user wants to exit
    if (input.Trim().ToLower() == "exit")
    {
        break;
    }

    // Try to parse the input time
    if (System.DateTime.TryParseExact(input, "h:mm tt", null, System.Globalization.DateTimeStyles.None, out System.DateTime targetTime))
    {
        System.DateTime now = System.DateTime.Now;

        // Set the target time to today
        targetTime = new System.DateTime(now.Year, now.Month, now.Day, targetTime.Hour, targetTime.Minute, 0);

        // Check if the time has already passed
        if (targetTime <= now)
        {
            System.Console.WriteLine("The time has already passed. Try again.\n");
            continue;
        }

        System.Console.WriteLine($"Countdown started from now to {targetTime:hh:mm tt}\n");

        // Start countdown loop
        while (true)
        {
            System.TimeSpan remaining = targetTime - System.DateTime.Now;

            // If countdown reaches zero, break the loop
            if (remaining.TotalSeconds <= 0)
            {
                System.Console.WriteLine("Time reached!\n");
                break;
            }

            // Display the remaining time in hours, minutes, and seconds
            System.Console.Write($"\rTime remaining: {remaining.Hours} hours {remaining.Minutes} minutes {remaining.Seconds} seconds   ");
            System.Threading.Thread.Sleep(1000); // Wait for 1 second before updating
        }
    }
    else
    {
        System.Console.WriteLine("Invalid time format. Please enter a valid time in h:mm AM/PM format.\n");
    }
}