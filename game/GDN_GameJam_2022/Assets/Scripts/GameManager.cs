using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Chel> allChels;









    private void Awake()
    {
        GameObject[] firstTwoChels = GameObject.FindGameObjectsWithTag("Chel");

        allChels.Add(firstTwoChels[0].GetComponent<Chel>());
        allChels.Add(firstTwoChels[1].GetComponent<Chel>());
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
