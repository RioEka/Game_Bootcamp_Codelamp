using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public CollectionManager collectionManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collectionManager.GetKeyCount() > 0)
            {
                collectionManager.UseKey();
                OpenDoor();
            }
        }
        else
        {
            Debug.Log("Need key to open the door");
        }
    }
    private void OpenDoor()
    {
        Debug.Log("Door opened!");
        //Destroy(gameObject);
        //belum nambahin konsidi menang
    }
}
