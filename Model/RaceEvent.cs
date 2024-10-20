﻿namespace CA1.Model;

public class RaceEvent {
    
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
}