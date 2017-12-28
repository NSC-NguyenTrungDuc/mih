package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADM107ULayDownListInfo;
import nta.med.data.model.ihis.adma.ADMS2015U01MenuInfo;
import nta.med.data.model.ihis.adma.ADMS2016MenuInfo;

/**
 * @author dainguyen.
 */
public interface Adm4100RepositoryCustom {
	public List<ADM107ULayDownListInfo> getAdm107uLayDownListInfo(String hospitalCode, String language, String userId, String sysId, String upprMenu);
	public List<ADM107ULayDownListInfo> getAdm107uLayDownListInfo(String hospitalCode, String langauge, String userId, String sysId);
	public List<ADM107ULayDownListInfo> getAdm107uLayRootListInfo(String hospitalCode, String language, String userId, String sysId);
	
	public String getAdm106UMaxValueCaseAdded(String hospCode, String language, String sysId, String role);
	
	public String getAdm106Uchkdelete(String hospCode, String language, String sysId, String trId, String role);
	
	public List<ADMS2015U01MenuInfo> getADMS2015U01LoadUpperMenu(String sysId, String hospCode, String language);
	
	public List<ADMS2015U01MenuInfo> getADMS2015U01LoadMenuItem(String sysId, String hospCode, String language, String upprMenu);
	
	public List<ADMS2016MenuInfo> getMenuBySysIDs(String sysId, String language);
	
}

