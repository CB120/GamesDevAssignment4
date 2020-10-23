using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject Computer;
    private float SpawnTime = 30f;
    private float moveSpeed = 2f;
    private float lifetime = 31f;
    
    //public Transform Spawn;
    
    void SpawnComputer()
    {
        GameObject Cherry = Instantiate(Computer) as GameObject;
        Cherry.name = Computer.name;
        Cherry.transform.position = new Vector2(35, -2.5f);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnComputer", SpawnTime, SpawnTime);
        Destroy(Computer, lifetime);
    }


   






    // Update is called once per frame
    void Update()
    {

        Vector3 startPoint = Computer.transform.position;

        Vector2 endPoint = Computer.transform.position + new Vector3(-1,0,0);

        if (GameObject.Find("Computer") != null)
        {
            Computer.transform.position = Vector2.Lerp(startPoint, endPoint, moveSpeed * Time.deltaTime);
        }
    }
}
