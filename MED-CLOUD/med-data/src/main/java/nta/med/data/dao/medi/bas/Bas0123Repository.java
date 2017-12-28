package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.bas.Bas0123;
import nta.med.data.dao.medi.CacheRepository;

/**
 * @author dainguyen.
 */
public interface Bas0123Repository extends Bas0123RepositoryCustom , CacheRepository<Bas0123>{
	public List<Bas0123> getBAS0001U00ControlDataValidating(String zipCode);
	
	public List<Bas0123> getFwkZipCode(String code,String find1);
	
	public List<Bas0123> getBAS0123U00GrdBAS0123(String code);
	
	public List<Bas0123> getByZipCode(String code);
	
	public String checkExistBas0123U00(
			String code,
			String zipName1,
			String zipName2,
			String zipName3);
	
	public Integer updateBas0123 (
			String updId,
			Date updDate,
			String zipName1 ,
			String zipName2 ,
			String zipName3 ,
			String zipNameGana1 ,
			String zipNameGana2 ,
			String zipNameGana3 ,
			String zipTonggye,
			String zipCode);
	
	public Integer deleteBas0123(String zipCode);
}

