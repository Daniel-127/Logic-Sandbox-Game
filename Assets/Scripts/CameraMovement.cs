using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float zoomScale;

    Vector3 formerPos;
    Vector3 MousePos => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnRightClick();
        }
        if (Input.GetMouseButton(1))
        {
            OnRightClickHeld();
        }

        Zoom(Input.mouseScrollDelta.y);
    }

    void OnRightClick()
    {
        formerPos = MousePos;
    }

    void OnRightClickHeld()
    {
        var curPos = MousePos;
        var diff = formerPos - curPos;
        diff.z = 0;
        transform.position += diff;
    }

    void Zoom(float delta)
    {
        Camera.main.orthographicSize = Mathf.Max(1, Camera.main.orthographicSize - delta * zoomScale);
    }
}
