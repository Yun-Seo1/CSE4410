using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] GameObject fireballPrefab;
    private GameObject _fireball;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    private int _health;
    //private bool _IsAlive;

    // Start is called before the first frame update
    void Start()
    {
        _health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        ReactiveTarget target = GetComponent<ReactiveTarget>();

        if (_health > 0)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (_health == 0)
        {
            target.ReactToHit();
        }
        else
        {
            _health = 0;
        }

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<PlayerScript>())
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }

            else if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);

                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log($"Enemy Health: {_health}");
    }

    /*public void SetAlive(bool alive)
    {
        _IsAlive = alive;
    }*/
}
