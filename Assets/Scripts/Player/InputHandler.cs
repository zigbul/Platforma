using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    public float HorizontalInput { get; private set; }

    public bool JumpPressed { get; private set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        JumpPressed = Input.GetButtonDown(Jump);
    }
}
