using RS.Utilities;
using UnityEngine;

public class InspectorReadOnlyExample : MonoBehaviour
{
    [Header("Normal Field")]
    public float MyFloat = 10;
    public string MyString = "A wonderful string";
    public Vector3 MyVector3 = new Vector3(1, 2, 3);


    [Header("Read only Field")]

    [InspectorReadOnly]
    public float ReadOnlyFloat = 10;

    [InspectorReadOnly]
    public string ReadOnlyString = "A wonderful read only string";

    [InspectorReadOnly]
    public Vector3 ReadOnlyVector3 = new Vector3(1,2,3);
}
