﻿namespace CA1.Model;

public class Race : IRace{

    private static int id = 0;
    
    private String name;
    private DateTime startTime;
    private List<Horse> horses;

    public Race(String name, DateTime startDate) {
        Name = name;
        StartDate = startDate;
        horses = new List<Horse>();
        id++;
    }

    public Race(DateTime startDate) {
        Name = "Race " + id;
        StartDate = startDate;
        horses = new List<Horse>();
        id++;
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
        get => startTime;
        set {
            if (startTime.CompareTo(DateTime.Now) >= 0) {
                throw new ArgumentException("Start date cannot be earlier than current date.");
            }
            startTime = value;
        }
    }

    public List<Horse> Horses {
        get => horses;
        set {
            ArgumentNullException.ThrowIfNull(value, "Horses cannot be null.");
            horses = value;
        }
    }
    

    public void AddListOfHorses(List<Horse> toAdd) {
        Horses = toAdd;
    }

    public void AddHorse(Horse horse) {
        ArgumentNullException.ThrowIfNull(horse, "Horse cannot be null.");
        horses.Add(horse);
    }
    
    public override string ToString(){ 
        
        return $"Race: {Name}, Start Time: {StartDate}, Horses: {string.Join(", ", Horses)}";
        
    }
    
    
    
    
}