using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TabController
{
	internal class TabItem : VisualElement
	{
		public new class UxmlFactory : UxmlFactory<TabItem>
		{
		}

		Button _button;
		VisualElement _border;

		public event System.Action clicked {
			add => _button.clicked += value;
			remove => _button.clicked -= value;
		}

		public TabItem()
			: this("Tab", null)
		{
		}

		ITabContent _content;

		public TabItem(string title, ITabContent tabContent)
		{
			name = "Tab";

			_button = new Button();
			_button.text = title;
			_border = new VisualElement();

			Add(_button);
			Add(_border);

			if (ColorUtility.TryParseHtmlString("#40A0FF80", out var color)) {
				_border.style.backgroundColor = color;
			}

			_border.style.height = 1.5f;

			style.flexShrink = 1;
			style.flexGrow = 1;

			_button.ToggleInClassList("tab-item-view");
			if(_button.ClassListContains("unity-button")) {
				_button.RemoveFromClassList("unity-button");
			}

			_content = tabContent;
		}

		public void Select()
		{
			if (!_button.ClassListContains("tab-item-view_select")) {
				_button.AddToClassList("tab-item-view_select");
			}
			_border.style.display = DisplayStyle.Flex;

			_content.OnSelect();
		}

		public void UnSelect()
		{
			if (_button.ClassListContains("tab-item-view_select")) {
				_button.RemoveFromClassList("tab-item-view_select");
			}
			_border.style.display = DisplayStyle.None;


			_content.OnUnselect();
		}
	}

}
