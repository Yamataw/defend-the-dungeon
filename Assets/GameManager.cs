using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int KillCount;
    public static GameManager Instance;
    public TextMeshProUGUI   KillCountText;
    public TextMeshProUGUI EndCounterText;
    public GameObject Panel;

    public GameObject Bandit;
    private float elapsedTime;
    public bool StillCount;

    void Start()
    {
        StillCount = true;
        Panel.SetActive(false);

        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        KillCount = 0;
        KillCountUpdate();

        StartCoroutine(_generateMobsUntilYouDie());

    }

    private void Update()
    {
        if (StillCount) elapsedTime += Time.deltaTime;

    }

    public void KillCountUpdate()
    {
        KillCountText.text = ": " + KillCount.ToString(); 
    }

    public float initialGenerationDelay = 7f;    
    public float minGenerationDelay = 2f;       
    public float accelerationTime = 300f;
    private float currentGenerationDelay;


    private IEnumerator _generateMobsUntilYouDie()
    {

        while (true) {
            Instantiate(Bandit, new Vector3(10f,-0.51f,0f), Quaternion.identity);
            currentGenerationDelay = Mathf.Lerp(initialGenerationDelay, minGenerationDelay, Time.time / accelerationTime);

            yield return new WaitForSeconds(currentGenerationDelay); 

        }
    }



    public void UpdateEnd()
    {
        StillCount = false;
        EndCounterText.text = Math.Round(elapsedTime, 1, MidpointRounding.AwayFromZero).ToString() + " secondes";
        Debug.Log(elapsedTime);
        Panel.SetActive(true);


    }
}
