using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : LogicGate
{
    [SerializeField] protected InputNode input;

    protected override bool ComputeValue()
    {
        return !input.GetValue();
    }

    private void Start()
    {
        input.Gate = this;
    }
}
