using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeControlSystem : MonoBehaviour
{
    public static List<TimeObjectBehaviour> TimeObjects = new List<TimeObjectBehaviour>();
    [SerializeField]
    private List<Save> Saves = new List<Save>();
    public static event EventHandler OnSave;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Load(0);
        }
    }

    void Save()
    {
        List<TimeObject> tempTOList = new List<TimeObject>();
        foreach (TimeObjectBehaviour item in TimeObjects)
        {
            tempTOList.Add(item.GetSaveInfo());
        }
        Saves.Add(new Save(tempTOList));
    }
    void Load(int saveID)
    {
        for (int i = 0; i < TimeObjects.Count; i++)
        {
            if (Saves.Count > 0)
                TimeObjects[i].Load(Saves[saveID].timeObjects[i]);
        }
        Saves.RemoveAt(saveID);

    }
}
[Serializable]
public class Save
{
    [SerializeField]
    private List<TimeObject> _timeObjects = new List<TimeObject>();
    public List<TimeObject> timeObjects { get => _timeObjects; }
    public Save(List<TimeObject> objects)
    {
        _timeObjects = objects;
    }
}
