using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbNode : InputNode
{
    public override void UpdateValue(bool newValue)
    {
        Value = newValue;
    }
}
