package nta.med.data.dao.medi.adm;

import java.util.Date;

import nta.med.core.domain.adm.Adm3100;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Adm3100Repository extends Adm3100RepositoryCustom, CacheRepository<Adm3100> {
	public Integer updateADM103SaveLayout( String hospCode,
			 String groupNm, String sysId,
			 Date updTime, String userGroup, String language);

	public Integer deleteADM103SaveLayout( String hospCode, String userGroup, String language);
}

