using Libs.Entities;
using Microsoft.Extensions.Logging;

namespace Libs.Repositories
{
    /// <summary>
    /// TODO情報のRepositoryインターフェース
    /// </summary>
    public interface ITodoRepository : IRepositoryBase
    {
        /// <summary>
        /// 全てのTODO情報を取得します。
        /// </summary>
        /// <returns>TODO情報</returns>
        List<TTodo> GetAllItems();

        /// <summary>
        /// TODO情報をIDで検索します。
        /// </summary>
        /// <param name="id">TodoId</param>
        /// <returns>TODO情報</returns>
        TTodo GetItemById(int id);

        /// <summary>
        /// TODO情報を更新します。
        /// </summary>
        /// <param name="entity">TODO情報</param>
        /// <returns>処理結果</returns>
        bool UpdItem(TTodo entity);
    }

    /// <summary>
    /// TODO情報のRepositoryクラス
    /// </summary>
    public class TodoRepository : RepositoryBase, ITodoRepository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="logger">ロガー</param>
        public TodoRepository(AppDbContext context, ILogger<TodoRepository> logger) : base(context, logger)
        {
        }

        /// <summary>
        /// 全てのTODO情報を取得します。
        /// </summary>
        /// <returns>TODO情報</returns>
        public List<TTodo> GetAllItems()
        {
            var items = context.Todos.Where(x => !x.DelFlg).ToList();

            return items;
        }

        /// <summary>
        /// TODO情報をIDで検索します。
        /// </summary>
        /// <param name="id">TodoId</param>
        /// <returns>TODO情報</returns>
        public TTodo GetItemById(int id)
        {
            // 存在しない場合、NULLを返す
            if (!context.Todos.Any(x => x.Id == id))
            {
                return null;
            }

            return context.Todos.Single(x => x.Id == id);
        }

        /// <summary>
        /// TODO情報を更新します。
        /// </summary>
        /// <param name="entity">TODO情報</param>
        /// <returns>処理結果</returns>
        public bool UpdItem(TTodo entity)
        {
            // 存在チェック
            if (!context.Todos.Any(x => x.Id == entity.Id))
            {
                return false;
            }

            context.Todos.Attach(entity);
            context.SaveChanges();
            return true;
        }
    }
}
