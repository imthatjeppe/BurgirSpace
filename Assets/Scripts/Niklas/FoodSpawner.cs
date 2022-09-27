using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnPointTopBun, spawnPointBottomBun, spawnPointPatty, spawnPointPlate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBurger();
        }
    }

    public void SpawnBurger()
    {
        ObjectPooler.instance.SpawnFromPool("TopBun", spawnPointTopBun.transform.position, Quaternion.Euler(-90, 0, 0));
        ObjectPooler.instance.SpawnFromPool("Patty", spawnPointPatty.transform.position, Quaternion.Euler(-90, 0, 0));
        ObjectPooler.instance.SpawnFromPool("BottomBun", spawnPointBottomBun.transform.position, Quaternion.Euler(-90, 0, 0));
    }

    public void SpawnPlate()
    {
        ObjectPooler.instance.SpawnFromPool("Plate", spawnPointTopBun.transform.position, spawnPointTopBun.transform.rotation);
    }
}
