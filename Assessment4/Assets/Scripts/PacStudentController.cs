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
    private Animator anim;
    private AudioSource PacMove;
    public ParticleSystem PlayerParticle;
    public GameObject Wall;
    private AudioSource PacCollide;
    public GameObject pellet;

    private void CheckLastInput() // This didnt fully work :(
    {
        if (Input.anyKeyDown)
        {
            //lastInput = Event.current.keyCode;*/
            Debug.Log(lastInput);

        }
    }

    private void PacMoveAudio()
    {
        PacMove.loop = true;
        PacMove.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        PacMove = gameObject.GetComponent<AudioSource>();
        anim.StopPlayback();
        PacCollide = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {

            endPoint = transform.position + new Vector3(TileSize.x, 0, 0);
            StartCoroutine(Move());
            lastInput = KeyCode.D;
            anim.Play("PlayerAnim");
            PacMoveAudio();
            PacStudentDust();

        }


        if (Input.GetKeyDown(KeyCode.A))
        {

            endPoint = transform.position + new Vector3(-TileSize.x, 0, 0);
            StartCoroutine(Move());
            lastInput = KeyCode.A;
            PacMoveAudio();
            PacStudentDust();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            endPoint = transform.position + new Vector3(0, TileSize.y, 0);
            StartCoroutine(Move());
            lastInput = KeyCode.W;
            PacMoveAudio();
            PacStudentDust();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            endPoint = transform.position + new Vector3(0, -TileSize.y, 0);
            StartCoroutine(Move());
            lastInput = KeyCode.S;
            PacMoveAudio();
            PacStudentDust();
        }

        CheckLastInput();

        if (Input.GetKeyDown(KeyCode.Space)) // Just for testing purposes
        {
            isMoving = false;
            lastInput = KeyCode.Space;
            PlayerParticle.Stop();
        }



        if (isMoving == false)
        {
            PacMove.Stop();
            if (lastInput == KeyCode.D)
            {
                endPoint = transform.position + new Vector3(TileSize.x, 0, 0);
                StartCoroutine(Move());
                lastInput = KeyCode.D; // I feel like currentInput is unnecessary. If i find any problems with this system ill add CurrentInput and find a solution using it. 
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

        if (lastInput == KeyCode.Space) // Just for testing purposes
        {
            isMoving = false;
        }

    }

    IEnumerator Move()
    {
        if (isMoving)
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


    void PacStudentDust()
    {
        PlayerParticle.Play();
    }

    private void OnCollisionStay2D(Collision2D Wall)
    {
        
        if (Wall.gameObject.CompareTag("Arena"))
        {
            //isMoving = false;
            Debug.Log("Collision Stay : " + Wall);
            PlayerParticle.Stop();
            PacCollide.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D Pellet)
    {
        Destroy(pellet);
    }

}


