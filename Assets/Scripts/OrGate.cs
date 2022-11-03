using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrGate : BinaryLogicGate
{
    protected override bool ComputeValue()
    {
        return input1.GetValue() | input2.GetValue();
    }
}
