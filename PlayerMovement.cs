using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Private Variables
    private float horizontalInput;
    private float verticalInput;
    private float mouseInput;

    public float speed;
    public float turnSpeed;
    public float mouseTurnSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseInput = Input.GetAxis("Mouse X");

        // We move the person forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // we turn the person
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        // mouse 
        transform.Rotate(Vector3.up * Time.deltaTime * mouseTurnSpeed * mouseInput);


    }
}
