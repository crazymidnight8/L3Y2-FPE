using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle : MonoBehaviour
{
    public int hp;
    int maxHp;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
