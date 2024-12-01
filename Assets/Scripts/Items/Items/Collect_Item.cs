using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Item : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject pfDisapear;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Scores.scores += 100;
            FindObjectOfType<AudioManager>().PlaySfx("CollectItem");
            //Instantiate(pfDisapear, this.transform.position, Quaternion.identity);
        }

    }
}
