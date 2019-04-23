using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dead!!!!!");
        if (collision.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
            Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
        }
    }
}
