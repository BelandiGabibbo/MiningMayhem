using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PistolShoot : MonoBehaviour
{

    public float damage = 5f;
    public float range = 100f;
    public float fireRate = 20f;

    public int maxAmmo = 16;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public AudioSource Pistol;
    public AudioClip shoot;
    public AudioClip reload;

    public Text AmmoAmountUI;
    public GameObject ReloadingMessageUI;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEnemyEffect;
    public GameObject impactGenericEffect;

    private float nextTimeToFire = 0f;

    public Animator animator;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        AmmoAmountUI.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();

        if (isReloading)
        {
            ReloadingMessageUI.SetActive(true);
            return;
        }

        ReloadingMessageUI.SetActive(false);

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload ()
    {
        Pistol.PlayOneShot(reload);

        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;

    }

    void Shoot(){
        muzzleFlash.Play();

        Pistol.PlayOneShot(shoot);

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Enemies target = hit.transform.GetComponent<Enemies>();
            if(target != null){
                target.TakeDamage(damage);
            }


            if(hit.transform.tag == "Enemy"){ 
                GameObject impactEnemy = Instantiate(impactEnemyEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactEnemy, 2f);
            }
            else
            {
                GameObject impactGeneric = Instantiate(impactGenericEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGeneric, 2f);
            }
        }
    }
}
