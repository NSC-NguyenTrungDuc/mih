package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.bass.HOTCODEMASTERGetGrdListInfo;

public interface AdmHotCodeRepositoryCustom {
	public Integer truncateAdmHotCode();
	public List<HOTCODEMASTERGetGrdListInfo> getHOTCODEMASTERGetGrdListInfo(String hotCode, String hangmogName, Integer pageNumber, Integer offset);
}
