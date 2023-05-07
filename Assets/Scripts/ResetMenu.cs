using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMenu : MonoBehaviour
{
    [SerializeField] private GameObject resetMenu;
    public void Reset()
    {
        resetMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        
    }
}
