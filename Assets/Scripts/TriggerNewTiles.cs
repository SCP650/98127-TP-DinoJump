using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNewTiles : MonoBehaviour
{
    public GameObject _tile;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newTile = Instantiate(_tile);
        newTile.transform.position = new Vector3(transform.position.x + 8.5f, transform.position.y - 0.5f, transform.position.z);
    }
}
