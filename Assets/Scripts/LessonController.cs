using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectOptions;

    private GameObject new_gameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject new_gameObject =
            Instantiate(objectOptions[0], new Vector3(0.672f, 0.732f, 0.05f), Quaternion.identity, transform);
        new_gameObject.name = "BasketValue";
    }
}
