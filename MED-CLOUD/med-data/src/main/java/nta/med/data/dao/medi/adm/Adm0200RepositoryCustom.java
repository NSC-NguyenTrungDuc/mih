package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.adma.ADM101UgrdSystemItemInfo;
import nta.med.data.model.ihis.adma.ADM103LaySysListGrpInfo;
import nta.med.data.model.ihis.adma.ADM401UGrdSysItemInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GetSystemListInfo;
import nta.med.data.model.ihis.adma.ADMSStartFormLoginInfo;
import nta.med.data.model.ihis.adma.OcsPemRU00GrdListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;

/**
 * @author dainguyen.
 */
public interface Adm0200RepositoryCustom {
	public List<ADM103LaySysListGrpInfo> getADM103LaySysListGrpInfo(String hospCode, String language);
	
	public List<ComboListItemInfo> getAdm102UFwkSysIdListItem(String hospCode, String language, String role);
	
	public String getAdm102UfbxSysId(String hospCode, String language, String sysId, String role);
	
	public List<ADM101UgrdSystemItemInfo> getADM101UgrdSystemItemInfo(String hospCode,String language,String grdId);
	
	public List<ADM401UGrdSysItemInfo> getADM401UGrdSysItemInfo(String language,String grdId);	
	
	public String getAdm106UFbxSysIdItem(String sysId, String language);
	
	public List<ComboListItemInfo> getAdm108UlaySysList(String language);
	
	public List<Adm108UTvwSystemListItemInfo> getAdm108UTvwSystemListItem(String language, String pgmId);
	
	public List<ComboListItemInfo> getLayLogSysList(String hospCode, String language, String userId);
	
	public List<ComboListItemInfo> getOcsPemRU00FwkSysIdListItem(String language);
	
	public List<OcsPemRU00GrdListItemInfo> getOcsPemRU00GrdListItem(String hospCode, String language);
	
	public String getOcsPemRU00GrdFbxSysId(String dataValue, String language);
	public List<ADMSStartFormLoginInfo> getADMSStartFormLoginInfo(String hospCode, String userId, String language, boolean user);
	public List<ADMS2015U00GetSystemListInfo> getADMS2015U00GetSystemListInfo(String grpId, String language);
	public List<ADM103LaySysListGrpInfo> getADM103LaySysListGrpInfoSAM(String language);
	public boolean isExistedADM0200(String sysId, String language);
	
	public List<ComboListItemInfo> findFwkSystem(String hospCode, String language);
}

