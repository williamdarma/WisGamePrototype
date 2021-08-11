using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class rumahScript : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] Image slider;
    [SerializeField] Transform spawnpointTank;
    public GameObject tankPrefabs;
    [SerializeField] List<GameObject> listTank = new List<GameObject>();
    int totalPool = 5;
    float increaseValue = .5f;
    float limitTimer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        initTank();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=limitTimer)
        {
            timer = 0;
            spawnTank();
        }
        userTap();
        updateSlider(timer);

    }

    void userTap()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            timer += increaseValue;
        }
    }

    void initTank()
    {
        for (int i = 0; i < totalPool;i++)
        {
            GameObject tank = Instantiate(tankPrefabs, gameObject.transform);
            listTank.Add(tank);
            tank.SetActive(false);
        }
    }
    private void spawnTank()
    {
        foreach(GameObject go in listTank)
        {
            if (!go.activeInHierarchy)
            {
                go.SetActive(true);
                go.transform.position = spawnpointTank.transform.position;
                go.transform.rotation = spawnpointTank.transform.rotation;
                break;
            }
        }
    }

    void updateSlider(float t)
    {
        slider.fillAmount = t / 10;
    }
}
