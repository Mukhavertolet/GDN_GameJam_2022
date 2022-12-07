using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;


    public List<Chel> allChels;
    private int lastChelID = 0;



    public GameObject chel;




    private void Awake()
    {
        if (instance == null)
            instance = new GameManager();
        DontDestroyOnLoad(gameObject);




        GameObject[] firstTwoChels = GameObject.FindGameObjectsWithTag("Chel");



        //first 2 chels that appear at the start of the game are shoved into the list here
        for (int i = 0; i < 2; i++)
        {
            allChels.Add(firstTwoChels[i].GetComponent<Chel>());
            firstTwoChels[i].GetComponent<Chel>().gameManager = gameObject.GetComponent<GameManager>();

            firstTwoChels[i].GetComponent<Chel>().id = lastChelID + 1;
            lastChelID += 1;
        }


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

    public void Birth(Vector3 firstParentPos, Vector3 secondParentPos, int amountOfChildren)
    {
        for (int i = 0; i < amountOfChildren; i++)
        {
            GameObject chelNew = Instantiate(chel, Vector3.Lerp(firstParentPos, secondParentPos, 0.5f), Quaternion.identity);
            Debug.Log("BUEHWowaowaowaosouuuuhhh.....");
            AddToTheList(chelNew.GetComponent<Chel>());
        }
    }

    private void AddToTheList(Chel chelToAdd)
    {
        allChels.Add(chelToAdd);
        chelToAdd.gameManager = gameObject.GetComponent<GameManager>();
        chelToAdd.id = lastChelID + 1;
        lastChelID += 1;
    }


}
