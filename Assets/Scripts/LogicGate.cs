using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicGate : Gate
{
    [SerializeField] protected OutputNode output;

    public override void Compute()
    {
        output.UpdateValue(ComputeValue());
    }

    protected abstract bool ComputeValue();

}
