package nta.med.data.dao.medi.xrt;

import nta.med.core.domain.xrt.Xrt0121;
import nta.med.data.dao.medi.CacheRepository;
import org.springframework.data.repository.query.Param;

/**
 * @author dainguyen.
 */
public interface Xrt0121Repository extends Xrt0121RepositoryCustom, CacheRepository<Xrt0121> {
	
	public Integer updateXrt0121Transaction(@Param("updId") String updId,
			@Param("buwiBunryuName") String buwiBunryuName,
			@Param("hospCode") String hospCode,
			@Param("buwiBunryu") String buwiBunryu,
			@Param("language") String language);
	
		public Integer deleteXrt0121Transaction(@Param("hospCode") String hospCode,
				@Param("buwiBunryu") String buwiBunryu,
				@Param("language") String language);
	
}

