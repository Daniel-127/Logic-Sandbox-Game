using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNode : Node
{
    public Gate Gate { private get; set; }
    OutputNode bound;
    protected override NodeType Type => NodeType.Input;

    bool flashing = false;

    public override bool GetValue()
    {
        if (bound != null)
        {
            return bound.GetValue();
        }
        else
        {
            //StartCoroutine(FlashRed());
            return false;
        }
    }
    public override void UpdateValue(bool newValue)
    {
        Value = newValue;
        Gate.Compute();
    }

    protected override void Bind(Node other)
    {
        if (bound != null) Release();
        bound = other as OutputNode;
        lr.enabled = true;
        UpdateLineStartPosition(transform.position);
        UpdateLineEndPosition(other.transform.position);
        OnMoved += UpdateLineStartPosition;
        other.OnMoved += UpdateLineEndPosition;
        UpdateValue(bound.GetValue());
    }
    void Release()
    {
        bound.Release(this);
        OnMoved -= UpdateLineStartPosition;
        bound.OnMoved -= UpdateLineEndPosition;
        bound = null;
        UpdateValue(false);
    }

    protected override void UpdateColor()
    {
        if (!flashing) 
        {
            base.UpdateColor();
        }
    }

    protected override void OnMouseDown()
    {
        if (bound != null) Release();
        base.OnMouseDown();
    }


    void UpdateLineStartPosition(Vector3 pos)
    {
        lr.SetPosition(0, (Vector2)pos);
    }

    void UpdateLineEndPosition(Vector3 pos)
    {
        lr.SetPosition(1, (Vector2)pos);
    }

    IEnumerator FlashRed()
    {
        flashing = true;
        for (int i = 0; i < 2; i++)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.25f);
            base.UpdateColor();
            yield return new WaitForSeconds(0.25f);
        }
        flashing = false;
    }

}
