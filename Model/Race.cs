namespace CA1.Model;

public class Race {

    private static int id = 0;
    
    private String name;
    private DateTime startDate;
    private List<Horse> horses;

    public Race(String name, DateTime startDate) {
        id++;
        this.name = name;
        this.startDate = startDate;
    }

    public Race(DateTime startDate) {
        this.name = "Race " + id;
        id++;
        StartDate = startDate;
    }

    public String Name {
        get {
            return name;
        }
        set {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("Race name cannot be null or empty.");
            }
            if (value.Length < 2) {
                throw new ArgumentException("Race name must be at least 2 characters long.");
            }
            name = value;
        }
    }

    public DateTime StartDate {
        get => startDate;
        set {
            if (startDate.CompareTo(DateTime.Now) <= 0) {
                throw new ArgumentException("Start date cannot be earlier than current date.");
            }
            startDate = value;
        }
    }

    public List<Horse> Horses {
        get => horses;
        set {
            if (value == null) {
                throw new ArgumentException("Horses cannot be null.");
            }
            horses = value;
        }
    }

}