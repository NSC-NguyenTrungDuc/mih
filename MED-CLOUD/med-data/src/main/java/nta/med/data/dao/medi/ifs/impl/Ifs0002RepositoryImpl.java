package nta.med.data.dao.medi.ifs.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.data.dao.medi.ifs.Ifs0002RepositoryCustom;
import nta.med.data.model.ihis.adma.IFS0001U00GrdDetailInfo;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.data.model.ihis.bass.ComBizLoadIFS0002Info;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.springframework.util.CollectionUtils;

/**
 * @author dainguyen.
 */
public class Ifs0002RepositoryImpl implements Ifs0002RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<ComboListItemInfo> getIfs003U03FwkCommonListItem(
			String hospCode, String codeType, String find, boolean orderByHospCode, Integer startNum, Integer endNum) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE							");
		sql.append("	     , A.CODE_NAME                      ");
		sql.append("	  FROM IFS0002 A                        ");
		sql.append("	 WHERE A.HOSP_CODE = :f_hosp_code       ");
		sql.append("	   AND A.CODE_TYPE = :f_code_type       ");
		sql.append("	   AND (   A.CODE      LIKE :f_find1    ");
		sql.append("	        OR A.CODE_NAME LIKE :f_find1    ");
		sql.append("	       )                                ");
		if(orderByHospCode){
			sql.append("	ORDER BY A.HOSP_CODE, A.CODE_TYPE, A.CODE   ");
		}else{
			sql.append("	 ORDER BY A.CODE                        ");
		}
		if(startNum != null && endNum != null){
			sql.append("	      LIMIT :startNum, :endNum              ");
		}

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_find1", find+"%");
		if(startNum != null && endNum != null){
			query.setParameter("startNum", startNum);
			query.setParameter("endNum", endNum);
		}
		
		List<ComboListItemInfo> list = new JpaResultMapper().list(query, ComboListItemInfo.class);
		return list;
	}

	@Override
	public String getIfs003U03FbxSearchGubun(String hospCode, String codeType,
			String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_NAME						");
		sql.append("	 FROM IFS0002 A                         ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code      ");
		sql.append("	  AND A.CODE_TYPE   = :f_code_type      ");
		sql.append("	  AND A.CODE        = :f_code           ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_code", code);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	
	@Override
	public String callPkgIfsBasFnLoadIfCodeName(String hospCode,
			String mapGubun, String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT PKG_IFS_BAS_FN_LOAD_IF_CODE_NAME(:f_hosp_code, :f_map_gubun, :f_code ) IF_CODE_NAME	");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_map_gubun", mapGubun);
		query.setParameter("f_code", code);
		
		List<String> result = query.getResultList();
		if(!CollectionUtils.isEmpty(result)){
			return result.get(0);
		}
		return null;
	}
	@Override
	public List<IFS0001U00GrdDetailInfo> getIFS0001U00GrdDetailInfo(String hospCode, String codeType, Integer pageNumber, Integer offset){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.CODE_TYPE                          ");
		sql.append("     , A.CODE                               ");
		sql.append("     , A.CODE_NAME                          ");
		sql.append("     , A.REMARK                             ");
		sql.append("  FROM IFS0002 A                            ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code           ");
		sql.append("   AND A.CODE_TYPE = :f_code_type           ");
		sql.append(" ORDER BY A.HOSP_CODE, A.CODE_TYPE, A.CODE  ");
		sql.append(" LIMIT :f_page_number,:f_offset 			");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_code_type", codeType);
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_page_number",pageNumber);
		query.setParameter("f_offset", offset);
		
		List<IFS0001U00GrdDetailInfo> list = new JpaResultMapper().list(query, IFS0001U00GrdDetailInfo.class);
		return list;
	}

	@Override
	public List<ComBizLoadIFS0002Info> getComBizLoadIFS0002ListItem(
			String hospCode, String codeType, String code) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_TYPE, A.CODE, A.CODE_NAME, A.REMARK 		");
		sql.append("	     , A.SYS_DATE, A.SYS_ID, A.UPD_DATE, A.UPD_ID       ");
		sql.append("	  FROM IFS0002 A                                        ");
		sql.append("	 WHERE A.HOSP_CODE = :hospCode                          ");
		sql.append("	   AND A.CODE_TYPE = :codeType                          ");
		sql.append("	   AND A.CODE      = :code                              ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("codeType", codeType);
		query.setParameter("code", code);
		
		List<ComBizLoadIFS0002Info> list = new JpaResultMapper().list(query, ComBizLoadIFS0002Info.class);
		return list;
	}

	@Override
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerInfoCaseCodeType(
			String hospCode, String find) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_TYPE       AS CODE			");			
		sql.append("	    , A.CODE_TYPE_NAME  AS CODE_NAME        ");
		sql.append("	 FROM IFS0002 A                             ");
		sql.append("	WHERE A.HOSP_CODE          = :hospCode      ");
		sql.append("	  AND (   A.CODE_TYPE      LIKE :find       ");
		sql.append("	       OR A.CODE_TYPENAME  LIKE :find       ");
		sql.append("	      )                                     ");
		sql.append("	ORDER BY A.HOSP_CODE, A.CODE_TYPE           ");
		

		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("find", "%"+find+"%");
		
		List<ComBizGetFindWorkerInfo> list = new JpaResultMapper().list(query, ComBizGetFindWorkerInfo.class);
		return list;
	}

	@Override
	public List<ComBizGetFindWorkerInfo> getComBizGetFindWorkerInfoCaseCodeOLD(
			String hospCode, String codeType, String find) {
		StringBuilder sql = new StringBuilder();
		
		sql.append("	SELECT A.CODE_NAME						");
		sql.append("	,' '								    ");
		sql.append("	,' '								    ");
		sql.append("	SELECT A.CODE_NAME						");
		sql.append("	 FROM IFS0002 A                         ");
		sql.append("	WHERE A.HOSP_CODE   = :f_hosp_code      ");
		sql.append("	  AND A.CODE_TYPE   = :f_code_type      ");
		sql.append("	  AND A.CODE        LIKE :find           ");
		sql.append("	  ORDER BY A.SORT_KEY, A.CODE          ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_code_type", codeType);
		query.setParameter("find",  "%"+find+"%");
		
		List<ComBizGetFindWorkerInfo> list = new JpaResultMapper().list(query, ComBizGetFindWorkerInfo.class);
		return list;
	}
	
	
}

