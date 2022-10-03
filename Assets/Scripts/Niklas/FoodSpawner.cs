using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnPointTopBun, spawnPointBottomBun, spawnPointPatty, spawnPointPlate, spawnPointPan;
    Transform spawn;

    #region Singleton
    public static FoodSpawner instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public void SpawnBurger()
    {
        ObjectPooler.instance.SpawnFromPool("TopBun", spawnPointTopBun.transform.position, Quaternion.Euler(-90, 0, 0));
        ObjectPooler.instance.SpawnFromPool("Patty", spawnPointPatty.transform.position, Quaternion.Euler(-90, 0, 0));
        ObjectPooler.instance.SpawnFromPool("BottomBun", spawnPointBottomBun.transform.position, Quaternion.Euler(-90, 0, 0));
        AudioManager.instance.PlayOnceLocal("Food spawn", gameObject);
    }

    public void SpawnPlate()
    {
        GameObject plate = ObjectPooler.instance.SpawnFromPool("Plate", spawnPointPlate.transform.position, spawnPointPlate.transform.rotation);

        plate.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void SpawnPan()
    {
        GameObject pan = ObjectPooler.instance.SpawnFromPool("Pan", spawnPointPan.transform.position, spawnPointPan.transform.rotation);

        pan.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public void SpawnIngridient(string name)
    {
        ObjectPooler.instance.SpawnFromPool(name, spawn.position, Quaternion.identity);
    }

    public void SetSpawn(Transform spawnPoint)
    {
        spawn = spawnPoint;
    }
}
