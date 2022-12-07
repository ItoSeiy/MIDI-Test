using UnityEngine;
using Klak.Timeline.Midi;

public class SignalInputManager : MonoBehaviour
{
    public bool InputActive { get; private set; } = false;

    [SerializeField]
    private MidiAnimationAsset _midiAnimation;

    [SerializeField]
    private JudgementType _judgementType = JudgementType.Miss;

    private int _midiEventIndex = -1;

    private void Start()
    {
        for(int i = 0; i < _midiAnimation.template.events.Length; i++)
        {
            _midiAnimation.template.events[i].inputed = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if (!InputActive)
            //{
            //    print("InputNotActive");
            //    return;
            //}

            if (_judgementType == JudgementType.Good)
            {
                _midiAnimation.template.events[_midiEventIndex].inputed = true;
                PrintJudge("Good");
            }
            else if (_judgementType == JudgementType.Perfect)
            {
                _midiAnimation.template.events[_midiEventIndex].inputed = true;
                PrintJudge("Perfect");
            }
        }
    }

    public void IncrementMidiEventInput()
    {
        _midiEventIndex++;
        //print($"Index{_midiEventIndex}");
    }

    public void InputSetActive(bool active)
    {
        InputActive = active;
        print($"InputActive{active}");
    }

    public void SetGoodState()
    {
        _judgementType = JudgementType.Good;
    }

    public void SetPerfectState()
    {
        _judgementType = JudgementType.Perfect;
    }

    public void SetMissState()
    {
        _judgementType = JudgementType.Miss;
        PrintJudge("Miss");
    }

    public void PrintJudge(string judge)
    {
        if(judge == "Miss" && !_midiAnimation.template.events[_midiEventIndex].inputed)
        {
            print(judge);
            return;
        }
        else if(judge == "Miss" && _midiAnimation.template.events[_midiEventIndex].inputed)
        {
            print($"Inputed{_midiAnimation.template.events[_midiEventIndex].inputed}");
            return;
        }
        else
        {
            print(judge);
        }
    }
}

public enum JudgementType
{
    Good,
    Perfect,
    Miss
}
