using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textShown : MonoBehaviour
{
    public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {

        text.text = Managers.textMana.getNextKey();
        string[] temp = Managers.textMana.getChoice();
        Messenger<string[]>.Broadcast(GameEvent.NEXT_WORD,temp);
    }


}
