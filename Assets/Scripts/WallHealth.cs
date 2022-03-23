using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public Sprite[] wallSprites; 
    int maxHealth = 3;
    int currentHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       

        if(currentHealth <= 0)
        {
            Destroy(this);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "bullet")
        {
            currentHealth--;
        }
        ChangeSprite();
    }

    void ChangeSprite()
    {
       if (currentHealth == 3)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprites[0];
        }
        if (currentHealth == 2)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprites[1];
        }
        if (currentHealth == 1)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprites[2];
        }
    }
}