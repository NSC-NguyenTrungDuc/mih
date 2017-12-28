package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.bass.BAS0123U00FwkZipCodeInfo;
import nta.med.data.model.ihis.bass.BAS0123U00GrdBAS0123Info;
import nta.med.data.model.ihis.system.BasManageZipCodeInfo;

/**
 * @author dainguyen.
 */
public interface Bas0123RepositoryCustom {
	
	public List<String> getNuroCboZipCodeInfo(String zipCode1, String zipCode2);
	
	public List<BasManageZipCodeInfo> getBasManageZipCodeInfo(String condition, String address, String zip1, String zip2);
	
	public String getBAS0110U00LayZipCode2Info(String zipCode1, String zipCode2);
	
	public String getBAS0110U00GrdJohapGubunZipCode(String zipCode1, String zipCode2);
	
	public List<BAS0123U00GrdBAS0123Info> getBAS0123U00GrdBAS0123Info(String zipCode);
	
	public List<BAS0123U00FwkZipCodeInfo> getBAS0123U00FwkZipCodeInfo(String code, String find1);

	public List<String> getZipNameByZipCode(String zipCode1, String zipCode2);


}


