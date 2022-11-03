using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    public abstract void Compute();

    Vector2 offset;

    private void OnMouseDown()
    {
        offset = (Vector2)transform.parent.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDrag()
    {
        transform.parent.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
}
