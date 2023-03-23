using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
using System.Linq;

public class CandleManager : MonoBehaviour
{
    [SerializeField] GameObject candlePrefab;
    [SerializeField] List<Candle> candles = new List<Candle>();

    private void OnValidate()
    {
        //clear null candles
        candles = GetComponentsInChildren<Candle>().ToList();
        candles.RemoveAll(c => c == null);
    }

    public void AddCandle(Candle candle)
    {
        if (candles.Contains(candle)) return;
        candles.Add(candle);
    }

    public void LightUpTwoRandomCandles(Candle source)
    {
        //get two random candles that are not lit and not the source
        var unlitCandles = candles.Where(c => !c.isLit && c != source).
                                OrderBy(c => Random.value).
                                Take(2).
                                ToList();


        Debug.Log($"Lighting up {unlitCandles.Count} candles");

        unlitCandles.ForEach(c => c.LightUp());
    }




}
