using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private const float distance = 17.5f;
    [SerializeField] private bool spawned;
   // [SerializeField] private int LVspawn;
    GameObject player;
    LVTemplates LV;
    private void Start()
    {
        LV = GameObject.FindGameObjectWithTag("LV").GetComponent<LVTemplates>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < distance && spawned==false)
        {
            SpawnLV();
            LV.spawn++;
            spawned= true;
        }
    }
    private void SpawnLV()
    {
        int random = Random.Range(0, LV.LV.Length);
        Instantiate(LV.LV[random], transform.position, Quaternion.identity);
    }
}
