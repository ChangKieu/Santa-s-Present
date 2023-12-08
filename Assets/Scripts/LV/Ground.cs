using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ground : MonoBehaviour
{
    Renderer ren;
    public Vector3 size,pos,posBang,posGai,posBang2;
    bool check = true;
    public GameObject[] boss,lv1;
    public GameObject bang,gai,bang2,heart;
    int capdo;
    LVTemplates LV;
    private void Start()
    {
        ren = GetComponent<Renderer>();
        LV = GameObject.FindGameObjectWithTag("LV").GetComponent<LVTemplates>();
        size = ren.bounds.size;
        pos = new Vector3(transform.position.x,transform.position.y+size.y, 0.1f);
        posBang = new Vector3(transform.position.x+size.x/2, transform.position.y + size.y, transform.position.z);
        posGai = new Vector3(transform.position.x + size.x / 2, transform.position.y + size.y*2, transform.position.z);
        posBang2 = new Vector3(transform.position.x-size.x/2, transform.position.y + 10f, transform.position.z);
    }
    private void Update()
    {
        if(check)
        {
            if(LV.spawn<3)
            {
                capdo = 0;
            }
            else if(LV.spawn<10)
            {
                capdo = 1;
            }
            else if(LV.spawn<15)
            {
                capdo = 2;
            }
            else if(LV.spawn<25)
            {
                capdo = 3;
            }
            else if(LV.spawn>25)
            {
                capdo = 4;
            }
            int option=Random.Range(0,capdo);
            if(option==0)
            {
                int ran = Random.Range(0, lv1.Length);
                if (ran == 0 && size.x>10) pos.y -= 0.4f;
                if (ran == 1 && size.x < 10) pos.y -= 0.5f;
                Instantiate(lv1[ran], pos, Quaternion.identity);
                check = false;
            }
            else if(option==1)
            {
                int ran = Random.Range(0, lv1.Length+1);
                if (ran == 0)
                {
                    pos.y -= 0.4f;
                }
                if(ran==1 && size.x <7)
                {
                    pos.y -= 1;
                }
                if(ran<lv1.Length) Instantiate(lv1[ran], pos, Quaternion.identity);
                else Instantiate(heart, pos, Quaternion.identity);
                check = false;
            }
            else if(option==2)
            {
                int ran = Random.Range(0, boss.Length);
                Instantiate(boss[ran], pos, Quaternion.identity);
                check = false;
            }
            else if(option==3) 
            {
                Instantiate(gai, posGai, Quaternion.identity);
                check = false;
            }
            else if(option==4)
            {

                StartCoroutine(ExampleCoroutine());
                check = false;
            }
            else
            {
                Instantiate(bang, posBang, Quaternion.identity);
                check = false;
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        Instantiate(bang2, posBang2, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        posBang2.x += size.x / 4;
        Instantiate(bang2, posBang2, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        posBang2.x += size.x / 4;
        Instantiate(bang2, posBang2, Quaternion.identity);
        //Neu size>10
        if(size.x>10)
        {
            yield return new WaitForSeconds(0.5f);
            posBang2.x += size.x / 4;
            Instantiate(bang2, posBang2, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            posBang2.x += size.x / 4;
            Instantiate(bang2, posBang2, Quaternion.identity);
        }
        
    }
}
