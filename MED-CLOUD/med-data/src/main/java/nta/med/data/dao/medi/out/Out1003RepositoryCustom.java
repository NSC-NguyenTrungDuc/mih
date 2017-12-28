package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.nuro.NuroORDERTRANSUpdateOCS1003SelectToInsert;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListSendYnInfo;

/**
 * @author dainguyen.
 */
public interface Out1003RepositoryCustom {
	public List<ORDERTRANSGrdListSendYnInfo> getORDERTRANSGrdListSendYnInfo(String hospCode, String language, String bunho);
	
	public Integer callPrIfsOutOrderMasterInsert(String hospCode, String bunho, Date actingDate, String gubun,String gwa, String doctor, String chojae);
	
	public List<NuroORDERTRANSUpdateOCS1003SelectToInsert> getNuroORDERTRANSUpdateOCS1003SelectToInsert(String hospCode, String bunho, 
			Double pkout1001, boolean orderTrans, boolean isMisa);
	
	
	public Double getNuroORDERTRANSUpdateOCS1003Pkocs1003IfExists(String hospCode, Double pkout1001, NuroORDERTRANSUpdateOCS1003SelectToInsert nuroORDERTRANSUpdateOCS1003);
	public String callPrInpUpdateOut0103(String hospCode, String userId, Date naewonDate, String bunho, String gwa,
			String gubun, String doctor, String inOut, String jubsuGwa, int tuyakIlsu, String specialYn, Date toiwonDate);
	
}

