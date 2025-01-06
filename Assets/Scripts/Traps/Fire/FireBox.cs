using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBox : MonoBehaviour
{
    //// Start is called before the first frame update

    //private bool isPlayer = true;
    //private Animator anim;

    //[SerializeField] private float timeDelay;
    //[SerializeField] private GameObject fire;
    //[SerializeField] private float distance;
    //[SerializeField] private LayerMask layerPlayer;

    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isPlayerOn())
    //    {
    //        // Animation
    //        anim.Play("Hit");

    //        Invoke(nameof(TurnOn), timeDelay);
    //        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0)
    //        {

    //        }
    //    }
    //}

    //void TurnOn()
    //{

    //    // MakeDame
    //    //anim.Play("On");
    //    fire.gameObject.SetActive(true);

    //    // Turn Off
    //    isPlayer = false;
    //    Invoke(nameof(TurnOff), 3f);
    //    Debug.Log("On");
    //}

    //void TurnOff()
    //{
    //    //Animation TurnOf
    //    // turn Off fire
    //    fire.gameObject.SetActive(false);
    //    Debug.Log("Off");
    //}

    //bool isPlayerOn()
    //{
    //    return Physics2D.Raycast(this.transform.position, Vector3.up, distance, layerPlayer);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(this.transform.position, new Vector3(transform.position.x,
    //        transform.position.y + distance, transform.position.z));
    //}
}
