using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventData : ComponentData
{
    public int target;
    public int button;
    public string eventKey;

    public ButtonEventData( ButtonEvent be ) : base( be, "buttonEvent" )
    {
        target = be.target.GetInstanceID();
        button = be.button.GetInstanceID();
        eventKey = be.eventKey;
    }
}
