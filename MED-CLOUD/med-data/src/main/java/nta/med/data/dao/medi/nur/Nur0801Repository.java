package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.core.domain.nur.Nur0801;
import nta.med.data.dao.medi.CacheRepository;

public interface Nur0801Repository extends Nur0801RepositoryCustom, CacheRepository<Nur0801> {

	public List<Nur0801> findByHospCodeHoDong(String hospCode, String hoDong);

	public Integer updateByHospCodeHoDOng(String updId, String makeHFileYn, String hospCode, String hoDong);

	public Integer deleteByHospCodeHoDong(String hospCode, String hoDong);
}
