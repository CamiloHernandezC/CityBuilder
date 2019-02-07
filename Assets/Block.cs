using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private bool anchored;
    private bool falling;

    private void OnCollisionEnter(Collision collision)
    {
        if (falling) {
            anchored = true;
        }
    }

    public bool IsAnchored
    {
        get
        {
            return anchored;
        }
        set
        {
            anchored = value;
        }
    }

    public bool IsFalling
    {
        get
        {
            return falling;
        }
        set
        {
            falling = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
