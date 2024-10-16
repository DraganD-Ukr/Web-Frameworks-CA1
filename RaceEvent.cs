namespace CA1;

public class RaceEvent {
    
    private String title;
    
    private String location;
    
    private List<Race> races;

    public RaceEvent(String title, String location, List<Race> races) {
        
    }

    public string Title {
        get => title;
        set => title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Location {
        get => location;
        set => location = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Race> Races {
        get => races;
        set => races = value ?? throw new ArgumentNullException(nameof(value));
    }
}