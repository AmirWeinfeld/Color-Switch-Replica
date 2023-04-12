using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private Color purple, green, red, cyan;

    private string currentColor;

    [SerializeField]
    private GameObject menu, pause;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        rb.isKinematic = true;
        RandomColorChange();
    }
	
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
            }
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            
            pause.SetActive(!pause.activeInHierarchy);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "ColorChange")
        {
            RandomColorChange();
            Destroy(collision.gameObject);
        }
        else if (tag == "Ground")
        {
            SceneManager.LoadScene(0);
        }
        else if (tag == "Objective")
        {
            menu.SetActive(true);
            Destroy(gameObject);
        }
        else if (tag != "Untagged")
        {
            if (tag != currentColor)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void RandomColorChange()
    {
        int randomIndex = Random.Range(0, 3);
        string nextColor = "";

        switch(randomIndex)
        {
            case 0:
                nextColor = "purple";
                sr.color = purple;
                break;
            case 1:
                nextColor = "green";
                sr.color = green;
                break;
            case 2:
                nextColor = "red";
                sr.color = red;
                break;
            case 3:
                nextColor = " cyan";
                sr.color = cyan;
                break;
        }

        if (nextColor == currentColor)
            RandomColorChange();
        else
            currentColor = nextColor;
    }
}
