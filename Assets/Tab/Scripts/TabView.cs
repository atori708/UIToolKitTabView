using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace TabController
{
	public class TabView : VisualElement
	{
		public new class UxmlFactory : UxmlFactory<TabView>
		{
		}

		List<TabItem> _tabItems = new();

		VisualElement tabRoot;
		VisualElement contentRoot;

		public TabView()
		{
			tabRoot = new VisualElement();
			tabRoot.name = "Tabs";
			tabRoot.style.flexGrow = 1;
			tabRoot.style.maxHeight = 15f;
			tabRoot.style.flexDirection = FlexDirection.Row;
			Add(tabRoot);

			contentRoot = new VisualElement();
			contentRoot.name = "Contents";
			contentRoot.style.flexGrow = 1;
			Add(contentRoot);

			style.flexGrow = 1;
		}

		/// <summary>
		/// �^�u��ǉ�����
		/// </summary>
		/// <param name="title">�^�u�̃^�C�g��</param>
		/// <param name="tabContent">�^�u�̒��g�̃R���e���c</param>
		public void AddTab(string title, ITabContent tabContent)
		{
			contentRoot.Add(tabContent.Root);
			var contents = contentRoot.Query<VisualElement>("Content").ToList();

			var tabItem = new TabItem(title, tabContent);

			tabRoot.Add(tabItem);
			_tabItems.Add(tabItem);

			var index = _tabItems.Count - 1;
			tabItem.clicked += () => {
				SelectTab(index);
			};
		}

		/// <summary>
		/// �^�u��I������
		/// </summary>
		/// <param name="index">�^�u�̃C���f�b�N�X</param>
		public void SelectTab(int index)
		{
			if (index < 0 || index > _tabItems.Count - 1) {
				throw new ArgumentOutOfRangeException($"���݂��Ȃ��^�u���w�肵�Ă��܂��Bindex:{index}");
			}

			for (int i = 0; i < _tabItems.Count; i++) {
				var tabItem = _tabItems[i];
				if (i == index) {
					tabItem.Select();
				}
				else {
					tabItem.UnSelect();
				}
			}
		}
	}
}