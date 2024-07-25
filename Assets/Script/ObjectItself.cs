using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class ObjectNumber : UnityEvent <bool, int> { }
public class ObjectItself : MonoBehaviour
{
    public ObjectNumber IsPicked;
    public int ObjectNumber;

    void OnTriggerStay(Collider other)
    {
        Debug.Log("IsInObjectCOllider");
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && PlayerMovement.CanCollect == true)
        {
            Debug.Log("Balala");
            IsPicked.Invoke(true, ObjectNumber);
        }
    }
}
