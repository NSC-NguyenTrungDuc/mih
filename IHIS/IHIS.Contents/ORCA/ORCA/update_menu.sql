Insert into MEDI.ADM4300
   (USER_ID, SYS_ID, SEQ, MENU_TP, MENU_LEVEL, PGM_NM, TR_ID, PGM_GRP_ID, PGM_SYS_ID, PGM_ID, PGM_ENT_GRAD, PGM_UPD_GRAD, PGM_DUP_YN, PGM_ACS_YN, PGM_OPEN_TP, HOSP_CODE)
 Values
   ('OUT001', 'OUTS', 19, 'M', 1, 
    '*Accounting business for Out-Patient', '00030', 'ORC', 'ORCA', 'PGM_ID_TEST', 
    0, 0, 
    'N', 'Y', 'PPS', 'K01');
    
    Insert into MEDI.ADM4300
   (USER_ID, SYS_ID, SEQ, MENU_TP, MENU_LEVEL, PGM_NM, TR_ID, PGM_GRP_ID, PGM_SYS_ID, PGM_ID, PGM_ENT_GRAD, PGM_UPD_GRAD, PGM_DUP_YN, PGM_ACS_YN, PGM_OPEN_TP, ASM_NAME, ASM_PATH, ASM_VER, HOSP_CODE)
 Values
   ('OUT001', 'OUTS', 20, 'P', 2, 
    'S02 - Registration Invoice', '00031',  'ORC', 'ORCA', 'S02', 
    0, 0, 
    'N', 'Y', 'PPF', 'S02.dll', 'ORC/ORCA/BSA', '1.0.0.0', 'K01');
