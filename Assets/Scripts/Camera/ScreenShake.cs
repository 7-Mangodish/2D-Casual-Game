using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originPos;
    [SerializeField] private float timeShake;
    [SerializeField] private float magnitude;
    void Start()    
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Shake(float timeShake, float magnitude)
    {
        originPos = this.transform.localPosition;
        float timeDuraion = 0;
        while(timeDuraion < timeShake)
        {
            float directX = Random.Range(-1f, 1f) * magnitude;
            float directY = Random.Range(-1f, 1f) * magnitude;

            this.transform.localPosition = new Vector3(directX, directY,this.transform.localPosition.z);
            timeDuraion += Time.deltaTime;

            yield return null;

        }
        this.transform.localPosition = originPos;
    }
}
