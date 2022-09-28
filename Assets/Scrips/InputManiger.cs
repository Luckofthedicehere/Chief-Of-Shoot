using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManiger : MonoBehaviour
{
    private PlayerInput PlayerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerInput = new PlayerInput();
        onFoot = PlayerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
