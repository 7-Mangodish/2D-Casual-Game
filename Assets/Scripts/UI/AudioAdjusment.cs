using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioAdjusment : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        musicSlider.value = 0.3f;
        sfxSlider.value = 0.3f;

    }
    void Start()
    {
        
        musicSlider.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.UpdateVolumn("music",value);
        });
        sfxSlider.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.UpdateVolumn("sfx",value);
        });

    }
    
}
