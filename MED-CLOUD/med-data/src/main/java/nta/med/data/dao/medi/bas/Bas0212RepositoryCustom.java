package nta.med.data.dao.medi.bas;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.bass.BAS0212U00GrdItemInfo;
import nta.med.data.model.ihis.bass.BAS0212U00fwkGongbiCodeInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetInsuranceCode;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GetInsuranceInfo2;

/**
 * @author dainguyen.
 */
public interface Bas0212RepositoryCustom {
	public String callFnBasLoadGongbiName(String GongbiCode, Date jukyongYmd, String language);
	
	public List<NuroOUT0101U02GetInsuranceInfo2> getNuroOUT0101U02GetInsuranceInfo2(String find1, String language);
	
	public String getNuroOUT0101U02GetInsuranceName(String gongbiCode, String language);
	
	public List<NuroOUT0101U02GetInsuranceCode> getNuroOUT0101U02GetInsuranceCode(String lawNo, String language);
	public List<String> getBAS0212U00ListItem(String code, String startDate, String language);
	public List<BAS0212U00fwkGongbiCodeInfo> getBAS0212U00fwkGongbiCode(String find1, String startDate, String language);
	public List<BAS0212U00GrdItemInfo> getBAS0212U00GrdItemInfo(String gongbiCode, String startDate, String language);
	public List<String>  getYByGongbiCodeAnDateBetWeen(String code, String startDate, String language);
	public List<String> getYByGongbiCodeAnDate(String gongbiCode, String startDate, String language);
	
	public List<ComboListItemInfo> findByHospCodeCodeType(String hospCode);
} 

