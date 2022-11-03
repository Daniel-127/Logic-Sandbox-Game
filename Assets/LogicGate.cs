using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicGate : Gate
{
    [SerializeField] protected InputNode input1;
    [SerializeField] protected InputNode input2;
    [SerializeField] protected OutputNode output;


    private void Start()
    {
        input1.Gate = this;
        input2.Gate = this;
    }

    public override void Compute()
    {
        output.UpdateValue(ComputeValue());
    }

    protected abstract bool ComputeValue();

}
