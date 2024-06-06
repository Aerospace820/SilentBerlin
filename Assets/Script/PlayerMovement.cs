using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Ob : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeedNorm;
    [SerializeField] float movementSpeedShift;
    public float MaxShift = 100f;
    public float ShiftThing = 100f;
    public float ShiftMore;
    public float TimeMulitiplier;
    private float movementSpeed;
    public float UpdateStatic;
    private float UpdateTime;
    private float Lower;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UpdateTime -= Time.deltaTime;

        if(UpdateTime < 0 && ShiftThing < MaxShift)
        {
            ShiftThing += ShiftMore;
            UpdateTime = UpdateStatic;
        }


       // else if (UpdateTime < 0 && ShiftThing < MaxShift && ShiftThing > MaxShift-- && !Input.GetKey(KeyCode.LeftShift)||!Input.GetKey(KeyCode.RightShift));
      //  {
      //      ShiftThing = MaxShift;
     //   }


        if(Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
        {
            float TimeOfShift = Time.deltaTime * TimeMulitiplier;
            ShiftThing -= TimeOfShift;
            movementSpeed = movementSpeedShift;
        }

        else
        {
            movementSpeed = movementSpeedNorm;
        }
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
    }   
}
