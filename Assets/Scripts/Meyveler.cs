using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meyveler : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameManeger gameManeger;
    private float speed;


    // Start is called before the first frame update
    
    void Start()
    {
        float tork = Random.Range(-10, 10); //rastgele ne tarafa d�nece�ini ayarlad�k
        float speed = Random.Range(10, 15); // rastgele uygulanan kuvvetin h�z�n� ayarlad�k

        enemyRB = GetComponent<Rigidbody>();
        gameManeger = GameObject.Find("Game Manager").GetComponent<GameManeger>();
        enemyRB.AddForce(Vector3.down * speed, ForceMode.Impulse);
        enemyRB.AddTorque(tork, tork, tork);
        transform.position = randomPozisyon(); //Pozisyonunu ayarlad�k
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    Vector3 randomPozisyon()
    {
        float startPosX = -7.37f,startposy=23, startPosZ = Random.Range(-13f, 10.5f);
        return new Vector3(startPosX, startposy, startPosZ);
    }
}
