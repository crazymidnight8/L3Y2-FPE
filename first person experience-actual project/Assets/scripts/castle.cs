using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class castle : MonoBehaviour
{
    public int hp;
    int maxHp;

    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
        healthSlider.maxValue = hp;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = hp;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
