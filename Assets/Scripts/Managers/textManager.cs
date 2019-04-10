using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class textManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    private int _len;
    private int _funValue;
    private string[] _nextChoices;
    private Dictionary<string,string> _currentDict;
    private List<string> _keys;
    private List<string> _values;

    public void Startup(NetworkService network)
    {
        Debug.Log("Text is starting up...");
        _network = network;
        _currentDict = Managers.dataMana.GetDict();
        _values = Managers.dataMana.values;
        _keys = Managers.dataMana.keys;
        _len = _currentDict.Count;
        status = ManagerStatus.Started;
    }
    //return the key that player need to do
    public string getNextKey()
    {
        _funValue = Random.Range(0, _len-1);
   
        return _keys[_funValue];
    }
    //return 3 choices that palyer can choose, one of them is the correct one
    public string[] getChoice()
    {
        string rightAns = _values[_funValue];

        int notFun1 = 0;
        int notFun2 = 0;
        while(notFun1 == _funValue)
        {
            notFun1 = Random.Range(0,_len-1);
        }
        string wongAns1 = _values[notFun1];

        while (notFun2 == _funValue || notFun2 == notFun1)
        {
            notFun2 = Random.Range(0, _len - 1);
        }
        string wongAns2 = _values[notFun2];
        _nextChoices[0] = rightAns;
        _nextChoices[1] = wongAns1;
        _nextChoices[2] = wongAns2;

        System.Random rnd = new System.Random();
        return _nextChoices.OrderBy(x => rnd.Next()).ToArray();
    }


}
