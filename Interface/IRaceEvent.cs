namespace CA1.Model;

public interface IRaceEvent {
    
    
    void AddRaceToEvent(Race race); 
    
    void RemoveRaceFromEvent(Race race);
    
    List<Race> GetAllRaces();
    
    
}