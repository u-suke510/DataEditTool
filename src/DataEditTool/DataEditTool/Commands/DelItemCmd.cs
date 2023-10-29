using DataEditTool.Models;
using DataEditTool.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Windows.Input;

namespace DataEditTool.Commands
{
    /// <summary>
    /// リストアイテム削除コマンドインターフェース
    /// </summary>
    public interface IDelItemCmd : ICommand
    {
        /// <summary>
        /// ビュー
        /// </summary>
        EditorViewModel View { get; set; }
    }

    /// <summary>
    /// リストアイテム削除コマンドクラス
    /// </summary>
    public class DelItemCmd : IDelItemCmd
    {
        /// <summary>
        /// Modelクラス
        /// </summary>
        private readonly ITodoList model;
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILogger<DelItemCmd> logger;

        /// <summary>
        /// ビュー
        /// </summary>
        public EditorViewModel View { get; set; }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="model">Modelクラス</param>
        /// <param name="logger">ロガー</param>
        public DelItemCmd(ITodoList model, ILogger<DelItemCmd> logger)
        {
            this.model = model;
            this.logger = logger;
        }

        /// <summary>
        /// イベントハンドラを実装します。
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// コマンドの有効/無効を判定します。
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        /// <returns>判定結果</returns>
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// コマンドの処理を実行します。
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        public void Execute(object? parameter)
        {
            logger.LogInformation($"Exec Delete Command.(id:{parameter})");
            var id = (int)parameter;

            // アイテムの削除
            model.DelListItem(id);

            // リストアイテムの更新
            var index = View.Items.Select((x, y) => new { x.Id, Index = y }).First(x => x.Id == id).Index;
            View.Items.RemoveAt(index);
        }
    }
}
