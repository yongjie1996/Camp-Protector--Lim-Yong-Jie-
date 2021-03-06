using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;

	[Header("Attributes")]

	public float range = 30f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;

	[Header("Unity Setup Fields")]

	public string enemy1 = "Goblin";
	public string enemy2 = "Wolf";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public GameObject bulletPrefab;
	public Transform firePoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget ()
    {
		float distanceToEnemy;
		GameObject[] enemies1 = GameObject.FindGameObjectsWithTag(enemy1);
		GameObject[] enemies2 = GameObject.FindGameObjectsWithTag(enemy2);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies1)
        {
			distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
            {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
            }
        }

		foreach (GameObject enemy in enemies2)
		{
			distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
        {
			target = nearestEnemy.transform;
        }
		else
        {
			target = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
			return;
        }
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if (fireCountdown <= 0f)
        {
			Shoot();
			fireCountdown = 1f / fireRate;
        }

		fireCountdown -= Time.deltaTime;
	}

	void Shoot()
    {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
        {
			bullet.Seek(target);
        }
    }
}
