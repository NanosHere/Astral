using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControler : MonoBehaviour
{
    public GameObject look;

    public GameObject lampPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    private Transform fireTransform;
    IEnumerator fireLamp()
    {
        GameObject Projectile = Instantiate(lampPrefab);
        Projectile.transform.forward = look.transform.forward;
        Projectile.transform.position = fireTransform.position + fireTransform.forward;

        yield return new WaitForSeconds(0.1f);

        //Projectile.GetComponent<>()

    }

}
