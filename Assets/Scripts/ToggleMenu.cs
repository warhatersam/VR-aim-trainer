using UnityEngine;
using UnityEngine.InputSystem;
public class ToggleMenu: MonoBehaviour
{
    public InputActionReference input;
    public GameObject Menu;
    void Update()
    {
        if (input.action.IsPressed())
        {
            Debug.Log("Pressed");
            Menu.SetActive(!Menu.activeSelf);
        }
    }
}
