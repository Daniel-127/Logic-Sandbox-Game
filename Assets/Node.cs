using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public static Node hoveringOver;
    public static Node draggingFrom;

    protected abstract NodeType Type { get; }

    [SerializeField]
    protected SpriteRenderer sr;

    [SerializeField]
    protected LineRenderer lr;

    public Action<Vector3> OnMoved { get; set; }


    readonly Color off = new Color(0.5f, 0.5f, 0.5f);
    readonly Color on = Color.white;
    readonly Color darken = new Color(0.15f, 0.15f, 0.15f, 0);

    bool SelfHover { get => hoveringOver == this; }

    private bool value;
    protected bool Value {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            UpdateColor();
        } 
    }

    public abstract bool GetValue();
    public abstract void UpdateValue(bool newValue);
    protected abstract void Bind(Node other);

    bool BindCompatible(Node other)
    {
        bool siblings = transform.parent != null && other.transform.parent != null && transform.parent == other.transform.parent;
        return Type != other.Type & !siblings;
    }
    protected virtual void UpdateColor()
    {
        var baseColor = value ? on : off;
        var tinted = SelfHover ? baseColor - darken : baseColor;
        sr.color = tinted;
    }

    protected virtual void Start()
    {
        lr.positionCount = 2;
    }

    void Update()
    {
        OnMoved?.Invoke(transform.position);
    }

    void OnMouseEnter()
    {
        if (!(draggingFrom != null && !BindCompatible(draggingFrom)))
        {
            hoveringOver = this;
            UpdateColor();
        }
    }

    void OnMouseExit()
    {
        if (SelfHover)
        {
            hoveringOver = null;
            UpdateColor();
        }
    }
    void OnMouseDrag()
    {
        lr.SetPosition(1, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    protected virtual void OnMouseDown()
    {
        draggingFrom = this;
        lr.enabled = true;
        lr.SetPosition(0, transform.position);
    }

    void OnMouseUp()
    {
        if (hoveringOver != null & !SelfHover)
        {
            Bind(hoveringOver);
            hoveringOver.Bind(this);
        }
        else
        {
            lr.enabled = false;
        }
        draggingFrom = null;
    }

    public enum NodeType { Input, Output }
}
