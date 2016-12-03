using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {
    public float rotation;
    float randomDistance;
    float randomFallDistance;
    Color usedColour;
    void Start ()
    {
        usedColour = transform.parent.gameObject.GetComponent<FireWorks>().colourOfFirework;
        gameObject.GetComponent<Renderer>().material.color = usedColour;
        gameObject.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", usedColour);
        randomDistance = Random.Range(0.1f, 10);
        randomFallDistance = Random.Range(7, 25);
        transform.Rotate(0, rotation, 0);
        StartCoroutine(shoot());
    }
	
    IEnumerator shoot()
    {
        int i = 0;
        while (i < randomDistance)
        {
            transform.Translate(Vector3.forward*0.2f);
            yield return new WaitForSeconds(Random.Range(0.001f,0.075f));
            i++;
        }
        int j = 0;
        transform.rotation = transform.parent.transform.rotation;
        transform.Rotate(-90, 0, 0);
        yield return new WaitForSeconds(0.5f - randomDistance/15f);
        //this.GetComponent<TrailRenderer>().enabled = false;
        while (j < randomFallDistance)
        {
            transform.Translate(Vector3.forward* 10 * Time.deltaTime);
            yield return new WaitForSeconds(Random.Range(0.001f, 0.075f));
            j++;
        }
        Destroy(this.gameObject);
    }
}
