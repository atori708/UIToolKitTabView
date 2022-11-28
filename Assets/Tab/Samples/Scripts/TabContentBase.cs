using UnityEditor;
using UnityEngine.UIElements;

namespace TabController.Samples
{
	public class TabContentBase : ITabContent
	{
		VisualElement root;
		public VisualElement Root => root;

		public TabContentBase(VisualTreeAsset visualTreeAsset)
		{
			root = visualTreeAsset.Instantiate();
		}

		/// <summary>
		/// タブ選択時に呼ばれる
		/// </summary>
		public virtual void OnSelect()
		{
			root.style.display = DisplayStyle.Flex;
		}

		/// <summary>
		/// タブ非選択時に呼ばれる
		/// </summary>
		public virtual void OnUnselect()
		{
			root.style.display = DisplayStyle.None;
		}
	}
}