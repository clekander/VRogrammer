using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroController : MonoBehaviour
{
    [SerializeField] typewriterUI typing;

    private float timeBeforeTransition = 5.0f;

    private float timer = 0.0f;

    private bool typingEnd = false;
    // Update is called once per frame
    void Update()
    {
        if (!typingEnd && typing.GetFinished())
        {
            timer = 0.0f;
            typingEnd = true;
        }

        else if (typingEnd && timer > timeBeforeTransition)
        {
            StateNameController.writeGameVariables = false;
            SceneManager.LoadScene("RedGreenLight");
        }
        timer += Time.deltaTime;
    }
}
