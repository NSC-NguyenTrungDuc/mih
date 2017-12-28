package nta.med.data.dao.medi.nur;

import java.util.List;

import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.injs.InjsINJ1001U01XEditGridCell89ItemInfo;
import nta.med.data.model.ihis.nuri.NUR0101U01GrdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR0801U00GrdMasterInfo;
import nta.med.data.model.ihis.nuri.NUR0802U00grdDetailInfo;
import nta.med.data.model.ihis.nuri.NUR1001U00LayComboSetInfo;
import nta.med.data.model.ihis.nuri.NUR1010Q00layTimeInfo;
import nta.med.data.model.ihis.nuri.NUR1020U00grdNUR1022INInfo;
import nta.med.data.model.ihis.nuri.NUR8003R02grdDetailInfo;
import nta.med.data.model.ihis.system.TripleListItemInfo;

/**
 * @author dainguyen.
 */
public interface Nur0102RepositoryCustom {
	
	public List<ComboListItemInfo> getNuroComboTime(String language, String hopitalCode, String codeType, boolean orderBySortKey);
	public List<ComboListItemInfo> getCboTimeList(String hospCode,String language);
	
	public List<ComboListItemInfo> getNUR1016U00xEditGridCell7(String hospCode, String language);
	
	public List<ComboListItemInfo> getNUR1016U00layComboSet(String hospCode, String codeType, String language); 
	public List<ComboListItemInfo> getINJ1001U01XEditGridCell88(String hospCode, String language);
	public List<InjsINJ1001U01XEditGridCell89ItemInfo> getInjsINJ1001U01XEditGridCell89ItemInfo(String hospCode, String language);
	public List<ComboListItemInfo> getNUR1017U00GetComboListItem(String hospCode, String codeType, String language);
	public List<ComboListItemInfo> getCodeNameComboListItem (String codeType);
	
	public List<NUR0101U01GrdDetailInfo> getNUR0101U01GrdDetailInfo(String hospCode, String codeType, String language);
	public List<ComboListItemInfo> getNUR0812U00XeditGridCell1(String hospCode, String codeType, String language);
	public List<ComboListItemInfo> getNUR0812U00XeditGridCell3(String hospCode, String codeType, String language);
	public String getNUR0102CodeName(String hospCode, String language, String codeType, String code);
	public List<String> getNUR6011U01GetNur6005(String hospCode, String language, String bunho);
	
	public List<NUR1020U00grdNUR1022INInfo> getNUR1020U00grdNUR1022INInfo(String hospCode, String bunho,
			Double fkInp1001, String orderDate, String gubn, String prevqryflag, String gubnType);
	
	public List<ComboListItemInfo> getCbxNUR1020U00layHangmog(String hospCode, String bunho, Double fkinp1001);
	public List<TripleListItemInfo> getNUR6011U01layComboSet(String hospCode, String language, String codeType);
	public List<NUR1010Q00layTimeInfo> getNUR1010Q00layTimeInfo(String hospCode, String language);
	
	public List<NUR0801U00GrdMasterInfo> getNUR0801U00GrdMasterInfo(String hospCode, String language, String needType);
	public List<String> getNUR1001R09layHodongPrint(String hospCode, String language, String hoDong);
	public List<NUR0802U00grdDetailInfo> getNUR0802U00grdDetailInfo(String hospCode, String language, String needType,
			String codeType, Integer startNum, Integer offset);
	public List<ComboListItemInfo> getNUR1035U00layModifyLimit(String hospCode, String codeType, String language);
	public List<ComboListItemInfo> getNUR9001U00layComboSet(String hospCode, String language);
	
	public List<NUR8003R02grdDetailInfo> getNUR8003R02grdDetailInfo(String hospCode, String language, String bunho,
			String needHType, String fromDate, String toDate, String writeDong);
	public String getNUR9001U00lblBojo(String hospCode, String language, String codeType, String code);
	public List<NUR1001U00LayComboSetInfo> getNUR1001U00LayComboSetInfo(String hospCode, String language);
	public List<String> getNUR1001U00GrdNUR1029FindClick(String hospCode, String language, String codeType);
}

