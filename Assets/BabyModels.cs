using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyModels : MonoBehaviour
{

    public Transform[] babyModels;
//    private bool modelChosen;

    void Start()
    {
        AssignModel((int)(Random.value * 4));
    }

    void Update()
    {
//        if (modelChosen) return;
//        int playerCount = FindObjectsOfType<PlayerDetails>().Length;
//        modelChosen = true;
    }

    public void AssignModel(int modelNumber)
    {
        for (var i = 0; i < babyModels.Length; i++)
        {
            var babyModel = babyModels[i];
            babyModel.gameObject.SetActive(i==modelNumber);
        }
    }
}
