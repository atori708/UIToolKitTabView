using UnityEditor;
using UnityEngine.UIElements;

namespace TabController.Samples
{
	public class TabWindow : EditorWindow
	{
		[MenuItem("Samples/TabWindow")]
		public static void Open()
		{
			GetWindow<TabWindow>("タブサンプル");
		}

		private void CreateGUI()
		{
			var tab = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Tab/VisualElements/Tab.uxml");
			tab.CloneTree(rootVisualElement);
			var tabView = rootVisualElement.Q<TabView>();

			var tab1Content = new TabContentBase(AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Tab/Samples/VisualElement/Tab1Content.uxml"));
			var tab2Content = new TabContentBase(AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Tab/Samples/VisualElement/Tab2Content.uxml"));
			tabView.AddTab("Tab1", tab1Content);
			tabView.AddTab("Tab2", tab2Content);

			tabView.SelectTab(0);
		}
	}
}