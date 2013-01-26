CREATE TABLE 'cd' ( 'id' INTEGER NOT NULL PRIMARY KEY, 'name' TEXT NOT NULL );
CREATE UNIQUE INDEX cd_id ON 'cd'('id');
CREATE TABLE 'dbver' ( 'version' INTEGER NOT NULL PRIMARY KEY );
CREATE TABLE 'files' ( 'id' INTEGER NOT NULL PRIMARY KEY, 'id_cd' INTEGER NOT NULL, 'name' TEXT , 'fullpath' TEXT , 'datecreated' DATETIME );
CREATE UNIQUE INDEX files_id ON 'files'('id');
CREATE INDEX files_id_cd ON 'files'('id_cd');
INSERT INTO 'dbver' VALUES ('1');

