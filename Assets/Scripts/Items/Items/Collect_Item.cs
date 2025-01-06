using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collect_Item : MonoBehaviour
{
    private Animator anim;
    private Scores score;
    [SerializeField] private GameObject pfDisapear;
    private void Awake()
    {
    }
    void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);           
            AudioManager.Instance.PlaySfx("CollectItem");
            GameManager.Instance.UpdateCurrentScore();
            //Debug.Log(GameManager.Instance.GetCurrentScore());
            //Instantiate(pfDisapear, this.transform.position, Quaternion.identity);
        }

    }
}
