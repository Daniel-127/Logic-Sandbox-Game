using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public static Node hoveringOver;
    public static Node dragginFrom;

    protected abstract NodeType Type { get; }

    [SerializeField] 
    SpriteRenderer sr;

    [SerializeField] 
    LineRenderer lr;

    //Binding
    Node bound;
    LineRenderer boundLr;

    readonly Color off = new Color(0.5f, 0.5f, 0.5f);
    readonly Color on = Color.white;
    readonly Color darken = new Color(0.15f, 0.15f, 0.15f, 0);

    void BindNode(Node other, LineRenderer lr)
    {
        bound = other;
        boundLr = lr;
    }

    bool BindCompatible(Node other)
    {
        return Type != other.Type;
    }

    void Start()
    {
        lr.positionCount = 2;
    }

    void OnMouseEnter()
    {
        if (!(dragginFrom != null && !BindCompatible(dragginFrom)))
        {
            sr.color -= darken;
            hoveringOver = this;
        }
    }

    void OnMouseExit()
    {
        if (hoveringOver == this)
        {
            sr.color += darken;
            hoveringOver = null;
        }
    }

    void OnMouseDrag()
    {
        lr.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void OnMouseDown()
    {
        dragginFrom = this;
        lr.enabled = true;
        lr.SetPosition(0, transform.position);
    }

    void OnMouseUp()
    {
        if (hoveringOver != null & hoveringOver != this)
        {
            bound = hoveringOver;
            hoveringOver.BindNode(this, lr);
            lr.SetPosition(1, hoveringOver.transform.position);
        }
        else
        {
            lr.enabled = false;
        }
        dragginFrom = null;
    }

    public enum NodeType { Input, Output }
}
