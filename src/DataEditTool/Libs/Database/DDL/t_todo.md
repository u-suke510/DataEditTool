# テーブル定義書

## t_todo

TODO情報

### columns

| 物理名称 | 論理名称 | データ型 | 初期値 | PK | NN | 備考 |
|:-|:-|:-:|:-:|:-:|:-:|:-|
| id | ID | int || 〇 |〇 | 一意にするキー |
| dt | 日付 | date ||| 〇 ||
| title | タイトル | nvarchar(40) ||| 〇 ||
| content | 内容 | nvarchar(max) |||||
| del_flg | 削除済みフラグ | bit | 0 || 〇 | 0:未削除<br/>1:削除済 |
| s_ins_dtm | 登録日時 | datetime ||| 〇 ||
| s_ins_usr | 登録者 | varchar(36) ||| 〇 ||
| s_upd_dtm | 更新日時 | datetime |||||
| s_upd_usr | 更新者 | varchar(36) |||||

### indexes

| 物理名称 | UNIQUE |
|:-|:-:|

## DDL

``` sql
CREATE TABLE t_todo(

  id int IDENTITY NOT NULL,
  dt date NOT NULL,
  title nvarchar(40) NOT NULL,
  content nvarchar(max),
  del_flg bit DEFAULT 0 NOT NULL,
  s_ins_dtm datetime NOT NULL,
  s_ins_usr varchar(36) NOT NULL,
  s_upd_dtm datetime,
  s_upd_usr varchar(36),

  CONSTRAINT PK_t_todo PRIMARY KEY (id)
);
```
