using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    private Vector3 offSet = new Vector3(0, -1.5f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 speed = Vector3.zero;

    [SerializeField] private Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position + offSet;
        transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref speed, smoothTime);
    }
}
