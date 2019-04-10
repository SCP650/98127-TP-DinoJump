using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public List<string> keys = new List<string>();
    public List<string> values = new List<string>();
  
    private Dictionary<string, string> _temp = new Dictionary<string, string>();

    private string _filename;
    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Data Manager Starting...");
        _network = service;
        //_filename = Path.Combine(Application.persistentDataPath,"game.dat");
        //full file path is constructed using Application.persistent- DataPath,
        // a location Unity provides to store data in.exact location differs in different platform
        status = ManagerStatus.Started;
    }

    public Dictionary<string, string> GetDict()
    {
        int i = 0;
        foreach (string tested in keys)
        {   
            _temp.Add(tested, values[i]);
            i++;
        }
        return _temp;
    }

  


    /*
    public void SaveGameState()
    {
        Dictionary<string, object> gamestate = new Dictionary<string, object>();
        gamestate.Add("inventory", Managers.Inventory.GetData());
        gamestate.Add("maxHealth", Managers.Player.health);
        gamestate.Add("curLevel", Managers.mission.curLevel);
        gamestate.Add("maxLevel", Managers.mission.maxLevel);

        FileStream stream = File.Create(_filename);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, gamestate);
        stream.Close();
    }

    public void LoadGameState()
    {
        if (!File.Exists(_filename))
        {
            Debug.Log("No Saved Game");
            return;
        }

        Dictionary<string, object> gamestate;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(_filename,FileMode.Open);
        gamestate = formatter.Deserialize(stream) as Dictionary<string, object>;
        stream.Close();

        Managers.Inventory.UpdateData((Dictionary<string, int>)gamestate["inventory"]);
        Managers.Player.UpdataData((int)gamestate["health"], (int)gamestate["maxHealth"]);
        Managers.mission.UpdateData((int)gamestate["curLevel"], (int)gamestate["maxLevel"]);
        Managers.mission.RestartCurrent();
    }*/
}
