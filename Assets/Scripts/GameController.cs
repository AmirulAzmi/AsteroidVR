using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text startText;
    public bool autoFire = false;
    public GameObject[] hazard = new GameObject[3];
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int score = 10;
    public Text scoreText;
    public Text gameOverScoreText; 
    public GameObject GameOverCanvas;
    public GameObject HUDCanvas;

    private int scoreCount = 0;
    private bool gameover = false;
    void Start ()
    {
        StartCoroutine(Countdown());
        StartCoroutine(SpawnWaves());
        scoreText.text = "Score: 000000";
    }
    void Update() {
        if (gameover)
        {
            HUDCanvas.SetActive(false);
            GameOverCanvas.SetActive(true);
            gameOverScoreText.text = scoreText.text;
            if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
                StartCoroutine(Restart());
            }
        }
    }

    IEnumerator Countdown() {
        int count = 3;
        while (count > 0)
        {
            startText.text = "Ready?\n" + count.ToString();
            yield return new WaitForSecondsRealtime(1);
            count--;
        }
        startText.text = "Start!";
        yield return new WaitForSecondsRealtime(1);
        startText.gameObject.SetActive(false);
        autoFire = true;
    }

    IEnumerator SpawnWaves ()
    {
        int waveCount = 0;
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard[chooseIndex(waveCount)], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            waveCount++;
        }
    }
    int chooseIndex(int wave) {
        float random = Random.value;
        int index = 0;
        switch (wave){
            case 0:
                index = 0;
                break;
            case 1:
                if (random < 0.30) { index = 1; }
                else { index = 0; }
                break;
            default:
                if (random < 0.35) { index = 1; }
                if (random < 0.25) { index = 2; }
                else { index = 0; } 
                break;
        }
        return index;
    }
    public void GameOver() {
        Debug.Log("GameOver");
        gameover = true;
    }
    public void AddScore(int count) {
        scoreCount += count;
        scoreText.text = "Score: " + (scoreCount * score).ToString("000000");
    }
    public void RestartOnclick() {
        //Debug.Log("Restart");
        StartCoroutine(Restart());
    }
    IEnumerator Restart() {
        yield return new WaitForSeconds(startWait);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}