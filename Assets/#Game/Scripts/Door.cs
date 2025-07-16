using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int requiredKeys = 2;
    [SerializeField] private CollectionManager collectionManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collectionManager.GetKeyCount() >= requiredKeys)
            {
                for (int i = 0; i < requiredKeys; i++)
                {
                    collectionManager.UseKey();
                }

                OpenDoor();
            }
        }
        else
        {
            Debug.Log($"Need {requiredKeys} keys to open the door. You have {collectionManager.GetKeyCount()}.");
            //ini gatau kenapa debugnya gak nyala
        }
    }
    private void OpenDoor()
    {
        Debug.Log("Door opened!");
        float timeLeft = FindObjectOfType<Timer>().GetRemainingTime();
        int deaths = DeathCountManager.Instance.GetDeathCount();

        FindObjectOfType<ResultWindowController>().ShowResult(timeLeft, deaths, true);
        //Destroy(gameObject);
        //belum nambahin konsidi menang
    }
}
