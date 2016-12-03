using UnityEngine;
using System.Collections;

public class FireWorks : MonoBehaviour {
    public float velocity = 5;
    Debris debrisClass;
    public int numberofdebris;
    bool stopped = false;
    public GameObject debris;
    float rotation = 0;
    public Color colourOfFirework;
    void Flying()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
    Color returnRandomColour()
    {
        int randomizer = Random.Range(1, 5);
        if (randomizer == 1)
            return Color.blue;
        if (randomizer == 2)
            return Color.green;
        if (randomizer == 3)
            return Color.red;
        if (randomizer == 4)
            return Color.magenta;
        if (randomizer == 5)
            return Color.yellow;
        return Color.yellow;
    }
    void Start()
    {
        colourOfFirework = returnRandomColour();
        gameObject.GetComponent<Renderer>().material.color = colourOfFirework;
        gameObject.GetComponent<TrailRenderer>().material.SetColor("_EmissionColor", colourOfFirework);
        this.transform.Rotate(-90, 0, 0);
        velocity = Random.Range(5, 8);
        rotation = 0;
        stopped = false;
        numberofdebris = Random.Range(25, 100);
    }
    void Update()
    {
        Debug.Log(velocity);

        if (velocity > -1f && stopped == false)
        {
            velocity -= 0.05f;
            Flying();
        }
        else
        {
            velocity = 0;
            stopped = true;
            for (int i = 1; i <= numberofdebris; i++)
            {
                GameObject temp;
                rotation += 360 / numberofdebris + 1;
                temp = Instantiate(debris, this.transform.position, Quaternion.identity) as GameObject;
                temp.transform.parent = this.transform;
                debrisClass = temp.gameObject.GetComponent<Debris>();
                debrisClass.rotation = rotation;
            }
            this.transform.Rotate(-90, 0, 0);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(this);
        }
    }
}
