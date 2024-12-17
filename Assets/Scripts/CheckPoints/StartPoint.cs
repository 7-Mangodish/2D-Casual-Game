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
            Instantiate(characterObject.getCharacter(PlayerPrefs.GetInt("characterIndex")));
        }
        Debug.Log(PlayerPrefs.GetInt("characterIndex"));
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
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
