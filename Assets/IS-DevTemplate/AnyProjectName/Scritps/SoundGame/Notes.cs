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

    public Notes(double beforeGoodGudgeEndTime, double perfectGudgeEndTime, double afterGoodGudgeEndTime)
    {
        _cts = new CancellationTokenSource();
        JudgeSequence(beforeGoodGudgeEndTime, perfectGudgeEndTime, afterGoodGudgeEndTime);
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
    }

    private async void JudgeSequence(double beforeGoodGudgeEndTime, double perfectGudgeEndTime, double afterGoodGudgeEndTime)
    {
        _currentGudge = JudgeType.Good;

        try 
        { 
            await UniTask.Delay(TimeSpan.FromSeconds(beforeGoodGudgeEndTime), cancellationToken: _cts.Token); 
        }
        catch (OperationCanceledException) { return; }

        _currentGudge = JudgeType.Perfect;

        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(perfectGudgeEndTime), cancellationToken: _cts.Token);
        }
        catch (OperationCanceledException) { return; }

        _currentGudge = JudgeType.Good;

        try
        {
            await UniTask.Delay(TimeSpan.FromSeconds(afterGoodGudgeEndTime), cancellationToken: _cts.Token);
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
