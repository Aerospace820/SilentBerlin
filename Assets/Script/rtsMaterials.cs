using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rtsMaterials : MonoBehaviour
{
    static Dictionary<string, Dictionary<string, float>> old = new Dictionary<string, Dictionary<string, float>>
    {
        {
            "normal", new Dictionary<string, float>
            {
                {"Fuel", 0f},
                {"Tools", 0f},
                {"Ammunition", 0f},
                {"Plane Parts", 0f}
            }
        },
        {
            "Advanced", new Dictionary<string, float>
            {
                {"Advanced Parts I", 0f},
                {"Advanced Parts II", 0f},
                {"Advanced Parts III", 0f},
            }
        },
        {
            "Stealth", new Dictionary<string, float>
            {
                {"Stealth Parts I", 0f},
                {"Stealth Parts II", 0f},
                {"Stealth Parts III", 0f},
            }
        },
        {
            "Computer", new Dictionary<string, float>
            {
                {"Computer Parts I", 0f},
                {"Computer Parts II", 0f},
                {"Computer Parts III", 0f},
            }
        },
        {
            "Radar", new Dictionary<string, float>
            {
                {"Radar Parts I", 0f}, 
                {"Radar Parts II", 0f},
                {"Radar Parts III", 0f},
            }
        },
    };

    static public Dictionary<string, float> materials = new Dictionary<string, float>
    {
        {"Coal", 0f},
        {"Wool", 0f},
        {"Wood", 0f}
    };

    public Slider EnergySlider, H1Slider, H2Slider;
    private float Oldthing = 100f, HealthThing1 = 50f, HealthThing2 = 50f;
    private float smoothVelocity;
    private float energy = 100f;
    private float Health1 = 50f, Health2 = 50f;
    private void Start()
    {
        EnergySlider.value = 100f;
        
    }
    private void Update()
    {
        SliderUpdate();
    }

    private void SliderUpdate()
    {
        Oldthing = Mathf.SmoothDamp(Oldthing, energy, ref smoothVelocity, 0.3f);
        EnergySlider.value = Oldthing;
        HealthThing1 = Mathf.SmoothDamp(HealthThing1, Health1, ref smoothVelocity, 0.3f);
        H1Slider.value = HealthThing1;
        HealthThing2 = Mathf.SmoothDamp(HealthThing2, Health2, ref smoothVelocity, 0.3f);
        H2Slider.value = HealthThing2;
    }

    public void WoodCoal()
    {
        materials["Coal"] = Random.Range(0.5f, 1.5f);
        materials["Wood"] = Random.Range(1f, 2f);
    }

    public void EnergyUpdate(float Incoming, int Updatetype)
    {
        if(Updatetype == 0)
        {
            energy = Incoming;
        }

        else if(Updatetype == 1)
        {
            Health1 = Incoming;
        }

        else if(Updatetype == 2)
        {
            Health2 = Incoming;
        }
    }
}
