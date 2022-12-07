using ISDevTemplate.Data;

public class Notes
{
    private GudgeType _currentGudge;

    private RangeValueStruct<float> _goodGudgeRange;

    private RangeValueStruct<float> _perfectGudgeRange;
    
    private void Input()
    {

    }
}

public enum GudgeType
{
    Perfect,
    Good,
    Miss
}
