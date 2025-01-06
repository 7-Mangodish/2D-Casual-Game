using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioAdjusment : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private string nameSlider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Start()
    {
        if(slider == null || nameSlider == "")
        {
            Debug.Log("Thieu slider hoac ten");
            return;
        }

        if (!PlayerPrefs.HasKey(nameSlider))
            PlayerPrefs.SetFloat(nameSlider, 0.3f);
        slider.value = PlayerPrefs.GetFloat(nameSlider); 

        slider.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.UpdateVolumn(nameSlider, value);
            PlayerPrefs.SetFloat(nameSlider, value);
        });

    }
    
}
