using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class LearnController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI variablesLessonsText;

    [SerializeField] private GameObject lessonMenu;
    [SerializeField] private GameObject entryMenu;
    [SerializeField] private GameObject endMenu;
    private List<string> texts = new List<string>() {"Ints: whole numbers \nex: 1, 8, 25", "Doubles: numbers with a decimal point \nex: 2.0, 25.18, 193.66", "Strings: combinations of letters, numbers, ect. \nex: \"Hello World\", \"Goodbye\"", "Booleans \nThere are only two values for booleans, true and false"};
    private List<int> variableTypesLookedAt = new List<int>(4);
    private int numVarsLookedAt = 0;
    private bool allFound = false;

    public void SetEduText(int variableType)
    {
        bool found = false;
        foreach(var vals in variableTypesLookedAt)
        {
            if (variableType == vals)
            {
                found = true;
            }
        }

        if (!found)
        {
            variableTypesLookedAt.Add(variableType);
            numVarsLookedAt += 1;
        }

        if (numVarsLookedAt == 4)
        {
            entryMenu.SetActive(false);
            endMenu.SetActive(true);
        }
        
        if (lessonMenu.activeSelf)
        {
            lessonMenu.SetActive(false);
        }
        else
        {
            variablesLessonsText.text = texts[variableType];
            lessonMenu.SetActive(true);
        }
    }

    public void NextLevel()
    {
        endMenu.SetActive(false);
        StateNameController.writeGameVariables = true;
        SceneManager.LoadScene("RedGreenLight");
    }
}
