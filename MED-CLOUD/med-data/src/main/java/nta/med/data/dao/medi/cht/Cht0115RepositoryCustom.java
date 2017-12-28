package nta.med.data.dao.medi.cht;

import java.util.List;

import nta.med.data.model.ihis.chts.CHT0115Q00GrdScInfo;
import nta.med.data.model.ihis.chts.CHT0115Q00SusikCodeInfo;
import nta.med.data.model.ihis.chts.CHT0115Q01grdCHT0115Info;

/**
 * @author dainguyen.
 */
public interface Cht0115RepositoryCustom {
	public List<CHT0115Q01grdCHT0115Info> getCHT0115Q01grdCHT0115ListItem(String hospCode, String susikDetail, Integer pageNumber, Integer offset);
	
	public String getCht0115Q01TransactionModifiedChk(String hospCode, String susikCode);
	public List<CHT0115Q00SusikCodeInfo> getCHT0115Q00SusikCodeInfo(String hospCode,String susikCode);
	public List<CHT0115Q00GrdScInfo> getCHT0115Q00GrdScPost(String hospCode,String susikDetailGubun,String susikName);
	public List<CHT0115Q00GrdScInfo> getCHT0115Q00GrdScPre(String hopsCode,String ioGubun,String userId,String susikDetailGubun,String susikName);
	
	public String callPrAdmUpdateMasterSusik(String hospCode, String userId, String procGubun);
}

