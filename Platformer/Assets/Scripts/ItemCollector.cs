using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour

{
    [SerializeField ] private Text Strawberriestext;
    [SerializeField] private AudioSource collectSound;




    private int Strawberries = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            Strawberries++;
            Strawberriestext.text = "Strawberries:" + Strawberries;
        }
    }
}
