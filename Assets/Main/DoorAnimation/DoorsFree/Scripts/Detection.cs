using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour
{
   
    public string Character = "e";

    void Start()
    {

        gameObject.name = "Player";
        gameObject.tag = "Player";

    }


   private IEnumerator AutoCloseDoor(Collision hit)
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(hit.collider.GetComponent<Door>().Move());


    }
    private void OnCollisionStay(Collision hit)
    {
        if (hit.collider.tag == "Door")
        {
          
            // Give the object that was hit the name 'Door'
            GameObject Door = hit.transform.gameObject;

            // Get access to the 'Door' script attached to the object that was hit
            Door dooropening = Door.GetComponent<Door>();

            if (Input.GetKey(Character))
            {
                // Open/close the door by running the 'Open' function found in the 'Door' script
                if (dooropening.RotationPending == false) StartCoroutine(hit.collider.GetComponent<Door>().Move());


               // if (dooropening.RotationPending == false)  AutoCloseDoor(hit);
                
            }
        }
    }

}
