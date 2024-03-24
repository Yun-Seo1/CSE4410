using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Door door;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Debug.Log("Target Hit by Raycast!");
                ShotTarget(); 
            }
        }
    }

    void ShotTarget()
    {
        // Call the ShotTarget method in the Door script
        if (door != null)
        {
            door.ShotTarget();
        }
    }
}


