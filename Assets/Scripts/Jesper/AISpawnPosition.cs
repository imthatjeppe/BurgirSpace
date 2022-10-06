using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnPosition : MonoBehaviour
{
    public GameObject[] robots;
    public List<GameObject> aiSpawnPosition = new List<GameObject>();
    public int positions;

    int randomIndex;
    int positionsUsed;
    void Start()
    {
        randomIndex = Random.Range(0, robots.Length);
        positionsUsed = Random.Range(0, positions);

        for (int i = 0; i < positionsUsed; i++)
        {
            GameObject Robot = Instantiate(robots[randomIndex], aiSpawnPosition[positionsUsed].transform.position, aiSpawnPosition[positionsUsed].transform.rotation);
            Robot.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Eating");
            randomIndex = Random.Range(0, robots.Length);
            positionsUsed = Random.Range(0, positions);
        }

    }
}