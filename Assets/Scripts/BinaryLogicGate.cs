using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BinaryLogicGate : LogicGate
{
    [SerializeField] protected InputNode input1;
    [SerializeField] protected InputNode input2;
    private void Start()
    {
        input1.Gate = this;
        input2.Gate = this;
    }
}
