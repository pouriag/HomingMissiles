using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    public GameObject road;
    public List<GameObject> spawnables;

    public int min, max;
    public int finalMin, finalMax;
    public float timeInterval;

    private List<float> xGrids, yGrids;

    private float totalTime = 0;
    private int origMin, origMax;
    private int modifier = 0;

    // Use this for initialization
    void Start()
    {
        origMin = min;
        origMax = max;

        xGrids = new List<float>() { 9.55f, 10.9f, 12.25f, 13.6f, 14.95f, 16.3f, 17.65f, 19f, 20.35f, 21.7f, 23.05f, 24.4f, 25.75f, 27.1f, 28.45f};
        yGrids = new List<float>() { 4.5f, 3.15f, 1.8f, 0.45f, -0.9f, -2.25f, -3.6f, -4.95f };
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;

        int division = (int)(totalTime / timeInterval);

        if (division > modifier)
        {
            modifier = division;
            
            if (min < finalMin)
            {
                min = origMin + modifier;
            }

            if (max < finalMax)
            {
                max = origMax + modifier;
            }
        }
    }

    public void SpawnObjects()
    {
        List<int> usedXGrids = new List<int>();
        List<int> usedYGrids = new List<int>();

        int spawnNum = Random.Range(min, max);

        while (spawnNum > 0)
        {
            spawnNum--;

            int i = Random.Range(0, spawnables.Count);

            int xInd;
            do
            {
                xInd = Random.Range(0, xGrids.Count);
            } while (usedXGrids.Contains(xInd));

            int yInd;
            do
            {
                yInd = Random.Range(0, yGrids.Count);
            } while (usedYGrids.Contains(yInd));

            usedXGrids.Add(xInd);
            usedYGrids.Add(yInd);
            float x = xGrids[xInd];
            float y = yGrids[yInd];

            GameObject newObj = Instantiate(spawnables[i], new Vector3(x, y, 0), Quaternion.identity);
            newObj.transform.parent = road.transform;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Background")
        {
            other.transform.position = new Vector3(17.7f, 0f, 0f);

            SpawnObjects();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
