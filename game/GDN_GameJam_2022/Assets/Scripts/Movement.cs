using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0f;

    private Vector3 startPosition;
    private Vector2 newPoint;
    private bool isWalking = false;
    

    void Start()
    {
        startPosition = transform.position;
        

        


    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewPoint();

            StartCoroutine(CharacterMovement());
        }



        //transform.position = Vector2.Lerp(transform.position, newPoint, Time.deltaTime);


        //if(timeLeft>0)
        //    timeLeft -= Time.deltaTime;
        //else
        //{


        //    if (Vector2.Distance(transform.position, newPoint) != 0)
        //    {
        //        while (Vector2.Distance(transform.position, newPoint) > 0.01f)
        //        {
        //            transform.position = Vector2.Lerp(transform.position, newPoint, Time.deltaTime / 2);
        //        }
        //    }
        //    else
        //    {
        //        timeLeft = time;
        //        newPoint = new Vector2(Random.Range(startPosition.x - 10, startPosition.x + 10),
        //                               Random.Range(startPosition.y - 5, startPosition.y + 5));
        //    }

        //}












    }

    IEnumerator CharacterMovement()
    {
        isWalking = true;
        while (Vector2.Distance(transform.position,newPoint)!=0)
        {
            transform.position = Vector2.MoveTowards(transform.position, newPoint, speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        
        }
        isWalking=false;
        yield return null;
    }
    
    void NewPoint()
    {
        newPoint = new Vector2(Random.Range(startPosition.x - 10, startPosition.x + 10),
                                       Random.Range(startPosition.y - 5, startPosition.y + 5));
    }

}
