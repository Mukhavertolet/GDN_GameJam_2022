using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chel : MonoBehaviour
{
    //temporary world point, need to get this from game manager later
    public Vector3 movementCenter = Vector3.zero;



    //hunger 
    private int maxHunger = 100;
    private float hunger;
    public float hungerDecreaseSpeed = 1;

    //state
    private bool isHomeless = true;
    private bool isBusy = false;
    private bool isReady = false;


    //housing
    public House house;
    public int cellNumber;


    //movement
    public float movementSpeed = 7.5f;
    public bool isWalking = false;



    // Start is called before the first frame update
    void Start()
    {
        hunger = maxHunger;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isWalking)
        {
            Debug.Log("Command");
            StartCoroutine(MoveToPoint(RandomPoint(movementCenter)));
        }


        if (hunger <= 0)
            Death();
    }

    public void Death()
    {
        //set this chel's house cell to FREE
        //increase death percentage
        Destroy(gameObject);
    }

    private IEnumerator MoveToPoint(Vector2 point)
    {
        Debug.Log("Moving...");
        isWalking = true;
        while (Vector2.Distance(transform.position, point) != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, point, movementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();

        }
        isWalking = false;
        Debug.Log("Moving finished");
        yield return null;

    }

    private Vector2 RandomPoint(Vector2 movementCenter)
    {
        Debug.Log("Generating point...");
        Vector2 newPoint = new Vector2(Random.Range(movementCenter.x - 10, movementCenter.x + 10),
                                       Random.Range(movementCenter.y - 5, movementCenter.y + 5));

        Debug.Log("New point = " + newPoint);
        return newPoint;

    }





}
