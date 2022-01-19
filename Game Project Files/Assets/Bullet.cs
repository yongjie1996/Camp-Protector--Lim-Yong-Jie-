using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private LevelInformation levelInfo;
	private Transform target;
	private float Damage;
	public float speed = 300f;
	public GameObject impactEffect;

	public void Seek(Transform _target)
    {
		target = _target;
    }

	void Start()
    {
		levelInfo = GameObject.FindGameObjectWithTag("LevelInformation").GetComponent<LevelInformation>();
		Damage = levelInfo.turretAttackCalculate();
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
			Destroy(gameObject);
			return;
        }

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
        {
			HitTarget();
			return;
        }

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget()
    {
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 0.5f);
		Health targetHealth = target.gameObject.GetComponent<Health>();
		if (targetHealth != null)
		{
			target.gameObject.GetComponent<Health>().TakeDamage(Damage);
		}
		Destroy(gameObject);
    }	
}
