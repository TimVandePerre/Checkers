using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Board_Builder))]
public class EditorBoardBuilder :   Editor
{
    public VisualTreeAsset InspectorUXML;

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement myInspector = new VisualElement();
        InspectorUXML.CloneTree(myInspector);

        Button BGenerate = myInspector.Q<Button>("BGenerate");
        BGenerate.clicked += BGenerate_clicked;

        Button BClear = myInspector.Q<Button>("BClear");
        BClear.clicked += BClear_clicked;

        return myInspector;
    }

    private void BGenerate_clicked()
    {
        (target as Board_Builder).GenerateBoard();
    }

    private void BClear_clicked()
    {
        (target as Board_Builder).ClearBoard();
    }
}
