package nta.med.data.dao.medi.adm;

import java.util.Date;
import java.util.List;

import nta.med.data.model.ihis.adma.ADM104UGridUserInfo;
import nta.med.data.model.ihis.adma.ADM3200R00grdADM3200Info;
import nta.med.data.model.ihis.adma.Adm107UFwkUserIdInfo;
import nta.med.data.model.ihis.adma.CheckAdminUserInfo;
import nta.med.data.model.ihis.adma.UserLoginFormListItemInfo;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.emr.EmailToInfo;
import nta.med.data.model.ihis.emr.OCS2015U31GetADM3200UserInfo;
import nta.med.data.model.ihis.ocsa.OcsaOCS0204U00MembListInfo;
import nta.med.data.model.ihis.system.AccountInfo;
import nta.med.data.model.ihis.system.AdmLoginFormCheckLoginUserInfo;
import nta.med.data.model.ihis.system.FwUserInfoChangePswInfo;
import nta.med.data.model.ihis.system.PrAdmMessageCallOutputInfo;
import nta.med.data.model.ihis.system.UserInfoCheckUserSubDoctorInfo;

/**
 * @author dainguyen.
 */
public interface Adm3200RepositoryCustom {
	
	public List<String> getUserNameByUserId(String hospitalCode, String userId);
	
	public List<OcsaOCS0204U00MembListInfo> getOcsaOCS0204U00MembListOcsaOCS0204U00FindWorkerList(String hospCode, String language, String find1, boolean isAll);
	public List<ComboListItemInfo> getCbxActorKist(String hospCode);
	
	public List<ComboListItemInfo> getFwkActorListItem(String hospCode, String userGroup,boolean order); 
	
	public String getCPL3020U00UserNmVsvJubsuja(String hospCode, String code);
	
	public String getCPL3020U00LayCommon(String hospCode, String userGroup, String userId);
	
	public String getSCH3001U00VsvUserName(String hospCode, String code);
	
	public UserInfoCheckUserSubDoctorInfo callProcAdmCheckLogin(String hospCode, String language, String sysId, String userId, String userScrt, String scrtCheckYn);
	
	public PrAdmMessageCallOutputInfo callPrAdmMessageCall(String hospCode, String language, String userId, String userTrm,
			String senderId, String msgTitle, String msgContents, String sendAllCnfmYn, String receiveGubun, String receiverId);
	
	public String getEnablePostApprove(String hospCode, String doctor);
	public List<ComboListItemInfo> getOFMakeUserCombo(String hospCode,String find,boolean isDoctorMode);
	public List<ComboListItemInfo> getDRG0201U00CbxActor(String hospCode, String userGroup, boolean userEndYmd);
	public List<ADM104UGridUserInfo> getADM104UGridUserInfo(String hospCode, String language, String userGroup, String searchWord, String userGubun);
	public String callPrAdmInsertSubpartDoctor(String hospitalCode, String userId, String iud);
	public List<Adm107UFwkUserIdInfo> getAdm107uFwkUserID(String hospCode, String language);
	public List<String> getAdm107uUserNm(String hospCode, String userId, String language);
	public List<ComboListItemInfo> getUserIdUserNameInfo (String userGroup, String userGubun, String hospCode, boolean userEndYmd, String date);
	
	public List<ComboListItemInfo> getOcsactCboSystemSelectedIndexPfesCaseListItem(String hospCode, String userGroup, String codeType, String language);
	
	public List<ComboListItemInfo> getOcsactCboSystemSelectedIndexOprsCaseListItem(String hospCode, String userGroup, String userGubun, String deptCode, boolean order);
	
	public List<ComboListItemInfo> getOcsactCboSystemSelectedIndexNuriCaseListItem(String hospCode, String userGroup, String userGubun, String hoDong, String language);
	
	public List<CheckAdminUserInfo> getCheckAdminUserInfo(String userId);
	public List<EmailToInfo> getEmailToInfoList (String emrRecordId) ;
	public ComboListItemInfo getDoctorCodeName (String userId);
	public UserLoginFormListItemInfo getUserLoginFormListItemInfo (String userId, String pwd);
	public AdmLoginFormCheckLoginUserInfo getAdmLoginFormCheckLoginUserInfo(String userId, String password, String hospCode);
	public  List<FwUserInfoChangePswInfo> getFwUserInfoChangePswInfo(String hospCode, String userId);

	public AdmLoginFormCheckLoginUserInfo getAdmLoginFormCheckLoginUserInfoByUserId(String userId);
	
	public List<OCS2015U31GetADM3200UserInfo> getAdminListOCS2015U31GetADM3200UserInfo(String hospCode);
	
	public List<OCS2015U31GetADM3200UserInfo> getNursOrDoctorListOCS2015U31GetADM3200UserInfo(String hospCode, String userId);

	public boolean isExistedAdma(String hospCode, String userId);
	public List<ComboListItemInfo> getOCSACT2GetComboUser(String hospCode, String userGroup, boolean order);
	
	public List<ComboListItemInfo> getExeDoctorListItemInfo(String hospCode, String gwa);
	
	public AccountInfo verifyAccountInfo(String userId, String password, String hospCode);
	public List<ADM3200R00grdADM3200Info> getADM3200R00grdADM3200Info(String hospCode, String userGroup, String hoDong, Integer startNum, Integer offset);
	public List<ComboListItemInfo> callFnPpeLoadConfirmEnable(String hospCode, String uerId);
	public String getOCS2003U99DeptCodeRequest(String hospCode, String userId);
	
	public String getUserNmByUserId(String hospCode, String userId);

	public String getOCS6010U10frmARActingUserNm(String hospCode, String userId);
	
	public List<String> getNurUserId(String hospCode, String coId);

	public List<ComboListItemInfo> getDRG3010P99cbxActor(String hospCode, String userGroup);
	
	public List<ComboListItemInfo> getCbxActorByUserGroup(String hospCode, String userGroup);

	public List<ComboListItemInfo> getNUR6011U01UserNmByBuseoName(String hospCode, String buseoName);
	
	public List<ComboListItemInfo> getCbxNUR1020U00fwkWriter(String hospCode, String buseoName, Date nurWrdt);
	
	public List<ComboListItemInfo> getCbxNUR1020U00layNURList(String hospCode, String buseoName);

	public String checkNUR1010Q00CheckNurseID(String hospCode, String userId);

	public List<ComboListItemInfo> getNUR1010U00fwkNurse(String hospCode, String buseoCode, String sabun);

	public String getNUR1010U00DamdangNurse(String hospCode, String code);

	public List<ComboListItemInfo> getNUR9001U00fwkFind(String hospCode, String find1, String sabun);
	
	public List<ComboListItemInfo> getNUR5020U00fwkNurse(String hospCode, String buseoCode, String sabun);
} 

