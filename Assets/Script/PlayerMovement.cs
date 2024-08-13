using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class EnergyBar : UnityEvent<float, int> { }
public class PlayerMovement : MonoBehaviour
{
    public EnergyBar energyBar; 
    public UnityEvent Shoot;
    public GameObject explode; 
    Rigidbody rb;
    public static bool CanCollect = false;
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
    public float UpdateTime;
    private float Lower;
    private bool isGrounded;
    private float RegenTime;
    public float RegenAmount;
    private float ShiftThingCheck = 100f, Health1Check = 50f, Health2Check = 50f;
    // attack
    public float timebetweenatttacks;
    private bool alreadyattacked;
    public float WoodHealth = 50f, WoolHealth = 50f;
    public float MoreWool, MoreWood;
    public string enemytag;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        RegenTime = Time.deltaTime/RegenAmount;
        UpdateTime = UpdateStatic;
    }

    private void Update()
    {
        Shooting();
        Collector();
        ShiftFunct();
        Health();
    }

    private void Health()
    {
        if(WoodHealth < 0.01f || WoolHealth < 0.01f)
        {
            explode.SetActive(true);
        }
        if(WoolHealth != Health1Check)
        {
            energyBar.Invoke(WoolHealth, 1);
            Health1Check = WoolHealth;
        }
        if(WoodHealth != Health2Check)
        {
            Debug.Log("did stuff");
            energyBar.Invoke(WoodHealth, 2);
            Health2Check = WoodHealth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(enemytag))
        {
          WoodHealth -= Random.Range(0.2f, 0.7f);
          WoolHealth -= Random.Range(0.1f, 0.5f);
          Destroy(other.gameObject);
        }
    }

    public void MoreWoodHealth()
    {
        WoodHealth += MoreWood;
    }

    public void MoreWoolHealth()
    {
        WoolHealth += MoreWool;
    }

    private void Collector()
    {
        if(!CanCollect)
        {
            UpdateTime -= Time.deltaTime;
        }
        if(UpdateTime < 0f)
        {
            CanCollect = true;
            UpdateTime = UpdateStatic;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            CanCollect = false;
        }
    }

    private void ShiftFunct()
    {
        if(ShiftThing != ShiftThingCheck)
        {
            energyBar.Invoke(ShiftThing, 0);
        }
        ShiftThingCheck = ShiftThing;
        Debug.Log(isGrounded);
        if(ShiftThing < MaxShift)
        {
            ShiftThing += RegenTime;
        }
    }

    private void Shooting()
    {
        if(Input.GetKey(KeyCode.F))
        {
            if(!alreadyattacked)
            {
                Shoot.Invoke();
                alreadyattacked = true;
                Invoke(nameof(ResetAttack), timebetweenatttacks);
            }
        }
    }
    private void ResetAttack()
    {
        alreadyattacked = false;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
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
}
     