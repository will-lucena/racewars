using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int hp;

    private void FixedUpdate()
    {
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("bullet"))
        {
            hp -= 3;
            print(hp);
            Destroy(collision);
            if (hp < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
