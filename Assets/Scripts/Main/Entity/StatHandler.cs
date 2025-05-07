using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatHandler : MonoBehaviour
{
    [Range(1f, 20f)][SerializeField] private float speed = 8;
    /*[SerializeField]*/ private float runMultiplier = 3f;

    private bool isRunning;

    public float BaseSpeed { get => speed; set => speed = Mathf.Clamp(value, 0, 20); }

    public float Speed => isRunning ? BaseSpeed * runMultiplier : BaseSpeed;

    void OnRun(InputValue inputValue)
    {
        isRunning = inputValue.isPressed;
    }
}
