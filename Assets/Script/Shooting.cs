using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public string Tag;
    public float bulletSpeed;
    public float LifeBul;
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.tag = Tag;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(BYEBYEBULLET(bullet));
    }

    IEnumerator BYEBYEBULLET(GameObject bullet)
    {
        yield return new WaitForSeconds(LifeBul);
        Destroy(bullet);
    }
}
