using UnityEngine;
using UnityEngine.UI;

public class Bear : MonoBehaviour
{
    [SerializeField] 
    private HealthBar healthBar;
    Health bearHealth;

    public int healthValue = 90;

    private SpriteRenderer spriteFill;

    void Start()
    {
        spriteFill = transform.Find("HealthBar").Find("Fill").Find("SpriteFill").GetComponent<SpriteRenderer>();
        bearHealth = new Health(healthValue, spriteFill);
        healthBar.Setup(bearHealth);
    }

    void Update()
    {
        bearHealth.GetColor();

        if(bearHealth.GetHealthPercentage() <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage)
    {
        bearHealth.GetDamage(damage);
    }
}
