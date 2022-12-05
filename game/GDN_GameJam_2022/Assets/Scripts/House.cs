using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public List<Chel> cells;

    [SerializeField]
    private int maxCells = 5;



    private void Awake()
    {
        for (int i = 0; i < maxCells; i++)
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
