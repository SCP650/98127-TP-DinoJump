using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textShown : MonoBehaviour
{
    public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(Managers.textMana.getNextKey());
        text.text = Managers.textMana.getNextKey();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
