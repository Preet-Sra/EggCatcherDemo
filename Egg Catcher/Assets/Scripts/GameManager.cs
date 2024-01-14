using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Eggs;
    [SerializeField] float YPosition, minXposition, maxXposition;
    [SerializeField] float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWait());
    }


    void Spawn()
    {
        Instantiate(Eggs, new Vector3(Random.Range(minXposition, maxXposition), YPosition, 0f), Quaternion.identity);
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(spawnTime);
        Spawn();
        StartCoroutine(SpawnWait());
    }
}
