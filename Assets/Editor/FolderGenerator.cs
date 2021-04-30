using UnityEngine;
using UnityEditor;
using System.IO;

public class FolderGenerator : EditorWindow
{
    [MenuItem("Editor/FolderGenerator")]
    static void ShowWindow() => GetWindow<FolderGenerator>();

    // "�t�H���_��", �ō쐬����t�H���_��ǉ�
    private static readonly string[] folderList = new string[]
    {
        "Scenes",
        "Scripts",
        "Prefabs",
        "Textures",
        "Shaders",
        "Materials",
        "Physics Materials",
        "Animations",
        "Animator Controllers",
        "Audio",
        "Resources",
        "Fonts",
        "Plugins",
        "Editor",
        // "Editor DefaultResources",
        // "Gizmos",
    };

    private string path = "Assets";
    private Vector2 scrollBar = Vector2.zero;

    private void OnGUI()
    {
        EditorGUILayout.LabelField("�I�������ꏊ�Ƀt�H���_���쐬���܂�", EditorStyles.boldLabel);

        GUILayout.Box(path);

        if (GUILayout.Button("�t�H���_��I������"))
        {
            path = EditorUtility.OpenFolderPanel("�t�H���_��I������", Application.dataPath, string.Empty);
            EditorGUILayout.LabelField(path);
            // �G�f�B�^�[�̍X�V
            AssetDatabase.Refresh();
        }
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("�쐬����t�H���_", EditorStyles.boldLabel);
        EditorGUILayout.BeginScrollView(scrollBar);
        {
            foreach (string folder in folderList)
            {
                if (GUILayout.Button(folder))
                {
                    string folderPath = Path.Combine(path, folder);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                        Debug.Log(folderPath + "���쐬���܂���");

                        // �G�f�B�^�[�̍X�V
                        AssetDatabase.Refresh();
                    }
                    else
                    {
                        Debug.Log("���Ƀt�H���_�����݂��܂�");
                    }
                }

            }

            EditorGUILayout.HelpBox("Assets/Editor/FolderGeneretor " +
                "��ҏW���邱�Ƃō쐬����t�H���_�̎�ނ𑝂₹�܂��B", MessageType.Info);
        }
        EditorGUILayout.EndScrollView();
    }
}
