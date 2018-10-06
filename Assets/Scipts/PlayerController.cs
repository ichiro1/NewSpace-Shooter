using UnityEngine;

[System.Serializable]
 public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
 
 public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private AudioSource audioSource;
    public float speed;
    public float tilt;
    public Boundary boundary;
    
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    public GameObject theWord;
    public WordManager WordManagerScript;
    public bool shoot;
    GameObject[] player;

    void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        theWord = GameObject.Find("WordManager");
        WordManagerScript = theWord.GetComponent<WordManager>();
       player= GameObject.FindGameObjectsWithTag("Player");
    }


    void Update () {
        shoot = WordManagerScript.shoot;
        if (Input.GetButton("Fire1") && Time.time > nextFire || shoot == true) {
            foreach (GameObject ship in player)
            {

                nextFire = Time.time + fireRate;
                if (ship)
                {
                    Instantiate(shot, ship.transform.position, ship.transform.rotation);
                }
                audioSource.Play();



                WordManagerScript.shoot = false;
            }
        }

        //if(shoot == true) {
        //    nextFire = Time.time + fireRate;
        //    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //    audioSource.Play ();

        //    WordManagerScript.shoot = false;
        //}


    }
    
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        
        rb.position = new Vector3
        (
        Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );
        
        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
