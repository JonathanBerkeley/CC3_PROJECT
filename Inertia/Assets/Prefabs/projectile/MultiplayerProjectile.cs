﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Multiplayer variant of projectile script
public class MultiplayerProjectile : MonoBehaviour
{
    public float delay = 3.0f;
    public float blastRadius = 5.0f;
    public float blastForce = 2000.0f;
    public GameObject explosionEffect;
    public AudioClip explosionAudio;
    public AudioClip hitSound;

    private int id;
    private float countdown;
    private bool exploded;
    private GameObject _self;
    private Rigidbody _selfBody;

    //Multiplayer variables
    private Vector3 location;
    private Quaternion rotation;
    void Start()
    {
        _self = gameObject;
        _selfBody = _self.GetComponent<Rigidbody>();
        countdown = delay;
    }

    private void Awake()
    {
        location = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
    }

    void Update()
    {
        //Countdown causes it to explode if flying into abyss too long
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f && !exploded)
        {
            Explode();
            exploded = true;
        }
    }

    void Explode()
    {
        //Show explosion effect
        GameObject explosionObject = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

        //Play explosion audio
        if (GlobalAudioReference.instance != null)
        {
            AudioSource.PlayClipAtPoint(explosionAudio, transform.position, GlobalAudioReference.instance.GetEffectsVolume());
        }
        else
        {
            AudioSource.PlayClipAtPoint(explosionAudio, transform.position, 0.5f);
        }


        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);


        //Affect nearby objects
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && rb != _selfBody)
            {
                rb.AddExplosionForce(blastForce, transform.position, blastRadius);

                //Explosion damage based on distance from explosion
                float distanceFromExplosion = Vector3.Distance(transform.position, rb.transform.position);
                GameObject _playerHit = rb.transform.root.gameObject;
                int _damage = 0;
                int _id = PlayerID.GetIDByGameObject(rb.gameObject);
                if (_id != this.id)
                {
                    if (distanceFromExplosion < 2.0f)
                    {
                        _damage = 60;
                    }
                    else if (distanceFromExplosion < 5.0f)
                    {
                        _damage = 40;
                    }
                    else if (distanceFromExplosion < 7.0f)
                    {
                        _damage = 30;
                    }
                    else if (distanceFromExplosion < 15.0f)
                    {
                        _damage = 10;
                    }

                }
                else
                {
                    //Reduced damage for author of rocket to encourage rocket jumping
                    _damage = 5;
                }

                //Decrease health of hit player/bot
                MultiplayerStats _ps;
                _playerHit.TryGetComponent(out _ps);
                if (_ps != null)
                {
                    _ps.DecreaseHealth(_damage);
                }
                else
                {
                    //There should not be bots in multiplayer, but left in to make future expansion easier
                    BotStats _bs;
                    _playerHit.TryGetComponent(out _bs);

                    if (_bs != null)
                    {
                        _bs.DecreaseHealth(_damage);
                    }
                }

                PlaySound(_damage, _id);

                //print(_playerHit.name + " was " + distanceFromExplosion + " from explosion and took " + _damage + " damage");
            }
        }

        //Cleanup for efficiency
        Destroy(explosionObject, 3);
        Destroy(gameObject);
    }

    private void PlaySound(int _dmg, int _id)
    {
        if (_dmg < 1 || this.id == _id || !SettingsData.hitsoundDesired)
            return;

        if (this.id == PlayerPassport.MyID && GlobalAudioReference.instance != null)
        {
            Vector3 audioListener = FindObjectOfType<AudioListener>().transform.position;
            AudioSource.PlayClipAtPoint(hitSound, audioListener, GlobalAudioReference.instance.GetEffectsVolume());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Prevents parent object from causing rocket to explode. Explodes otherwise
        if (PlayerID.GetIDByGameObject(collision.gameObject) != this.GetParentID())
        {
            Explode();
        }
    }

    //Handles ID for this object
    public void SetParentByID(int sid)
    {
        this.id = sid;
    }
    public int GetParentID()
    {
        return this.id;
    }
}
