using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

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
