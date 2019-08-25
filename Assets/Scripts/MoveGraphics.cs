using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGraphics : MonoBehaviour
{
    Vector3 destination = new Vector3(-150, 0, 0); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void MoveGraphicPosition()
    {
        this.transform.position += destination;
    }
}
