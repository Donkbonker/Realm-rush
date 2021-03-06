﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem onDeathPrefab;
    [SerializeField] int hp = 3;

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if(hp <= 0) {
            KillEnemy();
        }
    }
    void ProcessHit() {
        hitParticlePrefab.Play();
        hp -= 1;
    }

    void KillEnemy() {
        ParticleSystem a = Instantiate(onDeathPrefab, transform.position, Quaternion.identity);
        a.Play();
        float aDuration = a.main.duration;
        Destroy(a.gameObject, aDuration);
        Destroy(gameObject);
    }
}
