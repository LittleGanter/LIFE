using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ееее : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int Damage = 5;

            Hp.health -= Damage;

           // Destroy(gameObject);
        }


    }
}
