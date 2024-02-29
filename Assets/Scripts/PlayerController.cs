using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float horizontalInput;
    private float speed = 1000;
    public Text CounterText;
    private int count = 0;
    private float zpozsinir = 10.5f, znegsinir = -13f;
    private GameManeger gameManeger;
    public AudioSource playerSound;
    public AudioClip meyveSesi;
    public AudioClip saatSesleri;
    public AudioClip saatSesleri2;

    // Start is called before the first frame update
    void Start()
    {
    count = 0;
    playerRB = GetComponent<Rigidbody>();
        gameManeger = GameObject.Find("Game Manager").GetComponent<GameManeger>();
        playerSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        KarakterHareketi();
        KarakterSinirlama();
        

    }

    void KarakterHareketi()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRB.AddForce(Vector3.forward * speed * horizontalInput);
    }

    void KarakterSinirlama ()
    {
        if (transform.position.z > zpozsinir)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zpozsinir);
        }
        else if (transform.position.z < znegsinir)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, znegsinir);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Meyve1") && gameManeger.mey[0] > 0)
        {
            gameManeger.mey[0]--;
            gameManeger.meyve1.text = "Elma: " + gameManeger.mey[0];
            Destroy(other.gameObject);
            count += 1;
            CounterText.text = "Toplanan : " + count;
            playerSound.PlayOneShot(meyveSesi, 2.0f);
        }
        else if (other.gameObject.CompareTag("Meyve2") && gameManeger.mey[1] > 0)
        {
            gameManeger.mey[1]--;
            gameManeger.meyve2.text = "Armut: " + gameManeger.mey[1];
            Destroy(other.gameObject);
            count += 1;
            CounterText.text = "Toplanan : " + count;
            playerSound.PlayOneShot(meyveSesi, 2.0f);
        }
        else if (other.gameObject.CompareTag("Meyve3") && gameManeger.mey[2] > 0)
        {
            gameManeger.mey[2]--;
            gameManeger.meyve3.text = "Çilek: " + gameManeger.mey[2];
            Destroy(other.gameObject);
            count += 1;
            CounterText.text = "Toplanan : " + count;
            playerSound.PlayOneShot(meyveSesi, 2.0f);
        }
        else if (other.gameObject.CompareTag("Meyve4") && gameManeger.mey[3] > 0)
        {
            gameManeger.mey[3]--;
            gameManeger.meyve4.text = "Muz: " + gameManeger.mey[3];
            Destroy(other.gameObject);
            count += 1;
            CounterText.text = "Toplanan : " + count;
            playerSound.PlayOneShot(meyveSesi, 2.0f);
        }
        else if (other.gameObject.CompareTag("Meyve5") && gameManeger.mey[4] > 0)
        {
            gameManeger.mey[4]--;
            gameManeger.meyve5.text = "Viþne: " + gameManeger.mey[4];
            Destroy(other.gameObject);
            count += 1;
            CounterText.text = "Toplanan : " + count;
            playerSound.PlayOneShot(meyveSesi, 2.0f);
        }
        else if (other.gameObject.CompareTag("Saat1"))
        {
            gameManeger.kalanSure += 5;
            playerSound.PlayOneShot(saatSesleri, 2.0f);
        }
        else if (other.gameObject.CompareTag("Saat2"))
        {
            gameManeger.kalanSure -= 10;
            playerSound.PlayOneShot(saatSesleri2, 2.0f);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        
       
    }


}
