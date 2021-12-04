using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRaftScript : MonoBehaviour
{
    public Transform crate;
    // Start is called before the first frame update
    void Start()
    {
        crate = GameObject.FindGameObjectWithTag("crate").transform;  //I tagged the crate object with the crate tag
    }

    private void LateUpdate()
    {
       //store current camera position in temp
        Vector3 temp = transform.position;

        temp.x = crate.position.x; //set camera to x position of crate

        //set back the cameras temp position to the cameras position
        transform.position = temp;
    }
}//end class
