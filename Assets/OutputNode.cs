using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutputNode : Node
{
    protected override NodeType Type => NodeType.Output;

    public Func<bool> GetValueExternally { private get; set; }

    public override bool GetValue()
    {
        return GetValueExternally();
    }

    protected override void Bind(Node other)
    {
        lr.enabled = false;
    }
}
