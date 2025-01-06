using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private CharacterObject characterObject;
    private Animator anim;

    private void Awake()
    {
        if(characterObject != null)
        {
            Vector2 posPlayerSpawn = new Vector2(this.transform.position.x, this.transform.position.y + 10);
            Instantiate(characterObject.getCharacter(PlayerPrefs.GetInt("characterIndex")), 
                this.transform.position,Quaternion.identity);
        }
        Debug.Log("Character" + PlayerPrefs.GetInt("characterIndex"));
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        //Debug.Log("Start");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Player")) {
            anim.SetBool("Active", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Active", false);
        }
    }
}
