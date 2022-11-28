using UnityEngine.UIElements;

namespace TabController
{
	public interface ITabContent
	{
		VisualElement Root { get; }

		/// <summary>
		/// タブ選択時に呼ばれる
		/// </summary>
		void OnSelect();

		/// <summary>
		/// タブ選択解除時に呼ばれる
		/// </summary>
		void OnUnselect();
	}
}
