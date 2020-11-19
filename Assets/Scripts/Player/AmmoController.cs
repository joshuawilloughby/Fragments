using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    public Slider slider;

    public void SetMaxRounds(int rounds)
    {
        slider.maxValue = rounds;
        slider.value = rounds;
    }
    public void SetRounds(int rounds)
    {
        slider.value = rounds;
    }
}
