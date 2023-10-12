using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;
    public static GameManager instance;
    PlayerController controller;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        controller = PlayerController.instance;
    }
    public void OnSettingInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !settingCanvas.activeSelf)
        {
            settingCanvas.SetActive(true);
            controller.ToggleCursor(true);
        }
        else if (context.phase == InputActionPhase.Started && settingCanvas.activeSelf)
        {
            settingCanvas.SetActive(false);
            controller.ToggleCursor(false);
        }
    }
}
