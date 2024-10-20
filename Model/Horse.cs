namespace CA1.Model;
    public class Horse {
        private static int horseIdCounter = 1;  

        private string name;
        private DateTime dateOfBirth;
        private readonly long horseId;  

        public Horse(string name, DateTime date) {
            Name = name;
            Date = date;
            horseId = horseIdCounter++;  
        }

        public string Name {
            get {
                return name;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Horse name cannot be null or empty.");
                }
                if (value.Length < 2) {
                    throw new ArgumentException("Horse name must be at least 2 characters long.");
                }
                name = value;
            }
        }

        public DateTime Date {
            get {
                return dateOfBirth;
            }
            set {
                if (value >= DateTime.Now) {
                    throw new ArgumentException("Horse's date of birth must be in the past.");
                }
                dateOfBirth = value;  
            }
        }

        public long HorseId {
            get {
                return horseId;  
            }
        }

        public override string ToString() {
            return $"Horse ID: {HorseId}, Name: {Name}, Date of Birth: {Date:yyyy-MM-dd}";
        }
    }
