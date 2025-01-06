using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.UpdateStar(); // Update star
            AudioManager.Instance.PlaySfx("CollectItem"); // Play Sound
        }
    }
}
