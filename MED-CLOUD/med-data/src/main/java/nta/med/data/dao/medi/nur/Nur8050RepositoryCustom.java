package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR8050U00grdNur8050HisInfo;

/**
 * @author dainguyen.
 */
public interface Nur8050RepositoryCustom {

	public List<NUR8050U00grdNur8050HisInfo> getNUR8050U00grdNur8050HisInfo(String hospCode, String bunho,
			Double fkinp1001, String gubun);

}
