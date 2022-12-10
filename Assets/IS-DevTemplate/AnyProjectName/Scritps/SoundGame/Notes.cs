using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ISDevTemplate.Data;
using UnityEngine;

public class Notes
{
    private JudgeType _currentGudge;

    private CancellationTokenSource _cts;

    private bool _isMissed = false;

    public Notes(RangeValueStruct<float> goodGudgeRange, RangeValueStruct<float> perfectGudgeRange)
    {
        _cts = new CancellationTokenSource();
        JudgeSequence(goodGudgeRange, perfectGudgeRange);
    }

    public void Input()
    {
        if (_isMissed)
        {
            Debug.Log("すでにミスしているノーツが入力された");
            return;
        }

        _cts.Cancel();
        Debug.Log(_currentGudge);
    }

    private async void JudgeSequence(RangeValueStruct<float> goodGudgeRange, RangeValueStruct<float> perfectGudgeRange)
    {
        // この関数が呼ばれる時点ではGoodRangeが始まっているので goodGudgeRange.Start を待たない

        _currentGudge = JudgeType.Good;

        await UniTask.Delay(TimeSpan.FromSeconds(perfectGudgeRange.Start), cancellationToken: _cts.Token);

        _currentGudge = JudgeType.Perfect;

        await UniTask.Delay(TimeSpan.FromSeconds(perfectGudgeRange.End), cancellationToken: _cts.Token);

        _currentGudge = JudgeType.Good;

        await UniTask.Delay(TimeSpan.FromSeconds(goodGudgeRange.End), cancellationToken: _cts.Token);

        _isMissed = true;
        _currentGudge = JudgeType.Miss;
        Debug.Log("ノーツが見逃された");
    }
}

public enum JudgeType
{
    Perfect,
    Good,
    Miss
}
