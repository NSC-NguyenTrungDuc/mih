package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.ocso.OCS1003R02LayR02ListItemInfo;

/**
 * @author dainguyen.
 */
public interface Nur1003RepositoryCustom {
	public List<OCS1003R02LayR02ListItemInfo> getOCS1003R02LayOutListItemInfo(String hospCode, String gwaOut, String gwaNameOut, String bunhoOut,
			String sunameOut, String balheangDateOut, String birthOut, String naewonDateOut, String bunho1Out, String dangilGumsaResultYnOut,
			String jaedanName, String hospName, String tel, String homePage, Double fkout1001);
	public String callPrNurMakePatienInfo(String hospCode, String language, String bunho, Double fkout1001, String userId);
}

