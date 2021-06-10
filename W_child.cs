using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps W's animation at 0,0,0 of it's parent object.
public class W_child : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float GetYposition()
    {
        return transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, /*GetYposition()*/0, 0);

    }


}
