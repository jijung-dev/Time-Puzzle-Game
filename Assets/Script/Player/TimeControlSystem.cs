using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimeControlSystem : MonoBehaviour
{
    public static List<TimeObjectBehaviour> TimeObjects = new List<TimeObjectBehaviour>();
    private string _selectedSaveID = null;
    [SerializeField]
    private List<Save> saves = new List<Save>();
    [SerializeField]
    private GameObject savePointObj;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, LayerMask.GetMask("SavePoint"));
            if (hit.collider != null)
                _selectedSaveID = hit.collider.GetComponent<SavePoint>().savePointID;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Load(_selectedSaveID);
        }
    }

    void Save()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.5f, LayerMask.GetMask("SavePoint"));
        if (hit.collider != null)
        {   
            OverwriteSave(hit.collider.GetComponent<SavePoint>());
        }
        string GUID = Guid.NewGuid().ToString();
        SavePoint save = Instantiate(savePointObj, transform.position, Quaternion.identity).GetComponent<SavePoint>();
        save.SetID(GUID);

        List<TimeObject> tempTOList = new List<TimeObject>();
        foreach (TimeObjectBehaviour item in TimeObjects)
        {
            tempTOList.Add(item.GetSaveInfo());
        }
        saves.Add(new Save(tempTOList, GUID, save.gameObject));
    }
    void OverwriteSave(SavePoint savePoint)
    {
        Debug.Log("Overwritten");
        Save save = saves.FirstOrDefault(r => r.saveID == savePoint.savePointID);
        saves.Remove(save);
        Destroy(save.savePointObj);
    }
    void Load(string saveID)
    {
        if (saves.Count <= 0) return;
        Save save = saves.FirstOrDefault(r => r.saveID == saveID);

        for (int i = 0; i < TimeObjects.Count; i++)
        {
            TimeObjects[i].Load(save.timeObjects[i]);
        }
        saves.Remove(save);
        Destroy(save.savePointObj);
    }
}
[Serializable]
public class Save
{
    [SerializeField]
    private List<TimeObject> _timeObjects = new List<TimeObject>();
    private string _saveID = null;
    private GameObject _savePointObj;
    public List<TimeObject> timeObjects => _timeObjects;
    public string saveID => _saveID;
    public GameObject savePointObj => _savePointObj;
    public Save(List<TimeObject> objects, string ID, GameObject savePointObj)
    {
        _timeObjects = objects;
        _saveID = ID;
        _savePointObj = savePointObj;
    }
}
