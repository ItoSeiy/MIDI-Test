using System;
using ISDevTemplate.Data;
using Cysharp.Threading.Tasks;

public class Notes
{
    private JudgeType _currentGudge;

    private RangeValueStruct<float> _goodGudgeRange;

    private RangeValueStruct<float> _perfectGudgeRange;

    public Notes(RangeValueStruct<float> goodGudgeRange, RangeValueStruct<float> perfectGudgeRange)
    {
        _goodGudgeRange = goodGudgeRange;
        _perfectGudgeRange = perfectGudgeRange;
    }

    public void Input()
    {

    }

    private async void JudgeSequence()
    {
        _currentGudge = JudgeType.Good;
        await UniTask.Delay(TimeSpan.FromSeconds(_perfectGudgeRange.Start));
    }
}

public enum JudgeType
{
    Perfect,
    Good,
    Miss
}
