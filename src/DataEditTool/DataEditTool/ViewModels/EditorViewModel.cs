using DataEditTool.Commands;
using DataEditTool.Models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataEditTool.ViewModels
{
    public class EditorViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Modelクラス
        /// </summary>
        private readonly ITodoList model;
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// TODOリストアイテム
        /// </summary>
        private ObservableCollection<Todo> items;
        public ObservableCollection<Todo> Items
        {
            get
            {
                return items;
            }
        }
        /// <summary>
        /// 削除コマンド
        /// </summary>
        public IDelItemCmd DelItemCmd { get; private set; }

        /// <summary>
        /// プロパティ変更のイベントハンドラ
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="model">Modelクラス</param>
        /// <param name="logger">ロガー</param>
        public EditorViewModel(ITodoList model, IDelItemCmd cmd, ILogger<EditorViewModel> logger)
        {
            this.model = model;
            this.logger = logger;
            DelItemCmd = cmd;

            // 初期表示処理
            init();
        }

        /// <summary>
        /// 画面の初期表示処理をします。
        /// </summary>
        private void init()
        {
            DelItemCmd.View = this;
            // TODOリストアイテムを取得
            items = model.GetListItems();
        }
    }
}
