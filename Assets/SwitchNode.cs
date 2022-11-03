using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchNode : OutputNode
{
    private bool value = false;

    protected override void Start()
    {
        base.Start();
        GetValueExternally = () => value;
    }

    void OnMouseUpAsButton()
    {
        value = !value;
        SetColor(value);
    }
}
