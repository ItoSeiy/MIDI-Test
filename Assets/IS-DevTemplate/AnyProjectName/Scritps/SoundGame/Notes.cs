using System;
using ISDevTemplate.Data;
using Cysharp.Threading.Tasks;

public class Notes
{
    private JudgeType _currentGudge;

    public Notes(RangeValueStruct<float> goodGudgeRange, RangeValueStruct<float> perfectGudgeRange)
    {
        JudgeSequence(goodGudgeRange, perfectGudgeRange);
    }

    public void Input()
    {

    }

    private async void JudgeSequence(RangeValueStruct<float> goodGudgeRange, RangeValueStruct<float> perfectGudgeRange)
    {
        // この関数が呼ばれる時点ではGoodRangeが始まっているので goodGudgeRange.Start を待たない

        _currentGudge = JudgeType.Good;

        await UniTask.Delay(TimeSpan.FromSeconds(perfectGudgeRange.Start));

        _currentGudge = JudgeType.Perfect;

        await UniTask.Delay(TimeSpan.FromSeconds(perfectGudgeRange.End));

        _currentGudge = JudgeType.Good;

        await UniTask.Delay(TimeSpan.FromSeconds(goodGudgeRange.End));

        _currentGudge = JudgeType.Miss;
    }
}

public enum JudgeType
{
    Perfect,
    Good,
    Miss
}
