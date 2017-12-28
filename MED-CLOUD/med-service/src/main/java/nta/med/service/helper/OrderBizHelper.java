package nta.med.service.helper;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;

import nta.med.core.domain.drg.Drg0120;
import nta.med.core.domain.ocs.Ocs0131;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.data.dao.medi.adm.Adm0100Repository;
import nta.med.data.dao.medi.adm.Adm3211Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.dao.medi.bas.Bas0230Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.dao.medi.ifs.Ifs0001Repository;
import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.nur.Nur0104Repository;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.dao.medi.ocs.Ocs0115Repository;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.data.dao.medi.ocs.Ocs0131Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0170Repository;
import nta.med.data.dao.medi.ocs.Ocs0204Repository;
import nta.med.data.dao.medi.xrt.Xrt0102Repository;
import nta.med.data.model.ihis.adma.IFS0001U00GrdMasterInfo;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

public class OrderBizHelper {
	private static final Log LOG = LogFactory.getLog(OrderBizHelper.class);
	
	private synchronized static <T> T getRepository(Class<T> clazz) {
		return SpringBeanFactory.beanFactory.getBean(clazz);
	}
	
	public static SystemServiceProto.GetFindWorkerResponse.Builder getFindWorker(String hospitalCode, String language, CommonModelProto.GetFindWorkerRequestInfo info){
		SystemServiceProto.GetFindWorkerResponse.Builder result = SystemServiceProto.GetFindWorkerResponse.newBuilder();
		Ocs0115Repository ocs0115Repository = getRepository(Ocs0115Repository.class);
		Bas0260Repository bas0260Repository = getRepository(Bas0260Repository.class);
		List<ComboListItemInfo> listResult;
		String argu2 = "";
		switch (info.getColname()) {
//		case "code":
//			Ocs0132Repository ocs0132Repository = getRepository(Ocs0132Repository.class);
//			List<String> codeName = ocs0132Repository.getCodeNameOrderBySortKey(hospitalCode, language, info.getArgu1(), "%" + info.getArgu2() + "%");
//			break;
		case "code_type":
			Ocs0131Repository ocs0131Repository = getRepository(Ocs0131Repository.class);
			List<Ocs0131> listOcs0131 = ocs0131Repository.getInfoOrderByCodeType(language);
			if (!CollectionUtils.isEmpty(listOcs0131)) {
				for (Ocs0131 item : listOcs0131) {
					CommonModelProto.GetFindWorkerResponseInfo.Builder builder = CommonModelProto.GetFindWorkerResponseInfo.newBuilder();
					builder.setCode(item.getCodeType());
					builder.setName(item.getCodeTypeName());
					result.addInfo1(builder);
				}
			}
		case "ord_danui_name":
			Ocs0108Repository ocs0108Repository = getRepository(Ocs0108Repository.class);
			listResult = ocs0108Repository.getGetDefaultOrdDanuiInfo(hospitalCode, language, info.getArgu1());
			if(!CollectionUtils.isEmpty(listResult)){
				for(ComboListItemInfo ordDanuiName:listResult){
					CommonModelProto.GetFindWorkerResponseInfo.Builder builder = CommonModelProto.GetFindWorkerResponseInfo.newBuilder();
					builder.setCode(ordDanuiName.getCode());
					builder.setName(ordDanuiName.getCodeName());
					result.addInfo1(builder);
				}
				
			}
			break;
		case "jundal_part_out_hangmog":
		case "jundal_part_inp_hangmog":	
		case "jundal_table_inp_hangmog":
		case "jundal_table_out_hangmog":	
		case "move_part_hangmog":
			if(!"".equals(info.getArgu2())){
				argu2 = info.getArgu2();
			}else{
				argu2 = null;
			}
			listResult = ocs0115Repository.getFindWorkerJundalHangmog(hospitalCode, language, info.getArgu1(), argu2,info.getColname());
			
			if(!CollectionUtils.isEmpty(listResult)){
				for(ComboListItemInfo jundalPartOutHangmog : listResult){
					CommonModelProto.GetFindWorkerResponseInfo.Builder builder = CommonModelProto.GetFindWorkerResponseInfo.newBuilder();
					builder.setCode(jundalPartOutHangmog.getCode());
					builder.setName(jundalPartOutHangmog.getCodeName());
					result.addInfo1(builder);
				}
			}
			break;
		case "gwa":
			listResult=bas0260Repository.getComboListFromVwBasGwa(hospitalCode, language, info.getArgu1());
			if(!CollectionUtils.isEmpty(listResult)){
				for(ComboListItemInfo ordDanuiName:listResult){
					CommonModelProto.GetFindWorkerResponseInfo.Builder builder = CommonModelProto.GetFindWorkerResponseInfo.newBuilder();
					builder.setCode(ordDanuiName.getCode());
					builder.setName(ordDanuiName.getCodeName());
					result.addInfo1(builder);
				}
			}
			break;
		case "jusa":
			Ocs0132Repository ocs0132Repository = getRepository(Ocs0132Repository.class);
			listResult = ocs0132Repository.getComboListJusa(hospitalCode, info.getArgu1());
			if(!CollectionUtils.isEmpty(listResult)){
				for(ComboListItemInfo ordDanuiName:listResult){
					CommonModelProto.GetFindWorkerResponseInfo.Builder builder = CommonModelProto.GetFindWorkerResponseInfo
							.newBuilder().setCode(ordDanuiName.getCode())
							.setName(ordDanuiName.getCodeName());
					
					result.addInfo1(builder);
				}
			}
			
			break;
		case "ho_team":
			Nur0104Repository nur0104Repository = getRepository(Nur0104Repository.class);
			listResult = nur0104Repository.getComboListHoTeam(hospitalCode, info.getArgu1());
			if(!CollectionUtils.isEmpty(listResult)){
				for(ComboListItemInfo ordDanuiName:listResult){
					CommonModelProto.GetFindWorkerResponseInfo.Builder builder = CommonModelProto.GetFindWorkerResponseInfo
							.newBuilder().setCode(ordDanuiName.getCode())
							.setName(ordDanuiName.getCodeName());
					
					result.addInfo1(builder);
				}
			}
			
			break;
		case "bogyong_code_return":
			Drg0120Repository drg0120Repository = getRepository(Drg0120Repository.class);
			List<Drg0120> lstDrg = drg0120Repository.findByHospCodeLanguage(hospitalCode, language);
			if(!CollectionUtils.isEmpty(lstDrg)){
				for (Drg0120 drg0120 : lstDrg) {
					CommonModelProto.GetFindWorkerResponseInfo.Builder builder = CommonModelProto.GetFindWorkerResponseInfo
							.newBuilder()
							.setCode(drg0120.getBogyongCode() == null ? "" : drg0120.getBogyongCode())
							.setName(drg0120.getBogyongName() == null ? "" : drg0120.getBogyongName())
							.setValue1(drg0120.getBogyongGubun() == null ? "" : drg0120.getBogyongGubun());
					result.addInfo1(builder);
				}
			}
			
			break;
		default:
			break;
		}
		return result;
	}
	
