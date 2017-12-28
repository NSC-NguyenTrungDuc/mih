package nta.med.data.dao.medi.drg;

import java.util.List;

import nta.med.data.model.ihis.drgs.DRG3010Q12grdDrgHistoryInfo;

/**
 * @author dainguyen.
 */
public interface Drg9005RepositoryCustom {

	public List<DRG3010Q12grdDrgHistoryInfo> getDRG3010Q12grdDrgHistoryInfo(String hospCode, String language, String yyyymm, String bunho, Integer startNum, Integer offset);

	public boolean callProcDrg9005SeriesNew(String userId, String hospCode, String orderFrom, String bunho, String inOutGubun);

}

