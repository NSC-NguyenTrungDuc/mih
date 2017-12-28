package nta.med.data.dao.medi.nut;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.data.model.ihis.nuts.NUT9001Q01grdListInfo;

/**
 * @author dainguyen.
 */
public interface Nut2010RepositoryCustom {
	
	public List<NUT9001Q01grdListInfo> getNUT9001Q01grdListInfo(String hospCode, Date nutDate, String bldGubun, Double magamSeq, String hoDong);
	
	public CommonProcResultInfo callPrNutMagam(String hospCode, String updId, Date magamDate, String bldGubun, String nutMagamGubun);
	
	public CommonProcResultInfo callPrIfsNutProcMain(String hospCode, Double masterFk, String sendYn);
	
}

