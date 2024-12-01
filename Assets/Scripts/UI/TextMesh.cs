using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMesh : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public float speed;
    public float maxSize ;
    public float minSize;

    private float originalSize;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        originalSize = textMeshPro.fontSize;
    }

    void Update()
    {
        float size = Mathf.Lerp(minSize, maxSize, (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f);
        textMeshPro.fontSize = size * originalSize;
    }
}
