using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [Header("Iframe")]
    [SerializeField] private int numOfFlash;
    [SerializeField] private float durationIframe;
    private SpriteRenderer sprite;

    [Header("Camera")]
    private ScreenShake screenShake;

    [Header("Animation")]
    public bool isTakeDame = false;
    private Animator anim;
    private AnimationControl animControl;


    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 3, false);
        anim = GetComponent<Animator>();
        animControl = GetComponent<AnimationControl>();
        sprite = GetComponent<SpriteRenderer>();
        screenShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
        
    }

    void Update()
    {
    }


    public void TakeDame()
    {
        // Calculate quantity of hearts again
        int cntHeart = GameManager.Instance.GetHeart();
        GameManager.Instance.SetHeart(cntHeart -1);

        //Play animation
        AudioManager.Instance.PlaySfx("TakeDame");
        animControl.ChangeState("TakeDame");
        //Debug.Log("Damaged");
        //Debug.Log(cntHeart);
        //Debug.Log(GameManager.Instance.GetHeart());
        StartCoroutine("Iframe");
        StartCoroutine(screenShake.Shake(0.15f, 0.5f));
        if (cntHeart <= 0)
        {
            animControl.ChangeState("Die");
            Debug.Log("Die");
        }
    }

    private IEnumerator Iframe()
    {
        Physics2D.IgnoreLayerCollision(8, 3, true);
        isTakeDame = true;
        for(int i=0; i<numOfFlash; i++)
        {
            sprite.color = new Color(1, 1, 1, 0.2f);
            yield return new WaitForSeconds(0.15f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.15f);
        }
        isTakeDame=false;
        Physics2D.IgnoreLayerCollision(8, 3, false);

    }

    private void Die()
    {
        this.gameObject.SetActive(false);
        UIManager.isDied = true;
        AudioManager.Instance.PlaySfx("GameOver");
    }
}
