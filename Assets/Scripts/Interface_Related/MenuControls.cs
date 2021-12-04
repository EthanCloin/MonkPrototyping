using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Transform camTransform;
    public Transform menuTransform;
    public bool isVisible;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = cam.transform;
        menuTransform = transform;
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // keep menu in front of camera
        menuTransform.position = new Vector3(
            camTransform.position.x,
            camTransform.position.y,
            camTransform.position.z + 10);

        // hide menu based on isVisible 
        if (isVisible)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
