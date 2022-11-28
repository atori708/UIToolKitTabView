using UnityEditor;
using UnityEngine.UIElements;

namespace TabController.Samples
{
	public class TabContent2 : ITabContent
	{
		VisualElement root;
		public VisualElement Root => root;

		public TabContent2(VisualTreeAsset visualTreeAsset)
		{
			root = visualTreeAsset.Instantiate();
		}

		public void OnSelect()
		{
			root.style.display = DisplayStyle.Flex;
		}

		public void OnUnselect()
		{
			root.style.display = DisplayStyle.None;
		}
	}
}
