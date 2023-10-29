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
