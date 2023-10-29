using System.ComponentModel.DataAnnotations.Schema;

namespace Libs
{
    /// <summary>
    /// Entityクラスのベースクラス
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// 登録日時
        /// </summary>
        [Column("s_ins_dtm")]
        public DateTime SInsDtm { get; set; }
        /// <summary>
        /// 登録ユーザー
        /// </summary>
        [Column("s_ins_usr")]
        public string SInsUsr { get; set; }
        /// <summary>
        /// 更新日時
        /// </summary>
        [Column("s_upd_dtm")]
        public DateTime? SUpdDtm { get; set; }
        /// <summary>
        /// 更新ユーザー
        /// </summary>
        [Column("s_upd_usr")]
        public string? SUpdUsr { get; set; }
    }
}
