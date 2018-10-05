using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;

    
    public float waveWait;
    
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
	public Text waveCountText;
    //public GameObject asteriod;
    private bool gameOver;
    private bool restart;
    private int score;
	public int waveCount;
    
    void Start ()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());

    
   
    }

    void Update() {
        if(restart) {
            if(Input.GetKeyDown (KeyCode.R)) {
                Application.LoadLevel (Application.loadedLevel);
            }
        }

    }
    
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);

        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
                

            }
			waveCount++;
            spawnWait += (float)0.1;

			waveCountText.text = "Waves Survived: " + waveCount;
            yield return new WaitForSeconds (waveWait);
            
            //asteriod = GameObject.Find("Asteriod");
            //Mover movescript = asteriod.GetComponent<Mover>();
            //movescript.speed+= (float)0.2;

            if(gameOver) {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore (int newScoreValue) {
        score += newScoreValue;
        UpdateScore ();
    }
    
    void UpdateScore () {
        scoreText.text = "Score: " + score;
    }
    
    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;

    }

	public int shipsRemaining(){
		return GameObject.Find ("Players").transform.childCount;

	}
}
