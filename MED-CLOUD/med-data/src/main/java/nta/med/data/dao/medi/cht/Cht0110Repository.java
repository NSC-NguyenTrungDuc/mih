package nta.med.data.dao.medi.cht;

import java.util.Date;

import nta.med.core.domain.cht.Cht0110;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Cht0110Repository extends Cht0110RepositoryCustom , CacheRepository<Cht0110>{
	
	public String getCHT0110U00GetCodeName(String hospCode,String code);
	
	public String getSangCodeExt(String hospCode,String sangCode);
	
	public Integer deleteCHT0110U00(String hospCode,String sangCode);
	
	public Integer updateCHT0110U00(String hospCode,String userId,
			String sangName,String sangNameHan
			,String sangNameSelf,Date endDate
			,String bulyongYn,String sangCode);
}

