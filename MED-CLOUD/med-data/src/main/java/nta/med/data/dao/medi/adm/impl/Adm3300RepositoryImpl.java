package nta.med.data.dao.medi.adm.impl;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.data.dao.medi.adm.Adm3300RepositoryCustom;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Adm3300RepositoryImpl implements Adm3300RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Adm3300RepositoryImpl.class);
	
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public String getNexTrmId(String hospCode) {
		StringBuffer sql = new StringBuffer("SELECT TRIM(CONCAT('TRM',LPAD(CAST(SUBSTR(IFNULL(MAX(TRM_ID),'TRM000'),4,3) AS SIGNED )+1,3,'0'))) FROM ADM3300 WHERE HOSP_CODE = :hospCode ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		
		List<String> result = query.getResultList();
		if(!result.isEmpty()){
			 return result.get(0);
		}
		return "";
	}

	@Override
	public Integer updateAdm3300(String hospCode, String userId, Date upTime, String bPrintName, String ipAddr){
		StringBuffer sql = new StringBuffer("");
		sql.append("UPDATE ADM3300                              ");
		sql.append("  SET USER_ID         = :userId             ");
		sql.append("        , UP_TIME         = :upTime         ");
		sql.append("        , B_PRINT_NAME    = :bPrintName     ");
		sql.append("WHERE HOSP_CODE       = :hospCode           ");
		sql.append("  AND IP_ADDR         = :ipAddr		        ");
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("userId", userId);
		query.setParameter("upTime", upTime);
		query.setParameter("bPrintName", bPrintName);
		query.setParameter("ipAddr", ipAddr);
		return query.executeUpdate();
	}

	@Override
	public String getLayPrintName(String hospCode, String ipAddr) {
		StringBuilder sql= new StringBuilder();
		sql.append("SELECT B_PRINT_NAME FROM ADM3300 WHERE HOSP_CODE= :f_hosp_code AND IP_ADDR = :f_ip_addr");
		
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ip_addr", ipAddr);
		
		List<String> bPrintName=query.getResultList();
		if(!bPrintName.isEmpty()){
			return bPrintName.get(0);
		}
		return null;
	
	}

	@Override
	public Integer updateCPL2010U00SetPrint(String hospCode, String userId,String bPrintName, String ipAddr) {
		StringBuilder sql= new StringBuilder();
		sql.append("  UPDATE ADM3300                      ");
		sql.append("  SET USER_ID         = :q_user_id    ");
		sql.append(" , UP_TIME         = SYSDATE()        ");
		sql.append(" , B_PRINT_NAME    = :f_b_print_name  ");
		sql.append(" WHERE HOSP_CODE       = :f_hosp_code ");
		sql.append(" AND IP_ADDR         = :f_ip_addr    ");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("q_user_id", userId);
		query.setParameter("f_b_print_name", bPrintName);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_ip_addr", ipAddr);
		return query.executeUpdate();
	}

	@Override
	public String getTTrmIdCPL2010U00SetPrint(String hospCode) {
		StringBuilder sql= new StringBuilder();
		sql.append(" SELECT TRIM(CONCAT('TRM',LPAD(CAST(SUBSTRING(IFNULL(MAX(TRM_ID),'TRM000'),4,3) AS SIGNED)+1,3,'0')))       ");
		sql.append(" T_TRM_ID FROM ADM3300 WHERE HOSP_CODE = :f_hosp_code														");
		Query 	query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		List<String> tTrimId=query.getResultList();
		if(!CollectionUtils.isEmpty(tTrimId)){
			return tTrimId.get(0);
		}
		return null;
	}

	@Override
	public Integer insertCPL2010U00SetPrint(String hospCode,String tTrimId, String ipAddr,String userId, String bPrintName) {
		StringBuilder sql=new StringBuilder();
		sql.append(" INSERT INTO ADM3300                                                           ");
		sql.append(" ( TRM_ID,    IP_ADDR,      SYS_ID,     USER_ID,     DEPT_CODE,  HOSP_CODE,    ");
		sql.append("  USE_YN,    SERVER_IP,    CR_MEMB,    CR_TIME,     CR_TRM,     B_PRINT_NAME)  ");
		sql.append(" VALUES                                                                        ");
		sql.append(" (:t_trim_id, :f_ip_addr,   :q_user_id, :q_user_id,  NULL,      :f_hosp_code,   ");
		sql.append("  NULL,      NULL,         :q_user_id, SYSDATE(),     NULL,      :f_b_print_name)");
		Query query= entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_ip_addr", ipAddr);
		query.setParameter("t_trim_id", tTrimId);
		query.setParameter("q_user_id", userId);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_b_print_name", bPrintName);
		return query.executeUpdate();
	}
}

