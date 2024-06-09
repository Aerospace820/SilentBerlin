using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
//public class RTSGet : UnityEvent<float, float, bool> { }
public class RTSMainStats : MonoBehaviour
{
    [System.Serializable]
    public class RTSNames
    {
        public string Name;
        public float RTSValue;
    }
    
    public List<RTSNames> rtsObjects = new List<RTSNames>();
    public Slider EnergySlider;
    private float Oldthing = 100f;
    private float smoothVelocity;
    private float energy = 100f;
    private void Start()
    {
        EnergySlider.value = 100f;
    }
    private void Update()
    {
        Oldthing = Mathf.SmoothDamp(Oldthing, energy, ref smoothVelocity, 0.3f);
        EnergySlider.value = Oldthing;
    }
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

    public void EnergyUpdate(float Incoming)
    {
        energy = Incoming;
    }
}
