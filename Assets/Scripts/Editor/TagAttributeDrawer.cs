using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Linq;

public class TagAttributeDrawer : OdinAttributeDrawer<TagAttribute, string>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        var results = OdinSelector<ValueDropdownItem<string>>.DrawSelectorDropdown(label == null ? GUIContent.none : label, ValueEntry.SmartValue, DoSelector);
        if (results != null)
            ValueEntry.SmartValue = results.First().Value;
    }

    protected OdinSelector<ValueDropdownItem<string>> DoSelector(Rect buttonRect)
    {
        List<ValueDropdownItem<string>> tags = new List<ValueDropdownItem<string>>()
        {
            new ValueDropdownItem<string>( "(None)", string.Empty )
        };
        tags.AddRange(UnityEditorInternal.InternalEditorUtility.tags.Select(x => new ValueDropdownItem<string>(x, x)));

        var gs = new GenericSelector<ValueDropdownItem<string>>(tags);
        gs.EnableSingleClickToSelect();
        gs.ShowInPopup(buttonRect);
        return gs;
    }
}