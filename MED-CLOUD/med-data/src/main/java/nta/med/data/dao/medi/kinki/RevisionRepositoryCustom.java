package nta.med.data.dao.medi.kinki;

import java.util.List;

import nta.med.data.model.ihis.system.CacheRevisionInfo;

public interface RevisionRepositoryCustom {
	public List<CacheRevisionInfo> getCacheRevisionInfo(String hospCode);
}
