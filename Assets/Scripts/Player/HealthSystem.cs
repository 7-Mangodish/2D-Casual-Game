using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Display Hearts")]
    [SerializeField] private Sprite fullHearts;
    [SerializeField] private Sprite emptyHearts;
    [SerializeField] private Image[] hearts;
    [SerializeField] private int curHearts;
    [SerializeField] private int maxHearts;
    private Animator anim;

    [Header("Iframe")]
    [SerializeField] private int numOfFlash;
    [SerializeField] private float durationIframe;
    private SpriteRenderer sprite;

    [Header("Camera")]
    private ScreenShake screenShake;

    public bool isTakeDame = false;

    public int CurHeart
    {
        get { return this.curHearts; }
        set { this.curHearts = value;}
    }


    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 3, false);
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        screenShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
        curHearts = 2;
    }

    void Update()
    {
        DisplayHeart();
    }


    private void DisplayHeart()
    {
        if (curHearts > maxHearts)
            curHearts = maxHearts;
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < curHearts)
                hearts[i].sprite = fullHearts;
            else
                hearts[i].sprite = emptyHearts;
        }
    }
    public void TakeDame()
    {      
        if(this.curHearts <= 0)
        {
            anim.Play("Die");
            return;
        }

        this.curHearts--;

        FindObjectOfType<AudioManager>().PlaySfx("TakeDame");
        anim.SetTrigger("TakeDame");
        StartCoroutine("Iframe");
        StartCoroutine(screenShake.Shake(0.15f, 0.5f));
    }

    private IEnumerator Iframe()
    {
        Physics2D.IgnoreLayerCollision(8, 3, true);
        isTakeDame = true;
        for(int i=0; i<numOfFlash; i++)
        {
            sprite.color = new Color(1, 1, 1, 0.4f);
            yield return new WaitForSeconds(0.2f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
        }
        isTakeDame=false;
        Physics2D.IgnoreLayerCollision(8, 3, false);

    }

    private void Die()
    {
        this.gameObject.SetActive(false);
        UIManager.isDied = true;
        Debug.Log("Die");
    }
}
