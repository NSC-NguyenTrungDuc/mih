package nta.med.data.dao.medi.out.impl;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.StoredProcedureQuery;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0103RepositoryCustom;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridVisitListInfo;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.StringUtils;

/**
 * @author dainguyen.
 */
public class Out0103RepositoryImpl implements Out0103RepositoryCustom {
	private static final Log LOG = LogFactory.getLog(Out0103RepositoryImpl.class);
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<DetailPaInfoFormGridVisitListInfo> getDetailPaInfoFormGridVisitList(String language, String hospCode, String patientCode){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.NAEWON_DATE                                                                                   ");
		sql.append("      ,FN_BAS_LOAD_GWA_NAME(A.GWA, DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), :hospCode, :language) GWA_NAME  ");
		sql.append("      ,FN_BAS_LOAD_CODE_NAME('IN_OUT_GUBUN', A.IN_OUT_GUBUN, :hospCode, :language) GUBUN_NAME          ");
		sql.append("      ,FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, DATE_FORMAT(SYSDATE(), '%Y/%m/%d'), :hospCode) DOCTOR_NAME    ");
		sql.append("      ,A.TOIWON_DATE                                                                                   ");
		sql.append("FROM OUT0103 A                                                                                         ");
		sql.append("WHERE A.HOSP_CODE = :hospCode                                                                          ");
		sql.append("  AND A.BUNHO = :patientCode                                                                           ");
		sql.append("ORDER BY A.NAEWON_DATE DESC                                                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("hospCode", hospCode);
		query.setParameter("patientCode", patientCode);
		query.setParameter("language", language);

		List<DetailPaInfoFormGridVisitListInfo> list = new JpaResultMapper().list(query, DetailPaInfoFormGridVisitListInfo.class);

		return list;
	}
	
	@Override
	public String callPrOutInsertOut0103(String hospitalCode, String iudGubun, String user, String naewonDate, String bunho, String gwa, String gubun, String tuyakIlsu, String doctor, 
			String inOut, String chartGwa, String specialYn, String toiwonDate) {
		LOG.info("[START] callPrOutInsertOut0103 hospitalCode=" + hospitalCode + ", iudGubun=" + iudGubun 
				+ ", user=" + user + ", naewonDate=" + naewonDate + ", bunho=" + bunho 
				+ ", gwa=" +  gwa + ", gubun=" + gubun + ", tuyakIlsu=" + tuyakIlsu + ", doctor=" + doctor 
				+ ", inOut=" + inOut + ", chartGwa=" + chartGwa + ", specialYn=" + specialYn + ", toiwonDate=" + toiwonDate );
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OUT_INSERT_OUT0103");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IUD_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_USER", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_NAEWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_BUNHO", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GUBUN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TUYAK_ILSU", Integer.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_IN_OUT", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_CHART_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_SPECIAL_YN", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TOIWON_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("O_ERR", String.class, ParameterMode.INOUT);       
		
		query.setParameter("I_HOSP_CODE",hospitalCode);
		query.setParameter("I_IUD_GUBUN",iudGubun);
		query.setParameter("I_USER",user);
		query.setParameter("I_NAEWON_DATE",DateUtil.toDate(naewonDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_BUNHO",bunho);
		query.setParameter("I_GWA",gwa);
		query.setParameter("I_GUBUN",gubun);
		query.setParameter("I_TUYAK_ILSU",!StringUtils.isEmpty(tuyakIlsu) ? 0 : Integer.parseInt(tuyakIlsu));
		query.setParameter("I_DOCTOR",doctor);
		query.setParameter("I_IN_OUT",inOut);
		query.setParameter("I_CHART_GWA",chartGwa);
		query.setParameter("I_SPECIAL_YN",specialYn);
		query.setParameter("I_TOIWON_DATE",DateUtil.toDate(toiwonDate, DateUtil.PATTERN_YYMMDD));
		query.setParameter("O_ERR","");
		
		Boolean isValid = query.execute();
		String ioFlg = (String)query.getOutputParameterValue("O_ERR");
		return ioFlg;
	}

	@Override
	public List<String> callPrcLoadDoctorJinryoTime(String hospCode, String gwa,
			String doctor, String date, String time, String ioAmPm,
			String ioFromTime, String ioToTime, String ioFlag) {
		
		
		StoredProcedureQuery  query = entityManager.createStoredProcedureQuery("PR_OUT_LOAD_DOCTOR_JINRYO_TIME");
		query.registerStoredProcedureParameter("I_HOSP_CODE", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_GWA", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DOCTOR", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_DATE", Date.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("I_TIME", String.class, ParameterMode.IN);
		query.registerStoredProcedureParameter("IO_AM_PM", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FROM_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_TO_TIME", String.class, ParameterMode.INOUT);
		query.registerStoredProcedureParameter("IO_FLAG", String.class, ParameterMode.INOUT);
		
		query.setParameter("I_HOSP_CODE",hospCode);
		query.setParameter("I_GWA",gwa);
		query.setParameter("I_DOCTOR",doctor);
		query.setParameter("I_DATE",DateUtil.toDate(date, DateUtil.PATTERN_YYMMDD));
		query.setParameter("I_TIME",time);
		query.setParameter("IO_AM_PM",ioAmPm);
		query.setParameter("IO_FROM_TIME",ioFromTime);
		query.setParameter("IO_TO_TIME",ioToTime);
		query.setParameter("IO_FLAG",ioFlag);
		
		Boolean isValid = query.execute();
		
	
		List<String> list = new ArrayList<String>();
		list.add((String)query.getOutputParameterValue("IO_FROM_TIME") == null ? null :(String)query.getOutputParameterValue("IO_FROM_TIME"));
		list.add((String)query.getOutputParameterValue("IO_TO_TIME") == null ? null :(String)query.getOutputParameterValue("IO_TO_TIME"));
		list.add((String)query.getOutputParameterValue("IO_FLAG") == null ? null :(String)query.getOutputParameterValue("IO_FLAG"));

		return list;
	}
}

