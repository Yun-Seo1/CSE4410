using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorClosed, doorOpened, intIcon;
    public float openTime;

    private bool targetsShot = false;
    private int shotTargetsCount = 0;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            if (!targetsShot && Input.GetKeyDown(KeyCode.E))
            {
                intIcon.SetActive(false);
                doorClosed.SetActive(false);
                doorOpened.SetActive(true);
                StartCoroutine(closeDoor());
            }
        }
    }

    IEnumerator closeDoor()
    {
        yield return new WaitForSeconds(openTime);
        doorOpened.SetActive(false);
        doorClosed.SetActive(true);
    }

    public void ShotTarget()
    {
        shotTargetsCount++;
        Debug.Log("Shot targets count: " + shotTargetsCount);

        if (!targetsShot && shotTargetsCount >= 3)
        {
            targetsShot = true;
            // Debug.Log("Opening door...");
            OpenDoor(); 
        }
    }


    // Method to open the door
    public void OpenDoor()
    {
        doorClosed.SetActive(false);
        doorOpened.SetActive(true);
    }

    public void ResetDoor()
    {
        targetsShot = false;
        shotTargetsCount = 0;
        doorClosed.SetActive(true);
        doorOpened.SetActive(false);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
        }
    }
}






