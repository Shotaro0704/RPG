using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float inputVelocityX;
    public float inputVelocityY = 0;
    public float inputVelocityZ;
    public float velocityY = 10f;
    public float mainSPEED = 10f;
    public bool grounded;
    public bool collision;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playermove();
    }
    void playermove()       //ÉvÉåÉCÉÑÅ[ÇÃìÆÇ´
    {
        Transform trans = transform;
        transform.position = trans.position;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            inputVelocityY = this.velocityY;
        }
        else
        {
            inputVelocityY = this.myRigidbody.velocity.y;
        }
        if (collision && grounded == false)
        {
            inputVelocityX = 0;
            inputVelocityZ = 0;
        }
        else
        {
            inputVelocityX = Input.GetAxis("Horizontal") * mainSPEED;
            inputVelocityZ = Input.GetAxis("Vertical") * mainSPEED;
        }
        this.myRigidbody.velocity = trans.TransformDirection(new Vector3(inputVelocityX, inputVelocityY, inputVelocityZ));
    }
    
    void OnCollisionStay(Collision other)
    {
        foreach (ContactPoint contact in other.contacts)
        {
            if (Vector2.Angle(contact.normal, Vector3.up) < 60)
            {
                grounded = true;
            }
        }
    }
}
