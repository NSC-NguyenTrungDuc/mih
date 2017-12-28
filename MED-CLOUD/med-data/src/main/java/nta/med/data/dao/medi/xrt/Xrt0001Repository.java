package nta.med.data.dao.medi.xrt;

import java.util.List;

import nta.med.core.domain.xrt.Xrt0001;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Xrt0001Repository extends Xrt0001RepositoryCustom, CacheRepository<Xrt0001> {

	public String getXRT0000Q00GetModalityCode(String hospCode,String hangmogCode);

	public String getYValueLayDupXRT0001U00Initialize(String hospCode,String xrayCode);

	public Integer updateXRT0001U00ExecuteCase1(String hospCode,String userId,String xrayName,
			String xrayGubun,String xrayRoom,
			String xrayBuwi,String xrayBuwiKaiKei,
			String xrayGu,Double xrayGubun1);
	
	public Integer deleteXRT0001U00ExecuteCase1(String hospCode,String xrayCode);
	
	public List<Xrt0001> getObjectXrt0001ExecuteCase1(String hospCode,String xrayCode);
	
}
