using System;
using UnityEngine;

public class TimeObjectBehaviour : MonoBehaviour
{
    protected int state = 0;
    void Start()
    {
        TimeControlSystem.TimeObjects.Add(this);
    }
    public TimeObject GetSaveInfo()
    {
        return new TimeObject(transform.position, state);
    }
    public void Load(TimeObject timeObject)
    {
        state = timeObject.state;
        transform.position = timeObject.pos;
    }
}
[Serializable]
public class TimeObject
{
    [SerializeField]
    public Vector2 pos = Vector2.zero;
    [SerializeField]
    public int state = 0;

    public TimeObject(Vector2 pos, int state)
    {
        this.pos = pos;
        this.state = state;
    }
}
