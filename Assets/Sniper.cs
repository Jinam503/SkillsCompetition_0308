using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Enemy
{
    public GameObject warningBox;
    public GameObject bullet;
    

    private bool isAiming = true;
    SpriteRenderer warningBoxSpritrRenderer;
    protected override void Awake()
    {
        base.Awake();
        hp = 10;
        
        warningBoxSpritrRenderer = warningBox.GetComponent<SpriteRenderer>();
        StartCoroutine(Attack());

    }
    void Update()
    {
        if (hp <= 0) Destroy(gameObject);
        if (isAiming)
        {
            Vector3 dir = target.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
        }
        
        
    }
    IEnumerator Attack()
    {
        
        warningBox.gameObject.SetActive(true);
        warningBoxSpritrRenderer.material.color =
            new Color(warningBoxSpritrRenderer.material.color.r,
                      warningBoxSpritrRenderer.material.color.g,
                      warningBoxSpritrRenderer.material.color.b, 1f);
        yield return new WaitForSeconds(0.5f);
        warningBoxSpritrRenderer.material.color =
            new Color(warningBoxSpritrRenderer.material.color.r,
                      warningBoxSpritrRenderer.material.color.g,
                      warningBoxSpritrRenderer.material.color.b, 0.3f);
        yield return new WaitForSeconds(0.5f);
        warningBoxSpritrRenderer.material.color =
            new Color(warningBoxSpritrRenderer.material.color.r,
                      warningBoxSpritrRenderer.material.color.g,
                      warningBoxSpritrRenderer.material.color.b, 1f);
        yield return new WaitForSeconds(0.5f);
        warningBoxSpritrRenderer.material.color =
            new Color(warningBoxSpritrRenderer.material.color.r,
                      warningBoxSpritrRenderer.material.color.g,
                      warningBoxSpritrRenderer.material.color.b, 0.3f);
        yield return new WaitForSeconds(0.5f);
        warningBoxSpritrRenderer.material.color =
            new Color(warningBoxSpritrRenderer.material.color.r,
                      warningBoxSpritrRenderer.material.color.g,
                      warningBoxSpritrRenderer.material.color.b, 1f);
        yield return new WaitForSeconds(0.5f);
        warningBoxSpritrRenderer.material.color =
            new Color(warningBoxSpritrRenderer.material.color.r,
                      warningBoxSpritrRenderer.material.color.g,
                      warningBoxSpritrRenderer.material.color.b, 0.3f);
        
        isAiming = false;

        yield return new WaitForSeconds(1);
        warningBox.gameObject.SetActive(false);
        bullet.gameObject.SetActive(true);
        Vector2 vec = new Vector2(transform.position.x, transform.position.y + 2.5f);
        GameObject a = Instantiate(bullet, vec, transform.rotation);
        
        yield return new WaitForSeconds(1);
        Destroy(a);
        isAiming = true;
        yield return new WaitForSeconds(5);
        StartCoroutine(Attack());
    }
}
