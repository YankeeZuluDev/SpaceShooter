using UnityEngine;

public class InputHandler : MonoBehaviour, IInputHandler
{
    private float horizontal;
    private float vertical;
    private bool playerIsClicking;
    private bool hasForwardInput;

    public float Horizontal => horizontal;
    public float Vertical => vertical;
    public bool PlayerIsClicking => playerIsClicking;
    public bool HasForwardInput => hasForwardInput;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        playerIsClicking = Input.GetMouseButton(0);
        hasForwardInput = vertical > 0;
    }
}
