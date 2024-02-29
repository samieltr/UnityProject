using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManeger : MonoBehaviour
{
    public List<GameObject> meyveler;
    private float spawnSuresi = 1.5f;
    public bool oyunAktifmi = true;
    public bool oyunKazan = false;
    public TextMeshProUGUI geriSayim;
    public TextMeshProUGUI GameOverText;
    private float geriSayimSuresi = 60f;
    public Button startButton;
    public Button restartButton;
    public float kalanSure;
    public TextMeshProUGUI meyve1, meyve2, meyve3, meyve4, meyve5,winGameText;
    public int[] mey = new int[5];
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator SpawnGenerator()
    {
        while (oyunAktifmi == true)
        {
            yield return new WaitForSeconds(spawnSuresi); //spawn süresi
            int index = Random.Range(0,meyveler.Count);
            Instantiate(meyveler[index]);
        }
    }

    IEnumerator GeriSayimfonk()
    {
        while (kalanSure > 0 && oyunAktifmi == true)
        {
            kalanSure -=Time.deltaTime;
            int tamSayiSure = Mathf.RoundToInt(kalanSure);
            geriSayim.text = "Kalan Süre: " + tamSayiSure;
            winGame();

            if (kalanSure <= 0)
            {
                oyunAktifmi = false;
                gameOver();
            }
            yield return null;
        }

     
    }

   public void StartGame()
    {
        oyunAktifmi = true;
        StartCoroutine(SpawnGenerator());
        startButton.gameObject.SetActive(false);
        Gorev();
        kalanSure = geriSayimSuresi;
        StartCoroutine(GeriSayimfonk());
     
      

    }

    public void gameOver()
    {
        if(oyunAktifmi==false && oyunKazan == false )
        {
            GameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void winGame()
    {
        if (mey[0] == 0 && mey[1] == 0 && mey[2] == 0 && mey[3] == 0 && mey[4] == 0)
        {
            oyunKazan = true;
            winGameText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void restart ()
    {
        GameOverText.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Gorev ()
    {
        for (int i = 0; i < mey.Length; i++)
        {
            int rastgeleSayi = Random.Range(1, 11); // Her iterasyonda yeni bir rastgele sayý oluþturun
            mey[i] = rastgeleSayi; // Her meyveye farklý bir rastgele sayýyý atayýn
        }
        meyve1.text = "Elma: " + mey[0];
        meyve2.text = "Armut: " + mey[1];
        meyve3.text = "Çilek: " + mey[2];
        meyve4.text = "Muz: " + mey[3];
        meyve5.text = "Viþne: " + mey[4];

    }
}
