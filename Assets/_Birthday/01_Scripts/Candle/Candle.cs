using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Candle : MonoBehaviour
{
    [SerializeField, FoldoutGroup("Behavior")] float dropDownTime = 1f;
    [SerializeField, FoldoutGroup("Behavior")] float moveUpTime = 1f;
    [SerializeField, FoldoutGroup("Dependancies")] Transform candleObject;
    [SerializeField, FoldoutGroup("Dependancies")] CandleManager candleManager;
    [SerializeField, FoldoutGroup("Dependancies")] GameObject fireParticlesObject;
    [SerializeField, FoldoutGroup("Dependancies")] List<ParticleSystem> fireParticles = new List<ParticleSystem>();
    [SerializeField, FoldoutGroup("Dependancies")] AudioSource constanceSource;
    [SerializeField, FoldoutGroup("Dependancies")] AudioSource putOutSource;
    [FoldoutGroup("Debugging")] public bool isLit = false;

    void OnValidate()
    {
        candleManager = FindObjectOfType<CandleManager>();

        if (fireParticlesObject) fireParticles = fireParticlesObject.GetComponentsInChildren<ParticleSystem>().ToList();
    }

    void Start()
    {
        if (isLit) TurnOnFire();
        else TurnOffFire();
        transform.rotation = Quaternion.identity;
    }

    [Button]
    public void PutOut()
    {
        if (isLit == false) return;
        TurnOffFire();
        isLit = false;
        candleObject.DOLocalMoveY(-2f, dropDownTime).OnComplete(() =>
        {
            candleManager.LightUpTwoRandomCandles(this);
        });
    }

    [Button]
    public void LightUp()
    {
        if (isLit) return;
        isLit = true;
        candleObject.DOLocalMoveY(1f, moveUpTime).OnComplete(() =>
        {
            TurnOnFire();
        });
    }


    [Button]
    public void TurnOnFire()
    {
        fireParticles.ForEach(p => p.Play());
    }

    [Button]
    public void TurnOffFire()
    {
        fireParticles.ForEach(p => p.Stop());
        putOutSource.Play();
    }
}