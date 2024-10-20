namespace CA1.Model;

public class RaceEvent : IRaceEvent {
    
    private String title;
    
    private String location;
    
    private List<Race> races;

    public RaceEvent(String title, String location, List<Race> races) {
        Title = title;
        Location = location;
        Races = races;
    }

    public string Title {
        get => title;
        set {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("Title of event cannot be null or empty.");
            }
            if (value.Length < 2) {
                throw new ArgumentException("Title of event must be at least 2 characters long.");
            }
            title = value;
        }
    }

    public string Location {
        get => location;
        set {
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentException("Location of event cannot be null or empty.");
            }
            if (value.Length < 5) {
                throw new ArgumentException("Location of event must be at least 2 characters long.");
            }
            location = value;
        }
    }

    public List<Race> Races {
        get => races;
        set => races = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void AddRaceToEvent(Race race) {
        ArgumentNullException.ThrowIfNull(race);
        races.Add(race);
    }

    public void RemoveRaceFromEvent(Race race) {
        ArgumentNullException.ThrowIfNull(race);
        races.Remove(race);
    }

    public List<Race> GetAllRaces() {
        return Races.ToList();
    }
    
    public override string ToString(){
        
        return $"Race Event: {Title}\nLocation: {Location}\nRaces: {string.Join("\n", Races)}";
        
    }
}