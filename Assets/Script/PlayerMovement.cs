using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class EnergyBar : UnityEvent<float> { }
public class PlayerMovement : MonoBehaviour
{
    public EnergyBar energyBar; 
    Rigidbody rb;
    [SerializeField] float movementSpeedNorm;
    [SerializeField] float movementSpeedShift;
    public float jumpHeight;
    public float JumpEnergy;
    private float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public float MaxShift = 100f;
    public float ShiftThing = 100f;
    public float ShiftMore;
    public float TimeMulitiplier;
    private float movementSpeed;
    public float UpdateStatic;
    private float UpdateTime;
    private float Lower;
    private bool isGrounded;
    private float RegenTime;
    public float RegenAmount;
    private float ShiftThingCheck = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RegenTime = Time.deltaTime/RegenAmount;
    }

    void Update()
    {
        UpdateTime -= Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if(ShiftThing != ShiftThingCheck)
        {
            energyBar.Invoke(ShiftThing);
        }
        ShiftThingCheck = ShiftThing;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);
        if(ShiftThing < MaxShift)
        {
            ShiftThing += RegenTime;
        }

  //      else if (UpdateTime < 0 && ShiftThing < MaxShift && ShiftThing > MaxShift-- && !Input.GetKey(KeyCode.LeftShift)||!Input.GetKey(KeyCode.RightShift));
   //     {
     //       ShiftThing = MaxShift;
     //   }


        if(Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
        {
            movementSpeed = movementSpeedShift;
            float TimeOfShift = Time.deltaTime * TimeMulitiplier;
            ShiftThing -= TimeOfShift;
        }

        else
        {
            movementSpeed = movementSpeedNorm;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("IsJump?");
            Vector3 tempVelocity = rb.velocity;
            tempVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            rb.velocity = tempVelocity;
            ShiftThing -= JumpEnergy;
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
    }   
}
