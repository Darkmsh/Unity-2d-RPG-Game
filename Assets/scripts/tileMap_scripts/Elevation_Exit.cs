using System;
using Unity.VisualScripting;
using UnityEngine;

public class Elevation_Exit : MonoBehaviour
{
    public Collider2D[] mountainColiders;
    public Collider2D[] bounderyColiders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            foreach (Collider2D mountain in mountainColiders)
            {
                mountain.enabled = true;
            } 
            foreach (Collider2D mountain in bounderyColiders)
            {
                mountain.enabled = false;
            }

        }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
}
