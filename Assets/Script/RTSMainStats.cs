using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RTSGet : UnityEvent<float, float, bool> { }
public class RTSMainStats : MonoBehaviour
{
    [System.Serializable]
    public class RTSNames
    {
        public string Name;
        public float RTSValue;
    }
    
    public List<RTSNames> rtsObjects = new List<RTSNames>();


    public void ChangeValues(int objects, float valueChange, bool IsAdd)
    {
        if (IsAdd)
        {
            rtsObjects[objects].RTSValue += valueChange;
        }

        else
        {
            rtsObjects[objects].RTSValue -= valueChange;
        }   
    }
}