	public static String getLoadColumnCodeName(String hospitalCode, String language, CommonModelProto.LoadColumnCodeNameInfo info){
		String codeName = "";
		List<String> listCodeName = new ArrayList<String>();
		Ocs0132Repository ocs0132Repository = getRepository(Ocs0132Repository.class);
		Bas0260Repository bas0260Repository = getRepository(Bas0260Repository.class);
		Ocs0115Repository ocs0115Repository = getRepository(Ocs0115Repository.class);
		Ocs0108Repository ocs0108Repository = getRepository(Ocs0108Repository.class); 
		switch(info.getColName()){
		case "code":
			codeName = ocs0132Repository.getLoadColumnCodeNameInfoCaseCode(hospitalCode, language,info.getArg1(),info.getArg2());
			break;
		case "order_gubun_bas":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "ORDER_GUBUN_BAS", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "jundal_part_inp":
			codeName = bas0260Repository.getOCS0103U12GwaName(hospitalCode, language,info.getArg1(), info.getArg2());
			break;
		case "jundal_part_out":
			codeName = bas0260Repository.getOCS0103U12GwaName(hospitalCode, language,info.getArg1(), info.getArg1());
			break;
		case "gwa":
			codeName= bas0260Repository.loadGwaNameFromVwBasGwa(hospitalCode, language, info.getArg1(), info.getArg2(), "1");
			break;
		case "code_type":
			Ocs0131Repository ocs0131Repository = getRepository(Ocs0131Repository.class);
			codeName = ocs0131Repository.getLoadColumnCodeNameInfoCaseCodeType(info.getArg1(), language);
			break;
		case "gwa_doctor":
			Bas0270Repository bas0270Repository = getRepository(Bas0270Repository.class);
			codeName = bas0270Repository.getLoadColumnCodeNameInfoCaseGwaDoctor(hospitalCode, info.getArg1(), info.getArg2(), info.getArg3());
			break;
		case "ho_team":
			Nur0104Repository nur0104Repository = getRepository(Nur0104Repository.class);
			codeName = nur0104Repository.getLoadColumnCodeNameInfoCaseHoTeam(hospitalCode, info.getArg1(), info.getArg2());
			break;
		case "toiwon_drg_yn":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "TOIWON_DRG_YN", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "portable_yn":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "PORTABLE_YN", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "hangmog_code":
			Ocs0103Repository ocs0103Repository = getRepository(Ocs0103Repository.class);
			codeName = ocs0103Repository.getLoadColumnCodeNameInfoCaseHangmogCode(hospitalCode, info.getArg1(), info.getArg2());
			break;
		case "ho_dong":
			codeName = bas0260Repository.loadGwaNameFromVwBasGwa(hospitalCode, language, info.getArg1(), info.getArg2(), "2");
			break;
		case "ocs_gwa":
			codeName = bas0260Repository.loadColumnCodeNameInfoCaseOcsGwa(info.getArg1());
			break;
		case "input_part":
			codeName = bas0260Repository.loadColumnCodeNameInfoCaseOcsInputPart(info.getArg1());
			break;
		case "specimen_code":
			Ocs0116Repository ocs0116Repository = getRepository(Ocs0116Repository.class);
			codeName = ocs0116Repository.getOCS0116GetCodeNameByCode(info.getArg1(),hospitalCode);
			break;
		case "specimen_code_hangmog":
			Adm0100Repository adm0100Repository = getRepository(Adm0100Repository.class);
			codeName = adm0100Repository.getLoadColumnCodeNameJundalTableCase(info.getArg1());
			break;
		case "jundal_part_out_hangmog":
			codeName = ocs0115Repository.getLoadColumnCodeNameJundalPartOutHangmogCase(info.getArg1(), info.getArg2(), info.getArg3(), hospitalCode, language);
			break;
		case "jundal_part_inp_hangmog":
			codeName = ocs0115Repository.getLoadColumnCodeNameJundalPartInpHangmogCase(info.getArg1(), info.getArg2(), info.getArg3(), hospitalCode, language);
			break;
		case "move_part":
			codeName = bas0260Repository.getLoadColunmCodeNameMovePartCase(hospitalCode,language,info.getArg1(), info.getArg2());
			break;
		case "gongbi_code":
			Bas0212Repository bas0212Repository = getRepository(Bas0212Repository.class);
			codeName = bas0212Repository.callFnBasLoadGongbiName(info.getArg1(), new Date(), language);
			break;
		case "buwi":
			codeName = ocs0132Repository.callFnOcsBogyongColName(info.getArg2(), info.getArg1(), info.getArg3(), hospitalCode, language);
			break;
		case "bogyong_code":
			Drg0120Repository drg0120Repository = getRepository(Drg0120Repository.class);
			codeName = drg0120Repository.getLoadColumnCodeNameBogyongCodeCase(info.getArg1(), hospitalCode, language);
			break;
		case "specific_comment":
			Ocs0170Repository ocs0170Repository = getRepository(Ocs0170Repository.class);
			codeName = ocs0170Repository.getLoadColumnCodeNameSpecificCommentCase(info.getArg1(), hospitalCode);
			break;
		case "dv_time":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "DV_TIME", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "jusa":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "JUSA", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "jusa_spd_gubun":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "JUSA_SPD_GUBUN", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "pay":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "PAY", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "slip_code":
			Ocs0102Repository ocs0102Repository = getRepository(Ocs0102Repository.class);
			codeName = ocs0102Repository.getLoadColumnCodeNameSlipCodeCase(info.getArg1(), hospitalCode, language);
			break;
		case "cardex_gubun":
			listCodeName = ocs0132Repository.getCodeNameByCodeAndCodeType(hospitalCode, language, "CARDEX_GUBUN", info.getArg1());
			if(!CollectionUtils.isEmpty(listCodeName)){
				codeName = listCodeName.get(0);
			}
			break;
		case "xray_buwi":
			Xrt0102Repository xrt0102Repository = getRepository(Xrt0102Repository.class);
			codeName = xrt0102Repository.getXRT0001U00FbxDataValidatingSelectXRT0102(hospitalCode,language, "X2", info.getArg1());
			break;
		case "sg_code":
			Bas0310Repository bas0310Repository = getRepository(Bas0310Repository.class);
			codeName = bas0310Repository.getLoadColumnCodeNameSgCodeCase(info.getArg1(), info.getArg2(), info.getArg1());
			break;
		case "jaeryo_code":
			Inv0110Repository inv0110Repository = getRepository(Inv0110Repository.class);
			codeName = inv0110Repository.getLoadColumnCodeNameJaeryoCodeCase(info.getArg1(), hospitalCode);
			break;
		case "ord_danui":
			codeName = ocs0108Repository.getLoadColumnCodeNameOrdDanuiCase(info.getArg2(), info.getArg1(), hospitalCode);
			break;
		case "ord_danui_name":
			codeName = ocs0108Repository.getLoadColumnCodeNameOrdDanuiNameCase(info.getArg2(), info.getArg1(), hospitalCode,language);
			break;
		case "sang_gubun":
			Ocs0204Repository ocs0204Repository = getRepository(Ocs0204Repository.class);
			codeName = ocs0204Repository.getLoadColumnCodeNameSangGubunCase(info.getArg2(), info.getArg1(), hospitalCode, language);
			break;
		case "sang_code":
			Cht0110Repository cht0110Repository = getRepository(Cht0110Repository.class);
			codeName = cht0110Repository.getLoadColumnCodeNameSangCodeCase(info.getArg2(), info.getArg1(), hospitalCode);
			break;
		case "sang_end_sayu":
			Bas0102Repository bas0102Repository = getRepository(Bas0102Repository.class);
			codeName = bas0102Repository.callFnBasLoadCodeName("SANG_END_SAYU", info.getArg1(), hospitalCode, language);
			break;
		case "user_id":
			Adm3211Repository adm3211Repository = getRepository(Adm3211Repository.class);
			codeName = adm3211Repository.getLoadColumnCodeNameUserId(hospitalCode, info.getArg1());
			break;
		case "gwa_all":
			codeName = bas0260Repository.getLoadColumnGwaAll(hospitalCode, info.getArg2(), info.getArg1());
			break;
		default:
			break;
		}
		return codeName;
	}
	
