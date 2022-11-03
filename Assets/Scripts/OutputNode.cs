using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutputNode : Node
{
    readonly ICollection<Node> bounded = new List<Node>();
    protected override NodeType Type => NodeType.Output;
    public override bool GetValue()
    {
        return Value;
    }
    public override void UpdateValue(bool newValue)
    {
        Value = newValue;
        foreach(var bound in bounded)
        {
            bound.UpdateValue(newValue);
        }
    }

    protected override void Bind(Node other)
    {
        bounded.Add(other);
        lr.enabled = false;
    }

    public void Release(Node node)
    {
        bounded.Remove(node);
    }

}
