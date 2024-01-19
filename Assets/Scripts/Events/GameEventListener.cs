using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A class for event listener
/// </summary>
public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [Space()]
    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        gameEvent.Subscribe(this);
    }

    private void OnDisable()
    {
        gameEvent.Unsubscribe(this);
    }

    public void OnRaise()
    {
        response?.Invoke();
    }
}
