using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = 5;
    }

       void Update()
        {
            if(_health == 0)
            {
                SceneManager.LoadScene("SampleScene");
                _health = 5;
            }
        }

    // Update is called once per frame
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log($"Health: {_health}");
    }
}