	public static List<ComboListItemInfo> getLoadComboDataSource(String hospitalCode, String language, CommonModelProto.ComboDataSourceInfo info){
		List<ComboListItemInfo> listInfo = null;
		
		Bas0270Repository bas0270Repository = getRepository(Bas0270Repository.class);
		Ocs0132Repository ocs0132Repository = getRepository(Ocs0132Repository.class);
		Bas0260Repository bas0260Repository = getRepository(Bas0260Repository.class);
		switch(info.getColName()){
		case "doctor":
			listInfo = bas0270Repository.getOcsOrderBizLoadComboDataSourceListItem(hospitalCode, info.getArg2(), info.getArg1());
			break;
		case "suryang":
			listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode, "%", "SURYANG", language);
			break;
		case "nalsu":
			listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode, "%", "NALSU", language);
			break;
		case "dv":
		case "dv_1":
		case "dv_2":
		case "dv_3":
		case "dv_4":
		case "dv_5":
		case "dv_6":
		case "dv_7":
		case "dv_8":
			listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode, "%", "DV", language);
			break;
		case "dv_time":
			listInfo =ocs0132Repository.getComboDataSourceInfoCaseDvTime(hospitalCode, language);
			break;
		case "pay":
			listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode, "%", "PAY", language);
			break;
		case "portable_yn":
			listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode, "%", "PORTABLE_YN", language);
			break;
		case "jusa_spd_gubun":
			listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode, "%", "PORTABLE_YN", language);
			break;
		case "code":
			listInfo = ocs0132Repository.getOcsoOCS1003P01GetGubunInfo(hospitalCode,  "%",info.getArg1(), language);
			break;
		case "order_gubun_bas":
			listInfo = ocs0132Repository.getComboDataSourceInfoCaseOrderGubunBas(hospitalCode, language);
			break;
		case "ho_dong":
			listInfo = ocs0132Repository.getgetComboDataSourceInfoCaseOrderCaseHodong(hospitalCode, info.getArg1(), language);
			break;
		case "doctor_all":
			listInfo = new ArrayList<>();
			listInfo.add(new ComboListItemInfo("%", "全体"));
			listInfo.addAll(bas0270Repository.getOcsOrderBizLoadComboDataSourceListItem(hospitalCode, info.getArg2() == null ? "" : info.getArg2(), info.getArg1()));
			break;
		case "gwa":
			listInfo = bas0260Repository.getComboListFromVwBasGwa(hospitalCode, language, info.getArg1());
			break;
		default:
			break;
		}
		return listInfo;
	}
	
	public static List<ComBizGetFindWorkerInfo> getBassComBiz(String hospCode, String colName, String arg1, String find, String language){
		List<ComBizGetFindWorkerInfo> listInfo = new ArrayList<ComBizGetFindWorkerInfo>();
		List<ComboListItemInfo> listCombo = new ArrayList<ComboListItemInfo>();
		
		Ifs0001Repository ifs0001Reposistory = getRepository(Ifs0001Repository.class);
		Ifs0002Repository ifs0002Reposistory = getRepository(Ifs0002Repository.class);
		Bas0230Repository bas0230Repository = getRepository(Bas0230Repository.class);
		Bas0310Repository bas0310Repository = getRepository(Bas0310Repository.class);
		Bas0260Repository bas0260Repository = getRepository(Bas0260Repository.class);
		Ocs0103Repository ocs0103Repository = getRepository(Ocs0103Repository.class);
		Ocs0102Repository ocs0102Repository = getRepository(Ocs0102Repository.class);
		switch (colName) {
		case "code_type":
			listInfo = ifs0002Reposistory.getComBizGetFindWorkerInfoCaseCodeType(hospCode, find);
			break;
		case "code":
			listCombo = ifs0002Reposistory.getIfs003U03FwkCommonListItem(hospCode, arg1, find, true, null, null);
			listInfo = getBassComBizCommonListItem(listCombo);
			break;
		case "nu_gubun":
			listCombo = ifs0002Reposistory.getIfs003U03FwkCommonListItem(hospCode, "IF_SKR_JINRYO_GUBUN", find, true, null, null);
			listInfo = getBassComBizCommonListItem(listCombo);
			break;
		case "bun_code":
			listCombo = bas0230Repository.getBunCodeBunNameListItemInfo(hospCode, language, find, arg1, true, false);
			listInfo = getBassComBizCommonListItem(listCombo);
			break;
		case "sg_code":
			listInfo = bas0310Repository.getComBizGetFindWorkerInfoCaseSgCode(hospCode, arg1, find);
			break;
		case "codeOLD":
			listInfo = ifs0002Reposistory.getComBizGetFindWorkerInfoCaseCodeOLD(hospCode, arg1, find);
			break;
		case "code_typeOLD":
			List<IFS0001U00GrdMasterInfo> listMaster = ifs0001Reposistory.getIFS0001U00GrdMasterInfo(hospCode, "%","%");
			if(!CollectionUtils.isEmpty(listMaster)){
				for(IFS0001U00GrdMasterInfo item : listMaster){
					ComBizGetFindWorkerInfo info = new ComBizGetFindWorkerInfo(item.getCodeType(), item.getCodeTypeName(), "");
					listInfo.add(info);
				}
			}
			break;
		case "gwa":
			listCombo = bas0260Repository.getComboListFromVwBasGwa(hospCode, language, arg1);
			listInfo = getBassComBizCommonListItem(listCombo);
			break;
		case "hangmog_code":
			listInfo = ocs0103Repository.getComBizGetFindWorkerCaseHangmogCode(hospCode, find, arg1);
			break;
		case "slip_code":
			listCombo = ocs0102Repository.getOCS0103U00ComboListItemInfo(hospCode, arg1, true, language); // re-check
			listInfo = getBassComBizCommonListItem(listCombo);
			break;
			
		default:
			break;
		}
		return listInfo;
		
	}

	private static List<ComBizGetFindWorkerInfo> getBassComBizCommonListItem(List<ComboListItemInfo> listCombo) {
		 List<ComBizGetFindWorkerInfo> listInfo = new ArrayList<ComBizGetFindWorkerInfo>();
		
		if(!CollectionUtils.isEmpty(listCombo)){
			for(ComboListItemInfo item : listCombo){
				ComBizGetFindWorkerInfo info = new ComBizGetFindWorkerInfo(item.getCode(), item.getCodeName(), "");
				listInfo.add(info);
			}
		}
		return listInfo;
	}
}
