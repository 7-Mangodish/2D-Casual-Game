using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    [SerializeField] private float angle;
    [SerializeField] private int direct = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(anchor.position, Vector3.forward * direct, angle * Time.deltaTime);
    }
}
