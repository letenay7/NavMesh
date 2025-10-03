using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.AI.Navigation.Samples;

public class MenuScript : MonoBehaviour
{
    enum Mode
    {
        Autonomous,
        Manual
    }
    [SerializeField]
    private Button modeToggle;
    [SerializeField]
    private Button stopButton;
    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private TextMeshProUGUI infoText;
    private Mode currentMode;
    private TextMeshProUGUI buttonText;
    private GameObject avatar;

    private Mover mover;


    void Start()
    {
        buttonText = modeToggle.GetComponentInChildren<TextMeshProUGUI>();
        EnableManualMode();
    }
    private void EnableManualMode()
    {

        currentMode = Mode.Manual;
        buttonText.text = "Autonomous nav";
        joystick.SetActive(true);
        stopButton.gameObject.SetActive(false);
        infoText.text = "You are in manual mode. Use joystick to move";
        avatar = GameObject.FindGameObjectWithTag("Avatar");
        mover = avatar.GetComponent<Mover>();
        mover.StopMovement();
        ToggleNavMeshScript();

    }

    private void EnableAutonomousMode()
    {
        currentMode = Mode.Autonomous;
        buttonText.text = "Manual control";
        joystick.SetActive(false);
        stopButton.gameObject.SetActive(true);
        infoText.text = "You are in autonomous mode. Click to select destination";
        ToggleNavMeshScript();

    }

    public void ToggleModes()
    {
        if (currentMode == Mode.Autonomous)
        {
            EnableManualMode();
        }
        else
        {
            EnableAutonomousMode();
        }
    }

    public void EmergencyStop()
    {
        mover.StopMovement();
    }
    private void ToggleNavMeshScript()
    {
        ClickToMove clickScript = avatar.GetComponent<ClickToMove>();
        if (currentMode == Mode.Autonomous)
        {
            clickScript.enabled = true;
        }
        else
        {
            clickScript.enabled = false;
        }
    }
}
