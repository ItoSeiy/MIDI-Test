using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ISDevTemplate.Data;
using UnityEngine;

public class Notes
{
    public JudgeType CurrentGudge => _currentGudge;

    private JudgeType _currentGudge;

    private CancellationTokenSource _cts;

    private bool _isJudged = false;

    public Notes(RangeValueStruct<double> goodGudgeRange, RangeValueStruct<double> perfectGudgeRange)
    {
        _cts = new CancellationTokenSource();
        JudgeSequence(goodGudgeRange, perfectGudgeRange);
    }

    public void Input()
    {
        if (_isJudged)
        {
            Debug.Log("すでにミスしているノーツが入力された");
            return;
        }

        _cts.Cancel();
        NotesGudge.Instance.Gudge(_currentGudge);
        Debug.Log($"ノーツが入力された:{_currentGudge}");
    }

    private async void JudgeSequence(RangeValueStruct<double> goodGudgeRange, RangeValueStruct<double> perfectGudgeRange)
    {
        // この関数が呼ばれる時点ではGoodRangeが始まっているので goodGudgeRange.Start を待たない
        _currentGudge = JudgeType.Good;

        try 
        { 
            await UniTask.Delay(TimeSpan.FromSeconds(perfectGudgeRange.Start), cancellationToken: _cts.Token); 
        }
        catch (OperationCanceledException) { return; }

        _currentGudge = JudgeType.Perfect;

        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(perfectGudgeRange.End), cancellationToken: _cts.Token);
        }
        catch (OperationCanceledException) { return; }

        _currentGudge = JudgeType.Good;

        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(goodGudgeRange.End), cancellationToken: _cts.Token);
        }
        catch (OperationCanceledException) { return; }

        _isJudged = true;
        _currentGudge = JudgeType.Miss;
        NotesGudge.Instance.Gudge(_currentGudge);
        Debug.Log("ノーツが見逃された");
    }
}

public enum JudgeType
{
    Perfect,
    Good,
    Miss
}
