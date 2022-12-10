using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISDevTemplate;

public class NotesGudge : SingletonMonoBehaviour<NotesGudge>
{
    public void Gudge(JudgeType judgeType)
    {
        print($"ジャッジされた:{judgeType}");
    }
}
