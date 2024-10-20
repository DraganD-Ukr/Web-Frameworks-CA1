namespace CA1.Model;

public abstract class User {
    public string Name { get; }

    public User(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentException("Name cannot be null or empty.");
        }

        if (name.Length < 2) {
            throw new ArgumentException("Name cannot be less than 2 characters.");
        }
        Name = name;
    }

    public abstract void ViewUpcomingEvents();  // Common functionality for all users
}