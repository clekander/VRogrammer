using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoplight : MonoBehaviour
{
    [SerializeField] Material[] lightsOff;
    [SerializeField] Material[] lightsOn;
    
	private string variablesText;
    private List<int> minLightTime = new List<int>() {1, 2, 3};
    private List<int> maxLightTime = new List<int>() {5, 2, 7};
    private float lightTime;
    private float lightTimer = 0.0f;
    private int currentLight = 2;

    // Start is called before the first frame update
    void Start()
    {
       	lightTime = (float) UnityEngine.Random.Range(minLightTime[currentLight], minLightTime[currentLight]);
	
    }

    // Update is called once per frame
    void Update()
    {
        if (lightTimer > lightTime) {
            Material[] materials = GetComponent<Renderer>().materials;
            materials[currentLight+1] = lightsOff[currentLight];

            currentLight = currentLight - 1 ;
            if (currentLight == -1) { currentLight = 2; }
            materials[currentLight+1] = lightsOn[currentLight];
            GetComponent<Renderer>().materials = materials;

            lightTime = (float) UnityEngine.Random.Range(minLightTime[currentLight], maxLightTime[currentLight]);
			print(lightTime);
            lightTimer = 0.0f;
        }
        else
        {
            lightTimer += Time.deltaTime;
        }
    }
    
    public int GetLight() 
    {
        return currentLight;
    }

    public void ResetCycle()
    {
        currentLight = 2;
        lightTime = (float) UnityEngine.Random.Range(minLightTime[currentLight], minLightTime[currentLight]);
    }


}
