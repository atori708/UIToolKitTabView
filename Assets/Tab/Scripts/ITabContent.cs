using UnityEngine.UIElements;

namespace TabController
{
	public interface ITabContent
	{
		VisualElement Root { get; }

		/// <summary>
		/// �^�u�I�����ɌĂ΂��
		/// </summary>
		void OnSelect();

		/// <summary>
		/// �^�u�I���������ɌĂ΂��
		/// </summary>
		void OnUnselect();
	}
}
