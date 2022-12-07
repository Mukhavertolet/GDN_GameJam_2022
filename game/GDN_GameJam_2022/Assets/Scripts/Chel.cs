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
    bool reproduceAttempt = false;

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
        if (!isBusy && isReady && !reproduceAttempt)
        {
            StartCoroutine(Reproduce(excitementMultiplier, this));
        }


        if (hunger <= 0)
            Death();
    }

    private IEnumerator RestoreReadiness(float excitementMultiplier)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(7.5f, 12.5f) / excitementMultiplier);

            isReady = true;
        }



        yield return null;
    }

    private IEnumerator Reproduce(float excitementMultiplier, Chel whoAsked)
    {
        reproduceAttempt = true;

        bool hasReproduced = false;


        while (!hasReproduced)
        {
            Chel pair = gameManager.LookForPair(whoAsked);

            if (pair != null)
            {
                //yield return new WaitUntil(() => pair.IsBusy() != true);

                whoAsked.isBusy = true;
                pair.isBusy = true;

                whoAsked.isReady = false;
                pair.isReady = false;


                //fuck
                Debug.Log("hehe heha");


                hasReproduced = true;

                whoAsked.isBusy = false;
                pair.isBusy = false;

                reproduceAttempt = false;
                yield return null;
            }
            else
            {
                //point and hearts go out
                Debug.Log("EHEHOHUI(((");

                yield return new WaitForSeconds(Random.Range(3f, 8f) / excitementMultiplier);
                whoAsked.isBusy = false;
            }
        }


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
