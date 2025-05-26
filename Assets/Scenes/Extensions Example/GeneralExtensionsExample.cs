using RS.Extensions;
using RS.Utilities;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralExtensionsExample : MonoBehaviour
{
    [Header("List/Array as strings: play scene to see results in readonly fields")]
    [InspectorHide] public bool IgnoreMeIJustMakeHeaderVisibleA; // Only to show header

    public List<string> MyStringList;
    [InspectorReadOnly] public string StringMergedList;

    public List<int> MyIntList;
    [InspectorReadOnly] public string IntMergedList;

    public List<float> MyFloatList;
    [InspectorReadOnly] public string FloatMergedList;

    public List<Vector3> MyV3List;
    [InspectorReadOnly] public string Vector3MergedList;

    public List<GameObject> MyGOList;
    [InspectorReadOnly] public string GOMergedList;

    public string[] MyStringArray;
    [InspectorReadOnly] public string StringMergedArray;

    [Space(20)]

    [Header("List/Array Deduplication: play scene to remove duplicated value")]
    [InspectorHide] public bool IgnoreMeIJustMakeHeaderVisibleB; // Only to show header

    public List<string> ListToDeduplicate;

    [Space(20)]

    [Header("List/Array last element: play scene to see results in readonly fields")]
    [InspectorHide] public bool IgnoreMeIJustMakeHeaderVisibleC; // Only to show header

    public List<string> ListForLastElement;
    [InspectorReadOnly] public string LastElement;

    public List<string> ListForPopLastElement;
    [InspectorReadOnly] public string PopLastElement;

    [Space(20)]

    [Header("List/Array Randomization: play scene to get random element and shuffle list")]
    [InspectorHide] public bool IgnoreMeIJustMakeHeaderVisibleD; // Only to show header

    public List<string> ListForRandomElement;
    [InspectorReadOnly] public string RandomElement;

    public List<string> ListForRandomPopElement;
    [InspectorReadOnly] public string RandomPopElement;

    public List<string> ListToShuffle;

    [Space(20)]

    [Header("String Manipulation: play scene to see results in readonly fields")]
    public string FirstCharLowerCase;
    [InspectorReadOnly] public string FirstCharSetToUpperCase;

    [Space(20)]

    public string FirstCharUpperCase;
    [InspectorReadOnly] public string FirstCharSetToLowerCase;

    [Space(20)]

    public TMP_Text AddSizeTagText;
    public string AddSizeTagBefore;
    [InspectorReadOnly] public string AddSizeTagAfter;

    [Header("Image: play scene and move slider to change alpha ")]
    public Image ImageSetAlpha;
    [Range(0f,1f)] public float Alpha = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StringMergedList = MyStringList.MergeAsString(" - ");
        IntMergedList = MyIntList.MergeAsString(" - ");
        FloatMergedList = MyFloatList.MergeAsString(" - ");
        Vector3MergedList = MyV3List.MergeAsString(" - ");
        GOMergedList = MyGOList.MergeAsString(" - ");
        StringMergedArray = MyStringArray.MergeAsString(" - ");

        ListToDeduplicate.RemoveDuplicate();

        LastElement = ListForLastElement.LastElement();
        PopLastElement = ListForPopLastElement.PopLast();

        RandomElement = ListForRandomElement.RandomElement();
        RandomPopElement = ListForRandomPopElement.RandomPop();
        ListToShuffle.Shuffle();

        FirstCharSetToUpperCase = FirstCharLowerCase.UpperFirstCharacter();
        FirstCharSetToLowerCase = FirstCharUpperCase.LowerFirstCharacter();

        AddSizeTagAfter = AddSizeTagBefore.SetRichSize(40, 5, 10);
        AddSizeTagText.text = AddSizeTagAfter;
    }

    // Update is called once per frame
    void Update()
    {
        ImageSetAlpha.SetColorAlpha(Alpha);
    }
}
