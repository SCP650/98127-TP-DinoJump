
public interface IGameManager
{
    ManagerStatus status { get; }
    void Startup(NetworkService network);
}

public enum ManagerStatus
{
    Shutdown,
    Initializing,
    Started
}