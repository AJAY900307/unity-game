using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public float movespeed = 5f;
    GameObject currentfloor;

    [SerializeField] int hp;
    [SerializeField] GameObject heartbar;

    [SerializeField] Text scoretext;
    int score;
    float scoretime;

    Animator ani;

    [SerializeField] AudioSource GG;
    [SerializeField] GameObject replayButton,startButton;

    

    

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        score = 0;
        scoretime = 0f;
        ani = GetComponent<Animator>();

       
    }   
    

        
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(movespeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1, 1, 0);
            ani.SetBool("run", true);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-movespeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 0);
            ani.SetBool("run", true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            
        }
        else
        {
            ani.SetBool("run", false);
        }
        updatescore();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log(other.contacts[0].normal);
                Debug.Log(other.contacts[1].normal);
                Debug.Log("這階梯");
                currentfloor = other.gameObject;
                Modifyhp(1);
                other.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (other.gameObject.tag == "lava")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log(other.contacts[0].normal);
                Debug.Log(other.contacts[1].normal);
                Debug.Log("岩漿");
                currentfloor = other.gameObject;
                Modifyhp(-3);
                ani.SetTrigger("hurt");
                other.gameObject.GetComponent<AudioSource>().Play();
                this.gameObject.GetComponent<AudioSource>().Play();
                
            }
        }
        else if (other.gameObject.tag == "tenjio")
        {
            Debug.Log("頭破");
            currentfloor.GetComponent<BoxCollider2D>().enabled = false;
            ani.SetTrigger("hurt");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "deadline")
        {
            Debug.Log("GG");
            GG.gameObject.GetComponent<AudioSource>().Play();
            Time.timeScale= 0;
            replayButton.SetActive(true);
        }
    }

    void Modifyhp(int n)
    {
        hp += n;
        if (hp > 10)
        {
            hp = 10;
        }
        else if (hp <= 0)
        {
            hp = 0;
            
            GG.gameObject.GetComponent<AudioSource>().Play();
            Time.timeScale= 0;
            replayButton.SetActive(true);
            
            
        }
        updateheartbar();
    }

    void updateheartbar()
    {
        for (int i = 0; i < heartbar.transform.childCount; i++)
        {
            if (hp > i)
            {
                heartbar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                heartbar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void updatescore()
    {
        scoretime += Time.deltaTime;
        if (scoretime > 0.5F)
        {
            score++;
            scoretime = 0f;
            scoretext.text = "score: " + score.ToString();
        }
    }

    public void Replay(){

        Time.timeScale=1;
        SceneManager.LoadScene("SampleScene");
        

    }
}
