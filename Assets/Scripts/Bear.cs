using UnityEngine;
using UnityEngine.UI;

public class Bear : MonoBehaviour
{
    public int health;

    public Slider sliderHealth;

    void Start()
    {
        sliderHealth.maxValue = health;
    }

    void Update()
    {
        sliderHealth.value = health;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }
}
