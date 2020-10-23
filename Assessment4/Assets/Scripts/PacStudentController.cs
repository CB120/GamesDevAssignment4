using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{

    private bool isMoving;
    private Vector3 endPoint;
    private float moveSpeed = 2f;
    private KeyCode lastInput;
    public Vector2 TileSize;


    private void CheckLastInput() // I wish this would work. :(
    {
        if (Input.anyKeyDown)
        {
            //lastInput = Event.current.keyCode;*/
            Debug.Log(lastInput);
            
        }
    } 



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
            lastInput = KeyCode.D;
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            
            endPoint = transform.position + new Vector3(-TileSize.x, 0, 0);
            StartCoroutine(Move());
            lastInput = KeyCode.A;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            endPoint = transform.position + new Vector3(0, TileSize.y, 0);
            StartCoroutine(Move());
            lastInput = KeyCode.W;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            endPoint = transform.position + new Vector3(0, -TileSize.y, 0);
            StartCoroutine(Move());
            lastInput = KeyCode.S;
        }

        CheckLastInput();

        if (isMoving == false)
        {
            if (lastInput == KeyCode.D){
                endPoint = transform.position + new Vector3(TileSize.x, 0, 0);
                StartCoroutine(Move());
                lastInput = KeyCode.D;
            } 
        }
        
        {
            if (lastInput == KeyCode.A)
            {
                endPoint = transform.position + new Vector3(-TileSize.x, 0, 0);
                StartCoroutine(Move());
                lastInput = KeyCode.A;
            }
        }
       
        {
            if (lastInput == KeyCode.W)
            {
                endPoint = transform.position + new Vector3(0, TileSize.y, 0);
                StartCoroutine(Move());
                lastInput = KeyCode.W;
            }
        }
        
        {
            if (lastInput == KeyCode.S)
            {
                endPoint = transform.position + new Vector3(0, -TileSize.y, 0);
                StartCoroutine(Move());
                lastInput = KeyCode.S;
            }
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
