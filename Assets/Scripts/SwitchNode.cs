using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchNode : OutputNode
{
    void OnMouseUpAsButton()
    {
        UpdateValue(!Value);
    }
}
