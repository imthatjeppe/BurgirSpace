using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnPosition : MonoBehaviour
{
    public GameObject[] robots;
    public List<GameObject> aiSpawnPosition = new List<GameObject>();
    int positions;

    int randomIndex;
    int positionsUsed;
    int amountOfRobots = 0;
    void Start()
    {
        randomIndex = Random.Range(0, robots.Length);
        positionsUsed = Random.Range(1, positions);
        positions = aiSpawnPosition.Count;

        InvokeRepeating("SpawnRobots", 0, 3f);

    }

    void SpawnRobots()
    {
        if (amountOfRobots >= positionsUsed) {CancelInvoke("SpawnRobots"); return; }

        GameObject Robot = Instantiate(robots[randomIndex], aiSpawnPosition[positionsUsed].transform.position, aiSpawnPosition[positionsUsed].transform.rotation);
        Robot.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Eating");
        randomIndex = Random.Range(0, robots.Length);
        positionsUsed = Random.Range(0, positions);

        amountOfRobots++;
    }
}