package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.nuri.NUR9999R11grdNUR9999Info;

/**
 * @author dainguyen.
 */
public interface Nur9999RepositoryCustom {
	
	public List<NUR9999R11grdNUR9999Info> getNUR9999R11grdNUR9999Info(String hospCode, Double fkinp1001, String language);
}

