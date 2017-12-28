package nta.med.data.dao.medi.ocs;

import java.util.List;

import nta.med.core.domain.ocs.Ocs4001;
import nta.med.data.model.ihis.ocso.OCS4001U00LeftGrdViewInfo;

public interface Ocs4001RepositoryCustom {
	public List<OCS4001U00LeftGrdViewInfo> getOcs4001LeftGrdView(String hospCode, String tplCode, String bunho);
	public Ocs4001 getOcs4001InputContent(String id);
}
