using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    //Rigidbody bullet;
    public float speed = 10f;
    public int damage = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        WanderingAI enemy = other.GetComponent<WanderingAI>();

        if(enemy != null)
        {
            //Debug.Log("Player Hit");
            enemy.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
