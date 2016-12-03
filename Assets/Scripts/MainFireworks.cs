using UnityEngine;
using System.Collections;

public class MainFireworks : MonoBehaviour {
    public GameObject Firework;
    Vector3 positionWhereToSpawn;
	void Start ()
    {
        positionWhereToSpawn = new Vector3(0, -5, 0);
        StartCoroutine(spawnFireworks());
	}
	IEnumerator spawnFireworks()
    {
        while (true)
        {
            positionWhereToSpawn.x = Random.Range(-8.75f, 8.75f);
            StartCoroutine(cleanup(Instantiate(Firework, positionWhereToSpawn, Quaternion.identity) as GameObject));
            yield return new WaitForSeconds(0.25f);
        }
    }
    IEnumerator cleanup(GameObject whatToClean)
    {
        yield return new WaitForSeconds(10f);
        Destroy(whatToClean.gameObject);
    }
}
