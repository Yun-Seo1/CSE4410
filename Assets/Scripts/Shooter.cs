using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject pfBulletProjectile;
    [SerializeField]  GameObject pfBall;
    [SerializeField] public GameObject Gun1;
    [SerializeField] public GameObject Gun2;

    private GameObject bullet;
    private GameObject ball;
    int gun;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gun = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gun == 1)
            {
                gun = 2;
                Gun1.SetActive(false);
                Gun2.SetActive(true);
            }
            else if (gun == 2)
            {
                gun = 1;
                Gun2.SetActive(false);
                Gun1.SetActive(true);
            }
        }

        if (gun == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bullet = Instantiate(pfBulletProjectile) as GameObject;
                bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                bullet.transform.rotation = transform.rotation;
                StartCoroutine(Cooldown1());
            }
        }
        else if (gun == 2)
        {
            if (Input.GetMouseButton(0))
            {
                ball = Instantiate(pfBall) as GameObject;
                ball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                ball.transform.rotation = transform.rotation;
                StartCoroutine(Cooldown2());
            }
        }
    }
    
    private IEnumerator Cooldown1()
    {
        yield return new WaitForSeconds(5);
        Destroy(bullet);
    }
    private IEnumerator Cooldown2()
    {
        yield return new WaitForSeconds(5);
        Destroy(ball);
    }
}
