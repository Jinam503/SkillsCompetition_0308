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
        hp = 20;
        
        warningBoxSpritrRenderer = warningBox.GetComponent<SpriteRenderer>();
        StartCoroutine(Attack());

    }
    protected override void Update()
    {
        base.Update();
        if (hp <= 0)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        if (isAiming)
        {
            Vector3 dir = target.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
        }
        
        
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 2.0f));
        warningBox.gameObject.SetActive(true);
        bullet.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(1);
        bullet.gameObject.SetActive(false);
        isAiming = true;
        yield return new WaitForSeconds(2);
        StartCoroutine(Attack());
    }
}
