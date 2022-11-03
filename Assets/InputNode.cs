using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNode : Node
{
    protected override NodeType Type => NodeType.Input;

    public Node bound;

    protected override void Bind(Node other)
    {
        if (bound != null) Release();
        bound = other;
        lr.enabled = true;
        UpdateLineStartPosition(transform.position);
        UpdateLineEndPosition(other.transform.position);
        OnMoved += UpdateLineStartPosition;
        other.OnMoved += UpdateLineEndPosition;
    }

    protected override void OnMouseDown()
    {
        if (bound != null) Release();
        base.OnMouseDown();
    }

    void Release()
    {
        OnMoved -= UpdateLineStartPosition;
        bound.OnMoved -= UpdateLineEndPosition;
        bound = null;
    }

    public override bool GetValue()
    {
        if (bound != null)
        {
            return bound.GetValue();
        }
        else
        {
            Debug.Log("Input node not connected");
            return false;
        }
    }
}
