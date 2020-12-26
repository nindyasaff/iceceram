using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float distance;

    public LineRenderer bulletLine;
    RaycastHit2D hitObject;

    [SerializeField]
    private HealthBar healthBar;
    public Health playerHealth;

    public int healthValue;

    private SpriteRenderer spriteFill;

    void Start()
    {
        spriteFill = transform.Find("HealthBar").Find("Fill").Find("SpriteFill").GetComponent<SpriteRenderer>();
        playerHealth = new Health(healthValue, spriteFill);
        healthBar.Setup(playerHealth);
    }

    void Update()
    {
        if(GameManager.instance.isPlaying == true)
        {
            playerHealth.GetColor();

            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Shoot());
            }

            if (playerHealth.GetHealthPercentage() <= 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    IEnumerator Shoot()
    {
        hitObject = Physics2D.Raycast(bulletLine.transform.position, bulletLine.transform.right, distance);
        
        if (hitObject)
        {
            if (hitObject.collider.gameObject.CompareTag("Bear") && GameManager.instance.onClick == false)
            {
                Bear bear = hitObject.collider.gameObject.GetComponent<Bear>();

                bear.GetDamage(damage);

                bulletLine.SetPosition(0, bulletLine.transform.position);
                bulletLine.SetPosition(1, hitObject.point);
            }
        }
        else
        {
            bulletLine.SetPosition(0, bulletLine.transform.position);
            bulletLine.SetPosition(1, bulletLine.transform.position + bulletLine.transform.right * distance);
        }

        bulletLine.enabled = true;

        yield return new WaitForSeconds(0.2f);

        bulletLine.enabled = false;
    }
}
