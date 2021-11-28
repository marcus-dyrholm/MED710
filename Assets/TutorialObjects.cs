using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjects : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform[] cubPos;
    public List<GameObject> cubes;
    private Rigidbody cubeRB;
    float range1, range2;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            CreateCubes();
        }
    }

    public void CreateCubes()
    {
        if (cubes.Count > 0)
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                Destroy(cubes[i]);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject cube = Instantiate(cubePrefab, cubPos[Random.Range(0,cubPos.Length)]);
            cube.GetComponent<TutorialCube>().ID = i;
            cubes.Add(cube);
            cubeRB = cube.GetComponent<Rigidbody>();
            cubeRB.mass = Random.Range((float)i + 1.0f, (float)i + 2.0f);
        }
        
    }

}
