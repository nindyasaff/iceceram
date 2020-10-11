using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float distance;

    public Transform bulletPoint;

    public LineRenderer bulletLine;
    RaycastHit2D hitObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        hitObject = Physics2D.Raycast(bulletPoint.position, bulletPoint.right, distance);
        
        if (hitObject)
        {
            if (hitObject.collider.gameObject.CompareTag("Bear"))
            {
                Bear bear = hitObject.collider.gameObject.GetComponent<Bear>();

                bear.GetDamage(damage);

                bulletLine.SetPosition(0, bulletPoint.position);
                bulletLine.SetPosition(1, hitObject.point);
            }

            
        }
        else
        {
            bulletLine.SetPosition(0, bulletPoint.position);
            bulletLine.SetPosition(1, bulletPoint.position + bulletPoint.right * distance);
        }

        bulletLine.enabled = true;

        yield return new WaitForSeconds(0.2f);

        bulletLine.enabled = false;
    }
}
