using Libs.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataEditTool.Models
{
    /// <summary>
    /// TODOリストのModelインターフェース
    /// </summary>
    public interface ITodoList
    {
        /// <summary>
        /// TodoIdからアイテムを削除します。
        /// </summary>
        /// <param name="id">TodoId</param>
        void DelListItem(int id);

        /// <summary>
        /// TODOリストアイテムを取得します。
        /// </summary>
        /// <returns>TODOリストアイテム</returns>
        ObservableCollection<Todo> GetListItems();
    }

    /// <summary>
    /// TODOリストのModelクラス
    /// </summary>
    public class TodoList : ITodoList
    {
        /// <summary>
        /// ServiceProvider
        /// </summary>
        private readonly IServiceProvider provider;
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILogger<TodoList> logger;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="provider">ServiceProvider</param>
        /// <param name="logger">ロガー</param>
        public TodoList(IServiceProvider provider, ILogger<TodoList> logger)
        {
            this.provider = provider;
            this.logger = logger;
        }

        /// <summary>
        /// TodoIdからアイテムを削除します。
        /// </summary>
        /// <param name="id">TodoId</param>
        public void DelListItem(int id)
        {
            var repository = provider.GetService<ITodoRepository>();

            // 削除対象の取得
            var item = repository.GetItemById(id);
            if (item == null || item.DelFlg)
            {
                // 削除済み
                return;
            }

            // 論理削除の設定
            item.DelFlg = true;
            item.SUpdDtm = DateTime.Now;
            item.SUpdUsr = "DataEditTool";
            // 削除処理
            repository.UpdItem(item);
        }

        /// <summary>
        /// TODOリストアイテムを取得します。
        /// </summary>
        /// <returns>TODOリストアイテム</returns>
        public ObservableCollection<Todo> GetListItems()
        {
            // DBからTODOリストアイテムを取得
            var items = provider.GetService<ITodoRepository>().GetAllItems();

            // 削除済みを除くアイテムを設定
            var result = new ObservableCollection<Todo>();
            foreach ( var item in items.Where(x => !x.DelFlg))
            {
                result.Add(new Todo { Id = item.Id, Title = item.Title });
            }
            return result;
        }
    }
}
