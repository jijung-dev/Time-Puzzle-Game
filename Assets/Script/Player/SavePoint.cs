using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private string _savePointID = null;
    public string savePointID => _savePointID;
    public void SetID(string ID)
    {
        _savePointID = ID;
    }
}
