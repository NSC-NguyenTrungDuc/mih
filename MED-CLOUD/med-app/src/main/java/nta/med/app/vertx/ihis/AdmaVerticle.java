package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.adma.*;
import nta.med.service.ihis.proto.AdmaServiceProto;

public class AdmaVerticle extends AbstractVerticle {

	public AdmaVerticle() {
		super(AdmaServiceProto.class, AdmaServiceProto.getDescriptor());
	}
	
	@Override
    public void doStart() throws Exception{
		registerHandler(AdmaServiceProto.CheckAdminUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckAdminUserHandler.class));
		
		//[START] ADM103U
		registerHandler(AdmaServiceProto.ADM103UgrdUserGrpRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM103UgrdUserGrpHandler.class));
		registerHandler(AdmaServiceProto.ADM103LaySysListGrpRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM103LaySysListGrpHandler.class));
		registerHandler(AdmaServiceProto.ADM103RegSystemFormSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM103RegSystemFormSaveLayoutHandler.class));
		registerHandler(AdmaServiceProto.ADM103SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM103SaveLayoutHandler.class));
		registerHandler(AdmaServiceProto.ADM103LayLoginSysListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM103LayLoginSysListHandler.class));
		//Added
		registerHandler(AdmaServiceProto.ADM103UGetFwkHospitalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM103UGetFwkHospitalHandler.class));
		registerHandler(AdmaServiceProto.ADM103UValidateFwkHospitalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM103UValidateFwkHospitalHandler.class));
		//[END] ADM103U
		
		//[START] ADM104U
		registerHandler(AdmaServiceProto.ADM104UFwkBuseoCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM104UFwkBuseoCodeHandler.class));
		registerHandler(AdmaServiceProto.ADM104UGridUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM104UGridUserHandler.class));
		registerHandler(AdmaServiceProto.ADM104UFindBoxRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM104UFindBoxHandler.class));
		registerHandler(AdmaServiceProto.ADM104UGridUserSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM104UGridUserSaveLayoutHandler.class));
		registerHandler(AdmaServiceProto.ADM104UClisComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM104UClisComboHandler.class));
		//[END] ADM104U
		
		//[START] ADM101U
		registerHandler(AdmaServiceProto.ADM101UGetGrpNmRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM101UGetGrpNmHandler.class));
		registerHandler(AdmaServiceProto.ADM101UGrdGroupRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM101UGrdGroupHandler.class));
		registerHandler(AdmaServiceProto.ADM101UGrdSystemRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM101UGrdSystemHandler.class));
		registerHandler(AdmaServiceProto.ADM101USaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM101USaveLayoutHandler.class));
		//[END] ADM101U
		
		//[START] ADM107U
		registerHandler(AdmaServiceProto.Adm107ULayDownListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adm107ULayDownListHandler.class));
		registerHandler(AdmaServiceProto.Adm107ULayRootListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adm107ULayRootListHandler.class));
		registerHandler(AdmaServiceProto.Adm107UFbxSysIDDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adm107UFbxSysIDDataValidatingHandler.class));
		registerHandler(AdmaServiceProto.Adm107UFbxIDDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adm107UFbxIDDataValidatingHandler.class));
		registerHandler(AdmaServiceProto.Adm107USaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adm107USaveLayoutHandler.class));
		//new 
		registerHandler(AdmaServiceProto.Adm107UFwkUserIdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adm107UFwkUserIdHandler.class));
		registerHandler(AdmaServiceProto.ADM107UFwkSysIdRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM107UFwkSysIdHandler.class));
		registerHandler(AdmaServiceProto.Adm107UFbxHospCodeDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adm107UFbxHospCodeDataValidatingHandler.class));
		//[END] ADM107U
		
		// [START] ADM106U
		registerHandler(AdmaServiceProto.ADM106UFwkPgmIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM106UFwkPgmIDHandler.class));
		registerHandler(AdmaServiceProto.ADM106UMakeQueryListItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM106UMakeQueryListItemHandler.class));
		registerHandler(AdmaServiceProto.ADM106UGetPgmNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM106UGetPgmNameHandler.class));
		registerHandler(AdmaServiceProto.ADM106UGetSysNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM106UGetSysNameHandler.class));
		registerHandler(AdmaServiceProto.ADM106USaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM106USaveLayoutHandler.class));
		// [END] ADM106U
		
		// [START] ADM108U
		registerHandler(AdmaServiceProto.ADM108UGrdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM108UGrdListHandler.class));
		registerHandler(AdmaServiceProto.ADM108UFwkPgmIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM108UFwkPgmIDHandler.class));
		registerHandler(AdmaServiceProto.ADM108ULaySysListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM108ULaySysListHandler.class));
		registerHandler(AdmaServiceProto.ADM108UTvwSystemListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM108UTvwSystemListHandler.class));
		registerHandler(AdmaServiceProto.ADM108USaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM108USaveLayoutHandler.class));
		//[END] ADM108U
		
		// [START] ADM102U
		registerHandler(AdmaServiceProto.ADM102UGrdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM102UGrdListHandler.class));
		registerHandler(AdmaServiceProto.ADM102UGetSysNmRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM102UGetSysNmHandler.class));
		registerHandler(AdmaServiceProto.ADM102USaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM102USaveLayoutHandler.class));
		// [END] ADM102U
		
		//[START] ADM501U
		registerHandler(AdmaServiceProto.ADM501UKoreaListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM501UKoreaListHandler.class));
		registerHandler(AdmaServiceProto.ADM501UJapanListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM501UJapanListHandler.class));
		registerHandler(AdmaServiceProto.ADM501USpeakListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM501USpeakListHandler.class));
		registerHandler(AdmaServiceProto.ADM501UJapanEmptyListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM501UJapanEmptyListHandler.class));
		registerHandler(AdmaServiceProto.ADM501USaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM501USaveLayoutHandler.class));
 		//[END] ADM501U
		
		//[START] ADM201U
		registerHandler(AdmaServiceProto.ADM201UGrdDicDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM201UGrdDicDetailHandler.class));
		registerHandler(AdmaServiceProto.ADM201UGrdDicMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM201UGrdDicMasterHandler.class));
		registerHandler(AdmaServiceProto.ADM201USaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM201USaveLayoutHandler.class));
		//[END] ADM201U
		
		//[START] ADM401U
		registerHandler(AdmaServiceProto.ADM401UGrdSysRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM401UGrdSysHandler.class));
		registerHandler(AdmaServiceProto.ADM401UGrdGrpRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM401UGrdGrpHandler.class));
		registerHandler(AdmaServiceProto.ADM401UAsmRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM401UAsmHandler.class));
		registerHandler(AdmaServiceProto.ADM401UUpdateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM401UUpdateHandler.class));
		registerHandler(AdmaServiceProto.ADM401UInsertRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM401UInsertHandler.class));
		//[END] ADM401U
		
		//[START] ADMS2015U01
		registerHandler(AdmaServiceProto.ADMS2015U01GetSystemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U01GetSystemHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U01SystemIdValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U01SystemIdValidatingHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U01LoadUpperMenuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U01LoadUpperMenuHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U01LoadMenuItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U01LoadMenuItemHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U01SettingMenuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U01SettingMenuHandler.class));
		//[END] ADMS2015U01
		
		//[START] StartForm
		registerHandler(AdmaServiceProto.ADMSStartFormLoginRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMSStartFormLoginHandler.class));
		//[END] StartForm
		
		//[START] ADMS2015U00
		registerHandler(AdmaServiceProto.ADMS2015U00GetGroupListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U00GetGroupListHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U00GetSystemListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U00GetSystemListHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U00LoadGroupSystemHospitalHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U00GetSystemHospitalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U00GetSystemHospitalHandler.class));
		registerHandler(AdmaServiceProto.ADMS2015U00CreateGroupHospitalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADMS2015U00CreateGroupHospitalHandler.class));
		//[END] ADMS2015U00
		
		//[START] ADM2016U00
		registerHandler(AdmaServiceProto.ADM2016U00GrdLoadDrgRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM2016U00GrdLoadDrgHandler.class));
		registerHandler(AdmaServiceProto.HOTCODEMASTERSaveRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(HOTCODEMASTERSaveHandler.class));
		registerHandler(AdmaServiceProto.ADM2016U00NameTypeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM2016U00NameTypeHandler.class));
		registerHandler(AdmaServiceProto.Adms2016U00GetMaintainanceSettingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adms2016U00GetMaintainanceSettingHandler.class));
		registerHandler(AdmaServiceProto.Adms2016U00SaveMaintainanceSettingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Adms2016U00SaveMaintainanceSettingHandler.class));
		//[END] ADM2016U00
		
		//[START]
		registerHandler(AdmaServiceProto.ADM104QGetPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM104QGetPatientHandler.class));
		//[END]
		
		//[START]
		registerHandler(AdmaServiceProto.ADM3200R00grdADM3200Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ADM3200R00grdADM3200Handler.class));
		//[END]
	}

	@Override
	protected void doStop() throws Exception {
		
	}
}
	