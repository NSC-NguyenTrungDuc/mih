package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL0106U00GrdListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl0106RepositoryCustom {
	
	List<CPL0106U00GrdListItemInfo> getCPL0106U00GrdListItemInfo(String hospCode, String language, String codeType,
			String hangmogCode, String specimenCode, String emergency, String groupGubun);
	public String callFnCplLoadDupGrdHangmog(String hospCode,String newHanmogCode,String newSpecimenCode,String oldHanmogCode,String oldSpecimenCode  );
	public boolean isExistedCpl0106(String hospCode, String hangmocCode, String specimenCode, String emergency, String subHanmogCode);

}

