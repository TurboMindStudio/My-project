using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float Xpos;
    [SerializeField] Transform newPos;
    

    void Update()
    {
         transform.position += new Vector3(speed*Time.deltaTime,0,0);

         if(transform.position.x>Xpos)
         {

            transform.position=newPos.position;
         }

    }

    
}
