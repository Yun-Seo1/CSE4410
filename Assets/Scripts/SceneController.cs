using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; //Can edit in inspect but no where else
    [SerializeField] GameObject BossPreFab;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject BossUIPanel;
    [SerializeField] TMP_Text enemycounter;
    AudioManager audioManager;
    private GameObject _enemy;
    private GameObject _boss;

    private int enemycount;
    private int Bosscount;
    bool songplaying;


     private void DarkSoulsSong()
    {
        AudioManager audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlaySong(audioManager.DarkSouls);
        songplaying = true;

    }


    // Start is called before the first frame update
    void Start()
    {
        enemycount = 0;
        Bosscount = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(Random.Range(-20,20), 1, Random.Range(-17,22));

            float angle = Random.Range(0,360);

            _enemy.transform.Rotate(0, angle, 0);
            enemycounter.text = $"Enemies Killed: {enemycount}";
            enemycount += 1;
            if (enemycount >= 5)
            {
                BossUIPanel.SetActive(true);
                _boss = Instantiate(BossPreFab) as GameObject;
                _boss.transform.position = new Vector3(0,1,0);
                _enemy = Instantiate(enemyPrefab) as GameObject;
                _enemy.transform.position = new Vector3(2, 1, 2);
                _enemy = Instantiate(enemyPrefab) as GameObject;
                _enemy.transform.position = new Vector3(-1, 1, -1);
                _enemy = Instantiate(enemyPrefab) as GameObject;
                _enemy.transform.position = new Vector3(3, 1, 3);
            


                _boss.transform.Rotate(0,angle,0);
                Bosscount += 1;
                if (songplaying == false){
                DarkSoulsSong();
                }
                //WinPanel.SetActive(true);
                if (Bosscount == 2)
                {
                    BossUIPanel.SetActive(false);
                    WinPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
            }

        }
    }
}
