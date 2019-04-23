using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerNewTiles : MonoBehaviour
{   

    public GameObject _tile;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int diff = 9 - (int)( Time.time * 0.1);
        if (diff< 7)
        {
            diff = 7;
        }
        GameObject newTile = Instantiate(_tile);
        newTile.transform.position = new Vector3(transform.position.x + diff, transform.position.y - 0.5f, transform.position.z);
    }
}
