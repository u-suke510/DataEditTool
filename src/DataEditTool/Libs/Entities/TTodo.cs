using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libs.Entities
{
    /// <summary>
    /// TODO情報クラス
    /// </summary>
    [Table("t_todo")]
    public class TTodo : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 日付
        /// </summary>
        [Column("dt")]
        public DateTime Dt { get; set; }
        /// <summary>
        /// タイトル
        /// </summary>
        [Column("title")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column("content")]
        public string? Content { get; set; }
        /// <summary>
        /// 削除済みフラグ
        /// </summary>
        [Column("del_flg")]
        public bool DelFlg { get; set; }
    }
}
