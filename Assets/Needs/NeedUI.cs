using UnityEngine;
using UnityEngine.UI;

namespace GrandfatherSimulator
{
    public class NeedUI : MonoBehaviour
    {
        public Slider Slider;

        public void Refresh(float sliderValue)
        {
            Slider.value = sliderValue;
        }
    }
}
