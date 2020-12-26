using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpObject: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(gameObject.tag == "Coin")
            {
                GameManager.instance.coin += 100;
            } else if(gameObject.tag == "Diamond")
            {
                GameManager.instance.diamond += 30;
            }
            
            Destroy(gameObject);
        }
    }
}
