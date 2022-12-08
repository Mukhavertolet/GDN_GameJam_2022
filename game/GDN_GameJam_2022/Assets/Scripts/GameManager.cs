using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //thingies
    private static GameManager instance;

    [SerializeField] private Vector3 mouseWorldPosition;




    //chels info
    public List<Chel> allChels;
    private int lastChelID = -1;

    //houses info
    public List<House> allHouses;
    private int lastHouseID = -1;


    //prefabs to birth
    public GameObject chel;


    //prefabs to build
    public GameObject house;




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
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            BuildHouse(mouseWorldPosition, house.GetComponent<House>());
        }
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
            AddChelToTheList(chelNew.GetComponent<Chel>());
        }
    }

    public void BuildHouse(Vector3 mousePos, House house /*resources needed and taken*/)
    {
        House newHouse = Instantiate(house, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
        AddHouseToTheList(newHouse);

    }



    private void AddChelToTheList(Chel chelToAdd)
    {
        allChels.Add(chelToAdd);
        chelToAdd.gameManager = gameObject.GetComponent<GameManager>();
        chelToAdd.id = lastChelID + 1;
        lastChelID += 1;
    }

    private void AddHouseToTheList(House houseToAdd)
    {
        allHouses.Add(houseToAdd);
        houseToAdd.gameManager = gameObject.GetComponent<GameManager>();
        houseToAdd.id = lastHouseID + 1;
        lastHouseID += 1;
    }

}
