﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerMovement : MonoBehaviour, I_InputReceiver {

    bool debug;
    public Transform inputSender;

    [SerializeField]
    private float m_speedDelta;

    private Rigidbody2D m_rb;
    private Transform m_tr;

    private Vector2 m_velocity = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
        inputSender.GetComponent<I_InputSender>().addInputReceiver(this);
        m_rb = GetComponent<Rigidbody2D>();
        m_tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        m_rb.velocity = m_velocity;

        m_tr.up = m_rb.velocity;
	}

    public void onAttachedToSender()
    {
        if (debug)
            Debug.Log("Attached to sender");
    }

    public void onDetachFromSender()
    {
        if (debug)
            Debug.Log("Detached from sender");
    }

    public void onButtonPressed(E_InputTypes type)
    {
        switch (type)
        {
            case E_InputTypes.Up:
                m_velocity.y += m_speedDelta;
                break;
            case E_InputTypes.Down:
                m_velocity.y -= m_speedDelta;
                break;
            case E_InputTypes.Left:
                m_velocity.x -= m_speedDelta;
                break;
            case E_InputTypes.Right:
                m_velocity.x += m_speedDelta;
                break;
        }
    }

    public void onButtonReleased(E_InputTypes type)
    {
        switch (type)
        {
            case E_InputTypes.Up:
                m_velocity.y -= m_speedDelta;
                break;
            case E_InputTypes.Down:
                m_velocity.y -= m_speedDelta;
                break;
            case E_InputTypes.Left:
                m_velocity.x += m_speedDelta;
                break;
            case E_InputTypes.Right:
                m_velocity.x -= m_speedDelta;
                break;
        }
    }
}
