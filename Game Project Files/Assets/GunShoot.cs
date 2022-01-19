using System.Threading;
using UnityEngine;

public class GunShoot : MonoBehaviour {

	private LevelInformation levelInfo;
	private float damage;
	public float range = 100f;
	public float fireRate;

	public Camera fpsCam;
	public ParticleSystem MuzzleFlash;
	public GameObject ImpactEffect;

	private float nextTimeToFire = 0f;

	void Start ()
    {
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
		if (gameObject.tag == "MachineGun")
        {
			setDamage(levelInfo.machineGunAttackCalculate());
        }
		else if (gameObject.tag == "Rifle")
        {
			setDamage(levelInfo.rifleAttackCalculate());
		}
		else if (gameObject.tag == "Handgun")
		{
			setDamage(levelInfo.handgunAttackCalculate());
		}
		else if (gameObject.tag == "Shotgun")
        {
			setDamage(levelInfo.shotgunAttackCalculate());
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
			if (Time.deltaTime == 0)
			{
				return;
			}
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();
        }
	}

	void setDamage(float newDamage)
    {
		damage = newDamage;
    }

	void Shoot()
    {
		gameObject.GetComponent<AudioSource>().Play(0);
		RaycastHit hit;
		float actualDamage;
		MuzzleFlash.Play();
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
			Health health = hit.transform.GetComponent<Health>();

			if (health != null)
            {
				if (hit.distance < 5f && gameObject.tag == "Shotgun")
                {
					actualDamage = damage * 1.5f;
                }
				else if (hit.distance > 50f && gameObject.tag == "Rifle")
                {
					actualDamage = damage * 3f;
				}
				else
                {
					actualDamage = damage;
                }
				health.TakeDamage(actualDamage);
            }

			GameObject impactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 0.5f);
        }
    }
}
