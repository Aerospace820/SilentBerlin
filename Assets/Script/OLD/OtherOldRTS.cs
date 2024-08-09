using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rtsMaterials : MonoBehaviour
{
    static Dictionary<string, Dictionary<string, float>> Maeterials = new Dictionary<string, Dictionary<string, float>>
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

    public void EnergyUpdate(float Incoming)
    {
        energy = Incoming;
    }
}
