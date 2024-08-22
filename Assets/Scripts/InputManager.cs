using UnityEngine;

public class InputManager
{
    private InputControls inputControls;
    
    public Vector2 Movement => inputControls.Player.Movement.ReadValue<Vector2>();

    public InputManager()
    {
        inputControls = new InputControls();
        inputControls.Enable();
    }
}
