using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;


    public List<Chel> allChels;
    private int lastChelID = 0;








    private void Awake()
    {
        if (instance == null)
            instance = new GameManager();
        DontDestroyOnLoad(gameObject);




        GameObject[] firstTwoChels = GameObject.FindGameObjectsWithTag("Chel");



        //shove it up some ugly cycle
        allChels.Add(firstTwoChels[0].GetComponent<Chel>());
        allChels.Add(firstTwoChels[1].GetComponent<Chel>());

        firstTwoChels[0].GetComponent<Chel>().gameManager = gameObject.GetComponent<GameManager>();
        firstTwoChels[1].GetComponent<Chel>().gameManager = gameObject.GetComponent<GameManager>();

        firstTwoChels[0].GetComponent<Chel>().id = lastChelID + 1;
        lastChelID += 1;
        firstTwoChels[1].GetComponent<Chel>().id = lastChelID + 1;
        lastChelID += 1;

    }


    // Start is called before the first frame update
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {
        //foreach(Chel chel in allChels)
        //{
        //    if()
        //}



    }


    public Chel LookForPair(Chel ChelLookingForPair)
    {
        foreach (Chel chel in allChels)
        {
            if (!chel.IsBusy() && chel.IsReady() && chel.id != ChelLookingForPair.id)
            {
                return chel;
            }
        }

        return null;

    }

}
