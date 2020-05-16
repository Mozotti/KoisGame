using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GroupGameObjects
    {
        [MenuItem("GameObject/Group GameObjects %g")]
        private static void GroupSelected()
        {
            if (!Selection.activeTransform) return;

            GameObject Group = new GameObject
            {
                name = "Group"
            };

            Undo.RegisterCompleteObjectUndo(Group, "Group GameObjects");

            Group.transform.SetParent(Selection.activeTransform.parent, false);

            foreach (var transform in Selection.transforms)
            {
                Undo.SetTransformParent(transform, Group.transform, "Group GameObjects");
            }

            Selection.activeObject = Group;
        }
    }
}