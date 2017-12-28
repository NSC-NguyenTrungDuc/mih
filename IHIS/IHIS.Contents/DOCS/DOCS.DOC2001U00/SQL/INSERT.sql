INSERT INTO DOC0101
        (SYS_DATE, USER_ID, UPD_DATE, CERT_JNCD, CERT_VALD, CERT_RQGB, CERT_JNNM, CERT_IUSE, CERT_OUSE, CERT_EUSE, CERT_WUSE)
VALUES (SYSDATE, 'ICM017', SYSDATE, '018', 'Y', 'I', '�f�Ï��񋟏�(�Ұ�ޗL)', 'Y', 'Y', 'Y', 'Y');



CREATE TABLE DOC2002
(
  SYS_DATE   DATE,
  USER_ID    VARCHAR2(8),
  UPD_DATE   DATE,
  FKDOC1001  NUMBER                             NOT NULL,
  IMG_PATH1  VARCHAR2(100),
  IMG_PATH2  VARCHAR2(100),
  IMG_EXT1	 VARCHAR2(4),
  IMG_EXT2   VARCHAR2(4),
  IMG_LEN1	 NUMBER,
  IMG_LEN2   NUMBER
);

ALTER TABLE DOC2002 ADD (
  CONSTRAINT DOC2002_U1
 PRIMARY KEY
 (FKDOC1001));