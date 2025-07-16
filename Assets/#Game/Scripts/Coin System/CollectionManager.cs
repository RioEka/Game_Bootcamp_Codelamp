using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour
{
    //whiskas gajadi ditampilin
    //public TextMeshProUGUI whiskasUI;
    //int numWhiskasCollected = 0;

    public TextMeshProUGUI keyUI;
    int numKeyCollected = 0;

    private void OnEnable()
    {
        //Whiskas.OnWhiskasCollected += WhiskasCollected;
        Key.OnKeyCollected += KeyCollected;
    }

    private void OnDisable()
    {
        //Whiskas.OnWhiskasCollected -= WhiskasCollected;
        Key.OnKeyCollected -= KeyCollected;
    }

    //private void WhiskasCollected()
    //{
    //    numWhiskasCollected++;
    //    whiskasUI.text = numWhiskasCollected.ToString();
    //}

    private void KeyCollected()
    {
        numKeyCollected++;
        keyUI.text = numKeyCollected.ToString();
    }

    //buat ngecek Door
    public int GetKeyCount()
    {
        return numKeyCollected;
    }

    public void UseKey()
    {
        if (numKeyCollected > 0)
        {
            numKeyCollected--;
            keyUI.text = numKeyCollected.ToString();
        }
    }
}

