﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBotttomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i <numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBotttomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public  void AppleDestroyed()
    {
        //destoryall the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);

        }
        //destory one of the baskets 
        // get the index of the last basket in basketlist
        int basketIndex = basketList.Count - 1;
        //get a reference to the basket gameobject 
        GameObject tbasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tbasketGo);

        if(basketList.Count == 0)
        {
            //Application.LoadLevel("level_2");
            SceneManager.LoadScene("Level_2");
            
        }
    }
}
