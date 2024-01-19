/// <summary>
/// An interface for input handler
/// </summary>

public interface IInputHandler
{
    float Horizontal { get; }
    float Vertical { get; }
    bool PlayerIsClicking { get; }
    bool HasForwardInput { get; }
}
