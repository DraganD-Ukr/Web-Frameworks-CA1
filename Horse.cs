using System.Runtime.InteropServices.JavaScript;

namespace CA1;

public class Horse {
    
    private static int horseIdCounter = 0;
    
    private String name;
    private DateTime date;
    private long horseId;

    public Horse(String name, DateTime date) {
        Name = name;
        Date = date;
        horseId = HorseId;
    }

    public String Name {
        get => name;
        set {
            if (value == null) {
                throw new ArgumentException("Horse name cannot be null.");
            }
            if (value.Length < 2) {
                throw new ArgumentException("Horse name cannot be less than 2 characters.");
            }
            name = value;
        }
    }

    public DateTime Date {
        get => date;
        set {
            if (DateTime.Now.CompareTo(value) <= 0) {
                throw new ArgumentException("Horse's date of birth cannot be earlier than current date");
            }
        }
    }

    private long HorseId {
        get => horseId;
        set => horseId = horseIdCounter++;
    }
}