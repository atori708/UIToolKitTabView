# UIToolKitTabView

UIToolKitの練習として、タブを実装してみたサンプルです。
一応使える形にはなっている...と思います。

# サンプル
![TabViewサンプル](https://user-images.githubusercontent.com/6129556/204310686-b9b28e6b-0f14-48a1-974f-f0d16c7fca1f.gif)

用意するアセットとして以下のuxmlファイルが必要です。
- TabViewを追加したuxml
- 各タブで表示したいコンテンツのuxml

## コード
    public class TabWindow : EditorWindow
    {
        [MenuItem("Samples/TabWindow")]
        public static void Open()
        {
            GetWindow<TabWindow>("タブサンプル");
        }

        private void CreateGUI()
        {
            var tab = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("[TabViewを持っているuxmlのパス]");
            tab.CloneTree(rootVisualElement);
            var tabView = rootVisualElement.Q<TabView>();

            var tab1Content = new TabContentBase(AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("[Tab1で表示したいUIのuxmlのパス]"));
            var tab2Content = new TabContentBase(AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("[Tab2で表示したいUIのuxml]のパス"));
            tabView.AddTab("Tab1", tab1Content);
            tabView.AddTab("Tab2", tab2Content);

            // Tab1を選択
            tabView.SelectTab(0);
        }
    }
