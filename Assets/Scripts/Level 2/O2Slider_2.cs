using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Slider_2 : MonoBehaviour
{
    public Slider O2Slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
   public void setMax(float percent)
    {
        O2Slider.maxValue = percent;
        O2Slider.value = percent;
        fill.color = gradient.Evaluate(1f);
    }

    public void setpercent(float percent)
    {
        O2Slider.value = percent;
        fill.color = gradient.Evaluate(O2Slider.normalizedValue);
    }

}
