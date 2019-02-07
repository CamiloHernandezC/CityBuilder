using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 velocity;

    private bool goesToRight = true;
    private Vector3 craneBottomPosition;

    public Block craneBlock;

    private bool blockDroped;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = velocity;

        createBlock();
        
    }

    // Update is called once per frame
    void Update()
    {
        Push();

        if(craneBlock == null || (craneBlock.IsAnchored && blockDroped))
        {
            createBlock();
            blockDroped = false;
        }
        if (Input.GetKeyDown("space"))
        {
            Destroy(transform.gameObject.GetComponent<FixedJoint>());
            craneBlock.IsFalling = true;
            blockDroped = true;
        }

    }

    void Push()
    {
        //Goes to right
        if (goesToRight && transform.rotation.z >= 0)
        {
            rb.angularVelocity = velocity;
            goesToRight = false;
        }
        //Goes to left
        if (!goesToRight && transform.rotation.z < 0)
        {
            rb.angularVelocity = -1 * velocity;
            goesToRight = true;
        }
    }

    void createBlock()
    {
        craneBlock = (Block)Instantiate(craneBlock, transform.position, transform.rotation);

        //Se crea como hijo para poder ubicar el nuevo bloque de la manera correcta con respecto a la grua
        craneBlock.transform.parent = transform;
        craneBlock.transform.localPosition = new Vector3(craneBlock.transform.localPosition.x, (craneBlock.transform.localPosition.y - (transform.localScale.y + craneBlock.transform.localScale.y/2)), craneBlock.transform.localPosition.z);
        
        //Se coloca la masa en 0 para que no afecte 
        craneBlock.GetComponent<Rigidbody>().mass = 0;
        
        //Se crea un Fixed Joint para que el nuevo cubo se mueva con la grua
        transform.gameObject.AddComponent<FixedJoint>().connectedBody = craneBlock.GetComponent<Rigidbody>();
    }
}
