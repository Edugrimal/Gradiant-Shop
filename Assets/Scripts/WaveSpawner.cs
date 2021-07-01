using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum RoundState { IDLESHOP, DAYRUNNING, DAYEND };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemu;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 3f;
    public float waveCountdown;
    public RoundState Round;


    private RoundState state = RoundState.DAYRUNNING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (waveCountdown <= 0)
        {
            if (state != RoundState.DAYRUNNING)
            {
                //la tienda esta corriendo
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = RoundState.DAYRUNNING;

        //comienza el dia
        for (int i = 0; i < _wave.count; i++)
        {
            //spawn enemy
            SpawnEnemy();
            // tiempo que el cliente te va a esperar si no le vendes la pocion
            yield return new WaitForSeconds(25f / _wave.rate);
        }

        state = RoundState.IDLESHOP;
        yield break;
    }
    void SpawnEnemy()
    {
        // entra un cliente 
        Debug.Log("Entre un cliente");
    }
}

