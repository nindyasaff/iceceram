using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bear : MonoBehaviour
{
    public int damage;
    public float distance;

    public Transform bulletPoint;

    public LineRenderer bulletLine;
    RaycastHit2D hitObject;

    public bool onShoot = false;

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
        if(GameManager.instance.isPlaying == true)
        {
            if (!onShoot)
            {
                StartCoroutine(CallShot());
                onShoot = true;
            }

            bearHealth.GetColor();

            if (bearHealth.GetHealthPercentage() <= 0)
            {
                Destroy(gameObject);
                GameManager.instance.Win();
            }
        }
    }

    public void GetDamage(int damage)
    {
        bearHealth.GetDamage(damage);
    }

    IEnumerator Shoot()
    {
        
        hitObject = Physics2D.Raycast(bulletPoint.position, bulletPoint.right * -1, distance);

        if (hitObject)
        {
            if (hitObject.collider.gameObject.CompareTag("Player") && GameManager.instance.onClick == false)
            {
                Attack player = hitObject.collider.gameObject.GetComponent<Attack>();

                player.playerHealth.GetDamage(damage);

                bulletLine.SetPosition(0, bulletPoint.position);
                bulletLine.SetPosition(1, hitObject.point);
            }
        }
        else
        {
            bulletLine.SetPosition(0, bulletPoint.position);
            bulletLine.SetPosition(1, bulletPoint.position + bulletPoint.right * -1 * distance);
        }

        bulletLine.enabled = true;

        yield return new WaitForSeconds(0.5f);

        bulletLine.enabled = false;
    }

    IEnumerator CallShot()
    {
        StartCoroutine(Shoot());
        yield return new WaitForSeconds(3);
        onShoot = false;
    }
}
