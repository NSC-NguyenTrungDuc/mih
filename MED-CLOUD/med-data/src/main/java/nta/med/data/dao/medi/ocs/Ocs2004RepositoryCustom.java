package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.data.model.ihis.inps.CommonProcResultInfo;

/**
 * @author dainguyen.
 */
public interface Ocs2004RepositoryCustom {

	public CommonProcResultInfo callPrOcsiAutoCreateJisi(String hospCode, double fkinp1001, String bunho,
			String inputGubun, String inputId, String inputGwa, String inputDoctor, Date orderDate, String orderTime);
	
	public CommonProcResultInfo callPrOcsiOcs2005Dup(String hospCode, String iud, String gubun, String bunho,
			double fkinp1001, Date fromDate, String fromTime, Date toDate, String toTime, String user, Double pkocs2005);
}