using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heath_Point : MonoBehaviour
{
    public Slider healthSlider;
    private void Start() {
        healthSlider = GetComponent<Slider>();
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }
}
