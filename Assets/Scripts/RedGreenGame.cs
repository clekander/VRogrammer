using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RedGreenGame : MonoBehaviour
{
    private GaitLocomotion gaitControl;
    private Stoplight stopLight;
    private GameObject player;
    private CharacterController cc;

    private Transform playerHead;
    [SerializeField] private Transform resetTransform;
    [SerializeField] private Transform finishLine;
    private bool gamePlaying = true;

    private bool writeVariables;
    private List<string> lightText = new List<string>() { "bool red_light = true \nbool yellow_light = false \nbool green_light = false", "bool red_light = false \nbool yellow_light = true \nbool green_light = false","bool red_light = false \nbool yellow_light = false \nbool green_light = true"};
    public TextMeshProUGUI lightDisplay;
    public TextMeshProUGUI speedDisplay;
    public TextMeshProUGUI stepsDisplay;
    
    [SerializeField] private GameObject resetMenu;
    [SerializeField] private GameObject nextLevelMenu;
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private GameObject[] variables;

     
    // Start is called before the first frame update
    void Awake()
    {
        writeVariables = StateNameController.writeGameVariables;

        player = GameObject.FindGameObjectWithTag("Player");
        playerHead = Camera.main.transform;
        cc = player.GetComponent<CharacterController>();
        gaitControl = player.GetComponent<GaitLocomotion>();
        stopLight = GameObject.FindGameObjectWithTag("StopLight").GetComponent<Stoplight>();
        resetMenu.SetActive(false);
        ResetPlayer();
        if (writeVariables)
        {
            lightDisplay.text = lightText[stopLight.GetLight()];
            speedDisplay.text = "bool player_running = " + gaitControl.IsMoving();
            stepsDisplay.text = "int steps_count = " + gaitControl.GetTotalSteps();
        }
        else
        {
            foreach(var variable in variables)
            {
                variable.SetActive(false);
            }
        }

    }

    // Update is called once per frame

    void Update()
    {
        if (stopLight.GetLight() == 0 && gaitControl.IsMoving() && gamePlaying == true)
        {
            gamePlaying = false;
            gaitControl.enabled = false;
            resetMenu.SetActive(true);
        }
        else if (player.transform.position.z > finishLine.position.z)
        {
            gaitControl.enabled = false;
            gamePlaying = false;
            if (!writeVariables)
            {
                nextLevelMenu.SetActive(true);
            }
            else
            {
                endGameMenu.SetActive(true);
            }
        }
        
        if (writeVariables)
        {
            lightDisplay.text = lightText[stopLight.GetLight()];
            speedDisplay.text = "bool player_running = " + gaitControl.IsMoving();
            stepsDisplay.text = "int steps_count = " + gaitControl.GetTotalSteps();
        }
    }
    

    public void ResetPlayer()
    {
        cc.enabled = false;

        var rotationAngleY = playerHead.rotation.eulerAngles.y - resetTransform.rotation.eulerAngles.y;
        player.transform.Rotate(0, -rotationAngleY, 0);

        var distanceDiff = resetTransform.position - playerHead.transform.position;
        player.transform.position += new Vector3(resetTransform.position.x - playerHead.transform.position.x, 0.0f, resetTransform.position.z - playerHead.transform.position.z);
        cc.enabled = true;
    }

    public void resetGame()
    {
        Time.timeScale = 1f;
        gamePlaying = true;
        stopLight.ResetCycle();
        gaitControl.enabled = true;
        gaitControl.ResetSteps();
        ResetPlayer();
        resetMenu.SetActive(false);

    }
    
}
