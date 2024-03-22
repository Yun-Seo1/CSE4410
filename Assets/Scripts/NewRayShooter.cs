using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject pfBulletProjectile;
    [SerializeField]  GameObject pfBall;
    [SerializeField]  Transform projectileSpawner1;
    [SerializeField]  Transform projectileSpawner2;

    [SerializeField] public GameObject Gun1;
    [SerializeField] public GameObject Gun2;

    private Camera cam;
    private GameObject bullet;
    private GameObject ball;
    int gun;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
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
                Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);

                Ray ray = cam.ScreenPointToRay(point);

                RaycastHit hit;
                if (Physics.Raycast(ray,out hit))
                {
                    StartCoroutine(Fire1());
                }
            }
        }
        else if (gun == 2)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);

                Ray ray = cam.ScreenPointToRay(point);

                RaycastHit hit;
                if (Physics.Raycast(ray,out hit))
                {
                    StartCoroutine(Fire2());
                }
            }
        }
    
    }
    
    private IEnumerator Fire1()
    {
        bullet = Instantiate(pfBulletProjectile, projectileSpawner1) as GameObject;
        bullet.transform.rotation = transform.rotation;

        yield return new WaitForSeconds(5);
        Destroy(bullet);
    }
    private IEnumerator Fire2()
    {
        ball = Instantiate(pfBall, projectileSpawner2) as GameObject;
        ball.transform.rotation = transform.rotation;

        yield return new WaitForSeconds(5);
        Destroy(ball);
    }
}
