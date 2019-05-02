using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Text youdied;
    private void Awake()
    {
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, PlayerDead);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, PlayerDead);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

  

    public void PlayerDead()
    {
        string key = Managers.textMana.GetCurrentKey();

        string temp = "You Here Killed By \n" + key + "!! \n" + key + " means " + Managers.textMana.GetCorrectChoice();


        youdied.text = temp;
        gameObject.SetActive(true);
    }
}
