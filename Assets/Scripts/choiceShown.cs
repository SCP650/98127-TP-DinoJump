using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choiceShown : MonoBehaviour
{   
    
    public int ButtonNum;

    private void Awake()
    {
        Messenger<string[]>.AddListener(GameEvent.NEXT_WORD,updateChoice);
    }

    private void OnDestroy()
    {
        Messenger<string[]>.RemoveListener(GameEvent.NEXT_WORD,updateChoice);
    }
    private void updateChoice(string[] choices)
    {
        GetComponentInChildren<Text>().text = choices[ButtonNum];
    }

    public void ButtonDown()
    {   
        if (Managers.textMana.IsCorrectChoice(ButtonNum))
        {
            Debug.Log("true");
            Managers.Player.PlayerJump();
        }
        Debug.Log("False");
    }
}
