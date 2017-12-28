package nta.med.data.dao.medi.cpl;

import java.util.List;

import nta.med.data.model.ihis.cpls.CPL0000Q00ResultListQuerySelect2ListItemInfo;

/**
 * @author dainguyen.
 */
public interface Cpl3024RepositoryCustom {
	
	public List<CPL0000Q00ResultListQuerySelect2ListItemInfo> getCPL0000Q00ResultListQuerySelect2(String hospCode, String specimenSer,
			String kyunCode, Double serial);
}

