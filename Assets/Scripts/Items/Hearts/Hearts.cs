using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float angle;
    private Vector3 currentPosition;
    [SerializeField] private float deltaPositon;
    [SerializeField] private float distance;



    private void Awake()
    {

    }
    void Start()
    {
        angle = 150;
        currentPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y + deltaPositon*Time.deltaTime,
                                    transform.position.z);
        if (Vector3.Distance(currentPosition, this.transform.position) > distance)
            deltaPositon *= -1;
        this.transform.RotateAround(this.transform.position, Vector3.up, angle * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            health.CurHeart += 1;
            FindObjectOfType<AudioManager>().PlaySfx("CollectItem");
            this.gameObject.SetActive(false);
        }
    }

}
