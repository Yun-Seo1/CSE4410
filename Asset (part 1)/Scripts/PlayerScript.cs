using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject mouseLookScript;
    [SerializeField] TMP_Text healthcounter;
    private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = 5;
    }

    // Update is called once per frame
    public void Hurt(int damage)
    {
        _health -= damage;
        healthcounter.text = $"Health: {_health}";
        Debug.Log($"Health: {_health}");

        if (_health <= 0)
        {
            gameOverPanel.SetActive(true);
          //  Get the MouseLook component from the mouseLookScript GameObject and call SetMouseControl on it
            mouseLookScript.GetComponent<MouseLook>().SetMouseControl(false); // Disable mouse control
        }
    }
}
