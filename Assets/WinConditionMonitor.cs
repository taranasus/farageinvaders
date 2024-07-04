using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionMonitor : MonoBehaviour
{
    public GameObject winText;
    public GameObject looseText;
    public GameObject player;
    public bool IsLoose = false;
    public float RestartingIn = -1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemy") == null && RestartingIn == -1)
        {
            winText.SetActive(true);
            RestartingIn = 5.999999f;
        }
        if (IsLoose && RestartingIn == -1)
        {
            looseText.SetActive(true);
            RestartingIn = 5.999999f;
            GameObject.Destroy(player);
        }
        if (RestartingIn != -1)
        {
            RestartingIn -= Time.deltaTime;
            if (RestartingIn <= 0)
            {
                RestartGame();
            }
        }
        Debug.Log(RestartingIn);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
