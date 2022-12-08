using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameManager gameManager;


    public List<Chel> cells;

    [SerializeField]
    private int maxCells = 5;


    public int id;



    private void Awake()
    {
        for (int i = 0; i < maxCells; i++)//make the house have [maxCells] of free space
        {
            cells.Add(null);
        }

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
