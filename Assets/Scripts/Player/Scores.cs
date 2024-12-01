using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public static int scores = 0;
    [SerializeField] private TextMeshProUGUI textScore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        textScore.text = "Score: " + scores;

    }

}
