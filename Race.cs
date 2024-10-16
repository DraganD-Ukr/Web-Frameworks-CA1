namespace CA1;

public class Race {

    public static int id = 0;
    
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
        StartDate = startDate;
    }

    public String Name {
        get => name;
        set => name = value;
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
        set => horses = value;
    }

}