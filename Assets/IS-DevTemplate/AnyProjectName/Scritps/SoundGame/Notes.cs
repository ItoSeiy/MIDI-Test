using ISDevTemplate.Data;

public class Notes
{
    private JudgeType _currentGudge;

    private RangeValueStruct<float> _goodGudgeRange;

    private RangeValueStruct<float> _perfectGudgeRange;
    
    public void Input()
    {
        
    }
}

public enum JudgeType
{
    Perfect,
    Good,
    Miss
}
