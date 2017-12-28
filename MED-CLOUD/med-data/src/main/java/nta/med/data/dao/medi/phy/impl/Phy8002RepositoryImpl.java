package nta.med.data.dao.medi.phy.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.phy.Phy8002RepositoryCustom;
import nta.med.data.model.ihis.phys.Phy8002U01GrdPhy8002LisItemInfo;

/**
 * @author dainguyen.
 */
public class Phy8002RepositoryImpl implements Phy8002RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public Double getOCS0103U11GetFkOcs(String hospCode, Double pkocskey) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.FK_OCS					");
		sql.append("	 FROM PHY8002 A                 ");
		sql.append("	WHERE A.HOSP_CODE = :hospCode   ");
		if (pkocskey != null) {
			sql.append("	  AND A.FK_OCS = :pkocskey      ");
		} else {
			sql.append("	  AND A.FK_OCS IS NULL OR  A.FK_OCS = '' ");
		}
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		if (pkocskey != null) {
			query.setParameter("pkocskey", pkocskey);
		}
		
		List<Double> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}

	@Override
	public List<Phy8002U01GrdPhy8002LisItemInfo> getPhy8002U01GrdPhy8002LisItem(String hospCode, Double fkOcs) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	    SELECT  A.SYS_DATE,																	");
		sql.append("	        A.USER_ID,                                                                      ");
		sql.append("	        A.UPD_DATE,                                                                     ");
		sql.append("	        A.HOSP_CODE,                                                                    ");
		sql.append("	        A.PKPHY8002,                                                                    ");
		sql.append("	        A.FK_OCS,                                                                       ");
		sql.append("	        A.IO_KUBUN,                                                                     ");
		sql.append("	        A.IRAI_DATE,                                                                    ");
		sql.append("	        A.KANJA_NO,                                                                     ");
		sql.append("	        A.SINRYOUKA,                                                                    ");
		sql.append("	        A.SINDANISI,                                                                    ");
		sql.append("	        A.TANTOUI,                                                                      ");
		sql.append("	        A.NYUUINNBI,                                                                    ");
		sql.append("	        A.BYOUSITU_CODE,                                                                ");
		sql.append("	        A.BYOUTOU_CODE,                                                                 ");
		sql.append("	        A.KAISIBI,                                                                      ");
		sql.append("	        A.NISSUU,                                                                       ");
		sql.append("	        A.KOUMOKU_CODE,                                                                 ");
		sql.append("	        A.PT1,                                                                          ");
		sql.append("	        A.PT2,                                                                          ");
		sql.append("	        A.PT3,                                                                          ");
		sql.append("	        A.PT4,                                                                          ");
		sql.append("	        A.PT5,                                                                          ");
		sql.append("	        A.PT6,                                                                          ");
		sql.append("	        A.PT7,                                                                          ");
		sql.append("	        A.PT8,                                                                          ");
		sql.append("	        A.PT9,                                                                          ");
		sql.append("	        A.PT10,                                                                         ");
		sql.append("	        A.OT1,                                                                          ");
		sql.append("	        A.OT2,                                                                          ");
		sql.append("	        A.OT3,                                                                          ");
		sql.append("	        A.OT4,                                                                          ");
		sql.append("	        A.OT5,                                                                          ");
		sql.append("	        A.OT6,                                                                          ");
		sql.append("	        A.OT7,                                                                          ");
		sql.append("	        A.OT8,                                                                          ");
		sql.append("	        A.OT9,                                                                          ");
		sql.append("	        A.OT10,                                                                         ");
		sql.append("	        A.ST1,                                                                          ");
		sql.append("	        A.ST2,                                                                          ");
		sql.append("	        A.ST3,                                                                          ");
		sql.append("	        A.ST4,                                                                          ");
		sql.append("	        A.ST5,                                                                          ");
		sql.append("	        A.ST6,                                                                          ");
		sql.append("	        A.ST7,                                                                          ");
		sql.append("	        A.ST8,                                                                          ");
		sql.append("	        A.ST9,                                                                          ");
		sql.append("	        A.ST10,                                                                         ");
		sql.append("	        A.OBJECTIVE,                                                                    ");
		sql.append("	        A.CONSULT_COMMENT,                                                              ");
		sql.append("	        A.GENBYOUREKI,                                                                  ");
		sql.append("	        A.COMPLICATIONS,                                                                ");
		sql.append("	        A.TABOO,                                                                        ");
		sql.append("	        A.STOP_KIJYUN,                                                                  ");
		sql.append("	        A.FREQUENCY,                                                                    ");
		sql.append("	        A.INFECTIOUS,                                                                   ");
		sql.append("	        A.KIOUREKI,                                                                     ");
		sql.append("	        A.SYORI_FLAG,                                                                   ");
		sql.append("	        A.PT_FLAG,                                                                      ");
		sql.append("	        A.OT_FLAG,                                                                      ");
		sql.append("	        A.ST_FLAG,                                                                      ");
		sql.append("	        A.BU_FLAG,                                                                      ");
		sql.append("	        A.SYUJYUTUBI,                                                                   ");
		sql.append("	        A.KYUSEIZOUAKUBI,                                                               ");
		sql.append("	        A.DISUSE_GASYOU,                                                                ");
		sql.append("	        A.DISUSE_ADL,                                                                   ");
		sql.append("	        A.DISUSE_KAINYU,                                                                ");
		sql.append("	        A.DISUSE_KAIZEN,                                                                ");
		sql.append("	        A.DISUSE_CONTENTS,                                                              ");
		sql.append("	        A.IRAI_KUBUN,                                                                   ");
		sql.append("	        A.DISUSE_FIMBI,                                                                 ");
		sql.append("	        SUBSTR(A.YOIN_START_DATE,1, 10),                                                ");
		sql.append("	        SUBSTR(A.YOIN_SINDAN_DATE,1, 10),                                               ");
		sql.append("	        A.SU_1,                                                                         ");
		sql.append("	        A.SU_2_1,                                                                       ");
		sql.append("	        A.SU_2_2,                                                                       ");
		sql.append("	        A.SU_2_3,                                                                       ");
		sql.append("	        A.SU_2_4,                                                                       ");
		sql.append("	        A.SU_3_1,                                                                       ");
		sql.append("	        A.SU_3_2,                                                                       ");
		sql.append("	        A.SU_4_1,                                                                       ");
		sql.append("	        A.SU_4_2,                                                                       ");
		sql.append("	        A.SU_4_3,                                                                       ");
		sql.append("	        A.KE_FLAG,                                                                      ");
		sql.append("	        A.IMAGE,                                                                        ");
		sql.append("	        A.IMAGE_PATH,                                                                   ");
		sql.append("	        A.IMAGE_SEQ,                                                                    ");
		sql.append("	        DATE_FORMAT(IFNULL(A.CR_TIME, SYSDATE()),'%Y/%m/%d %H:%i:%s') CR_TIME           ");
		sql.append("	  FROM PHY8002 A                                                                        ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code                                                       ");
		sql.append("	   AND A.FK_OCS    = :f_fk_ocs                                                          ");

		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_fk_ocs", fkOcs);
		
		List<Phy8002U01GrdPhy8002LisItemInfo> list = new JpaResultMapper().list(query, Phy8002U01GrdPhy8002LisItemInfo.class);
		return list;
	}
}

