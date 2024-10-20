using CA1.Model;


namespace CA1;
    class Program {
        static List<RaceEvent> events = new List<RaceEvent>();

        static void Main(String[] args) {
            String command;

            do {
                Console.WriteLine("\nHorse Racing Management System");
                Console.WriteLine("1. Create Race Event");
                Console.WriteLine("2. Add Race to Event");
                Console.WriteLine("3. Add Horse to Race");
                Console.WriteLine("4. View Upcoming Events");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                command = Console.ReadLine();

                switch (command) {
                    case "1":
                        CreateRaceEvent();
                        break;
                    case "2":
                        AddRaceToEvent();
                        break;
                    case "3":
                        AddHorseToRace();
                        break;
                    case "4":
                        DisplayUpcomingEvents();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (command != "5");
        }

        private static void CreateRaceEvent() {
            try {
                Console.Write("Enter Event Title: ");
                String title = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(title) || title.Length < 2) {
                    Console.WriteLine("Title of event must be at least 2 characters long.");
                    return;
                }

                Console.Write("Enter Location: ");
                String location = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(location)) {
                    Console.WriteLine("Location cannot be empty.");
                    return;
                }

                var raceEvent = new RaceEvent(title, location, new List<Race>());
                events.Add(raceEvent);
                Console.WriteLine("Race Event created successfully.");
            } catch (ArgumentException ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void AddRaceToEvent() {
            Console.Write("Enter Event Title: ");
            String title = Console.ReadLine();
            var raceEvent = events.FirstOrDefault(e => e.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (raceEvent != null) {
                Console.Write("Enter Race Name: ");
                String raceName = Console.ReadLine();
                Console.Write("Enter Race Start Time (yyyy-mm-dd hh:mm): ");
                DateTime startTime;

                if (!DateTime.TryParse(Console.ReadLine(), out startTime) || startTime <= DateTime.Now) {
                    Console.WriteLine("Invalid start time. Please enter a future date and time.");
                    return;
                }

                var race = new Race(raceName, startTime);
                raceEvent.AddRaceToEvent(race);
                Console.WriteLine("Race added to event successfully.");
            } else {
                Console.WriteLine("Event not found.");
            }
        }

        private static void AddHorseToRace() {
            Console.Write("Enter Event Title: ");
            String title = Console.ReadLine();
            var raceEvent = events.FirstOrDefault(e => e.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (raceEvent != null) {
                Console.Write("Enter Race Name: ");
                String raceName = Console.ReadLine();
                var race = raceEvent.Races.FirstOrDefault(r => r.Name.Equals(raceName, StringComparison.OrdinalIgnoreCase));

                if (race != null) {
                    Console.Write("Enter Horse Name: ");
                    String horseName = Console.ReadLine();
                    Console.Write("Enter Horse Date of Birth (yyyy-mm-dd): ");
                    DateTime dob;

                    if (!DateTime.TryParse(Console.ReadLine(), out dob) || dob >= DateTime.Now) {
                        Console.WriteLine("Invalid date of birth. Please enter a past date.");
                        return;
                    }

                    var horse = new Horse(horseName, dob);
                    race.AddHorse(horse);
                    Console.WriteLine("Horse added to race successfully.");
                } else {
                    Console.WriteLine("Race not found.");
                }
            } else {
                Console.WriteLine("Event not found.");
            }
        }

        private static void DisplayUpcomingEvents() {
            if (events.Count == 0) {
                Console.WriteLine("No upcoming events.");
                return;
            }

            foreach (var raceEvent in events) {
                Console.WriteLine(raceEvent);
            }
        }
    }

