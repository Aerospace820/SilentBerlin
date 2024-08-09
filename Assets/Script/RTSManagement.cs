using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSManagement : MonoBehaviour
{
    static public Dictionary<string, float> materials = new Dictionary<string, float>
    {
        {"Coal", 0f},
        {"Wool", 0f},
        {"Wood", 0f}
    };

    public void WoodCoal()
    {
        materials["Coal"] = Random.Range(0.5f, 1.5f);
        materials["Wood"] = Random.Range(1f, 2f);


    }
}
