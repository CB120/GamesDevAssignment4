using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{

    private bool isMoving;
    private Vector3 endPoint;
    private float moveSpeed = 10f;

    public Vector2 TileSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //isMoving = true;
            endPoint = transform.position + new Vector3(TileSize.x, 0, 0);
            StartCoroutine(Move());
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            //isMoving = true;
            endPoint = transform.position + new Vector3(-TileSize.x, 0, 0);
            StartCoroutine(Move());
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            //isMoving = true;
            endPoint = transform.position + new Vector3(0, TileSize.y, 0);
            StartCoroutine(Move());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //isMoving = true;
            endPoint = transform.position + new Vector3(0, -TileSize.y, 0);
            StartCoroutine(Move());
        }

    }

    IEnumerator Move()
    {
        if(isMoving)
        {
            yield break;
        }

        isMoving = true;
        Vector3 startPoint = transform.position;
        while (MoveToPoint(startPoint)) { yield return null; }
        


        isMoving = false;
    }
    bool MoveToPoint(Vector3 StartPoint)
    {
        return endPoint != (transform.position = Vector3.MoveTowards(transform.position, endPoint, moveSpeed * Time.deltaTime));
    }
}
