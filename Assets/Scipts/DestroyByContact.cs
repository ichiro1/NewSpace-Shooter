using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public WordManager wordManager;

    private Word activeWord;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
	public int shipsRemaining;
    
    void Start () {
    GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
    if(gameControllerObject != null) {
        gameController = gameControllerObject.GetComponent <GameController>();
    }
    if(gameController == null) {
Debug.Log ("Cannot find 'GameController' script");

    }
}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		Destroy(gameObject);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            
			Debug.Log (gameController.shipsRemaining ());
			if (gameController.shipsRemaining () <= 1) {
				gameController.GameOver ();
                wordManager.words.Remove(activeWord);
			}
        }
        gameController.AddScore (scoreValue);

    }
}
