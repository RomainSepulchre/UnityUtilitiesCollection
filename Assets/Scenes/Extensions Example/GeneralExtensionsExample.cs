using JetBrains.Annotations;
using RS.Extensions;
using RS.Utilities;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GeneralExtensionsExample : MonoBehaviour
{
    [Header("List as strings: play scene to see results in readonly fields")]
    [InspectorReadOnly]
    public bool IgnoreMeIJustMakeHeaderVisible; // Only to show header

    public List<string> MyStringList;
    [InspectorReadOnly]
    public string stringMergedList;

    public List<int> MyIntList;
    [InspectorReadOnly]
    public string intMergedList;

    public List<float> MyFloatList;
    [InspectorReadOnly]
    public string floatMergedList;

    public List<Vector3> MyV3List;
    [InspectorReadOnly]
    public string Vector3MergedList;

    public List<GameObject> MyGOList;
    [InspectorReadOnly]
    public string GOMergedList;

    [Space(20)]

    [Header("String Manipulation: play scene to see results in readonly fields")]
    public string FirstCharLowerCase;
    [InspectorReadOnly]
    public string FirstCharSetToUpperCase;

    [Space(20)]

    public string FirstCharUpperCase;
    [InspectorReadOnly]
    public string FirstCharSetToLowerCase;

    [Space(20)]
    public TMP_Text AddSizeTagText;
    public string AddSizeTagBefore;
    public string AddSizeTagAfter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stringMergedList = MyStringList.MergeAsString(" - ");
        intMergedList = MyIntList.MergeAsString(" - ");
        floatMergedList = MyFloatList.MergeAsString(" - ");
        Vector3MergedList = MyV3List.MergeAsString(" - ");
        GOMergedList = MyGOList.MergeAsString(" - ");
        FirstCharSetToUpperCase = FirstCharLowerCase.UpperFirstCharacter();
        FirstCharSetToLowerCase = FirstCharUpperCase.LowerFirstCharacter();
        AddSizeTagAfter = AddSizeTagBefore.SetRichSize(26, 5, 10);
        AddSizeTagText.text = AddSizeTagAfter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
