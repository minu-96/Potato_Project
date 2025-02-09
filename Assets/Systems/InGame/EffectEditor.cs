using UnityEditor;
using UnityEngine;

public class ConvertToLegacy : MonoBehaviour
{
    [MenuItem("Tools/Convert Animation to Legacy")]
    static void Convert()
    {
        AnimationClip clip = Selection.activeObject as AnimationClip;
        if (clip != null)
        {
            SerializedObject serializedClip = new SerializedObject(clip);
            SerializedProperty animationType = serializedClip.FindProperty("m_Legacy");
            animationType.boolValue = true;
            serializedClip.ApplyModifiedProperties();
            Debug.Log(clip.name + " 애니메이션이 Legacy로 변경되었습니다!");
        }
        else
        {
            Debug.LogError("애니메이션 클립을 선택하세요!");
        }
    }
}
