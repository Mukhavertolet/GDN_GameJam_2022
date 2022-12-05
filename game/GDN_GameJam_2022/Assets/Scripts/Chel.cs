using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chel : MonoBehaviour
{
    //greater powers
    public GameManager gameManager;


    //stats
    public int id;



    //temporary world point, need to get this from game manager later
    public Vector3 movementCenter = Vector3.zero;



    //hunger 
    private int maxHunger = 100;
    private float hunger;
    public float hungerDecreaseSpeed = 1;

    //state
    [SerializeField] private bool isHomeless = true;
    [SerializeField] private bool isBusy = false;
    [SerializeField] private bool isReady = false;

    private bool isAllowedToWalk = true;


    //housing
    public House house;
    public int cellNumber;


    //movement
    public float movementSpeed = 7.5f;
    public bool isWalking = false;
    public float movementTimerMultiplier = 1;

    //reproducing
    public float excitementMultiplier = 1;




    // Start is called before the first frame update
    void Start()
    {
        hunger = maxHunger;

        StartCoroutine(RandomMoveTimer(movementTimerMultiplier));

        StartCoroutine(RestoreReadiness(excitementMultiplier));

    }

    // Update is called once per frame
    void Update()
    {

        if (hunger <= 0)
            Death();
    }

    private IEnumerator RestoreReadiness(float excitementMultiplier)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(7.5f, 12.5f) / excitementMultiplier);

            isReady = true;
            if (!isBusy && isReady)
            {
                StartCoroutine(Reproduce(excitementMultiplier));
            }
        }



        yield return null;
    }

    private IEnumerator Reproduce(float excitementMultiplier)
    {

        if(AskForPair(this) != null)
        {
            isBusy = true;
            //fuck
            Debug.Log("hehe heha");
            isReady = false;
        }
        else
        {
            //point and hearts go out
            Debug.Log("EHEHOHUI(((");
            yield return new WaitForSeconds(Random.Range(3f, 5f) * excitementMultiplier);
        }

        isBusy = false;


        yield return null;
    }

    private Chel AskForPair(Chel whoAsked)
    {
        return gameManager.LookForPair(whoAsked);
    }




    public void Death()
    {
        //set this chel's house cell to FREE
        //increase death percentage
        Destroy(gameObject);
    }

    private IEnumerator MoveToPoint(Vector2 point)
    {
        isWalking = true;
        while (Vector2.Distance(transform.position, point) != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, point, movementSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();

        }
        isWalking = false;
        yield return null;

    }

    private Vector2 RandomPoint(Vector2 movementCenter)
    {
        Vector2 newPoint = new Vector2(Random.Range(movementCenter.x - 10, movementCenter.x + 10),
                                       Random.Range(movementCenter.y - 5, movementCenter.y + 5));
        return newPoint;

    }

    private IEnumerator RandomMoveTimer(float timeMultiplier)
    {
        while (true)
        {
            if (isAllowedToWalk && !isWalking)
            {
                StartCoroutine(MoveToPoint(RandomPoint(movementCenter)));
            }

            yield return new WaitForSeconds(Random.Range(0.75f, 5f) * timeMultiplier);

        }


        yield return null;
    }





    public bool IsReady()
    {
        return isReady;
    }
    public bool IsBusy()
    {
        return isBusy;
    }

}
