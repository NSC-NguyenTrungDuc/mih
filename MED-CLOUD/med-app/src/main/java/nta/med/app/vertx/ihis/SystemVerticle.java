package nta.med.app.vertx.ihis;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.vertx.java.core.Handler;
import org.vertx.java.core.eventbus.Message;

import com.google.protobuf.InvalidProtocolBufferException;

import nta.med.core.glossary.AdministrationNotice;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.socket.vertx.VertxContext;
import nta.med.service.emr.handler.PatientInfoLoadPatientNaewonListHandler;
import nta.med.service.ihis.handler.adma.AdmLoginFormLockUserHandler;
import nta.med.service.ihis.handler.kinki.SyncKinkiCacheHandler;
import nta.med.service.ihis.handler.system.*;
import nta.med.service.ihis.handler.system.composite.LoadHangmogInfoCompositeFirstHandler;
import nta.med.service.ihis.handler.system.composite.LoadHangmogInfoCompositeSecondHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
public class SystemVerticle extends AbstractVerticle {

    private static final Log LOGGER = LogFactory.getLog(SystemVerticle.class);
	
    public SystemVerticle() {
        super(SystemServiceProto.class, SystemServiceProto.getDescriptor());
    }

    @Override
    protected void doStart() throws Exception {
        registerHandler(SystemServiceProto.MainMenuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(MainMenuHandler.class));
        registerHandler(SystemServiceProto.GetPatientByCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetPatientByCodeHandler.class));
        registerHandler(SystemServiceProto.GetPatientInsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetPatientInsHandler.class));
        //[START] 
        registerHandler(SystemServiceProto.FindPatientFromRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FindPatientHandler.class));
        registerHandler(SystemServiceProto.BasManageZipCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BasManageZipCodeHandler.class));
        registerHandler(SystemServiceProto.XPaInfoBoxRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XPaInfoBoxHandler.class));
        
        registerHandler(SystemServiceProto.DetailPaInfoFormGridInsureRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DetailPaInfoFormGridInsureHandler.class));
        registerHandler(SystemServiceProto.DetailPaInfoFormGridVisitListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DetailPaInfoFormGridVisitListHandler.class));
        registerHandler(SystemServiceProto.DetailPaInfoFormGridCommentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DetailPaInfoFormGridCommentHandler.class));
        registerHandler(SystemServiceProto.BuseoListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BuseoListHandler.class));
        registerHandler(SystemServiceProto.UserNameListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(UserNameListHandler.class));
        registerHandler(SystemServiceProto.UserNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(UserNameHandler.class));
        
        registerHandler(SystemServiceProto.UserInfoCheckUserSubDoctorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(UserInfoCheckUserSubDoctorHandler.class));
        registerHandler(SystemServiceProto.UserInfoSetSystemUserToRegistryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(UserInfoSetSystemUserToRegistryHandler.class));
        registerHandler(SystemServiceProto.FormGwaListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FormGwaListHandler.class));
        registerHandler(SystemServiceProto.UserInfoCheckUserSubRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(UserInfoCheckUserSubHandler.class));
        registerHandler(SystemServiceProto.CheckUserDoctorLoginRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckUserDoctorLoginHandler.class));
        registerHandler(SystemServiceProto.CheckUserLoginRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckUserLoginHandler.class));
        registerHandler(SystemServiceProto.MdiFormSystemMenuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(MdiFormSystemMenuHandler.class));
        registerHandler(SystemServiceProto.MdiFormMainMenuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(MdiFormMainMenuHandler.class));
        registerHandler(SystemServiceProto.MdiFormOpenMainScreenRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MdiFormOpenMainScreenHandler.class));

        //[END]
        
        //[START] HangmogInfo
        registerHandler(SystemServiceProto.GetNextGroupSerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetNextGroupSerHandler.class));
        registerHandler(SystemServiceProto.PrOcsConvertHangmogCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PrOcsConvertHangmogCodeHandler.class));
        registerHandler(SystemServiceProto.PrOcsLoadHangmogInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PrOcsLoadHangmogInfoHandler.class));
		//[END] HangmogInfo
		
        //[START] OCS.Lib OrderBiz
        registerHandler(SystemServiceProto.OcsoGetNotApproveOrderCntRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoGetNotApproveOrderCntHandler.class));
        registerHandler(SystemServiceProto.IsOrderDataChangedEnabledRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(IsOrderDataChangedEnabledHandler.class));
        registerHandler(SystemServiceProto.GetJundaPartAndTableRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetJundaPartAndTableHandler.class));
        registerHandler(SystemServiceProto.SpeciFicCommentInputYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SpeciFicCommentInputYnHandler.class));
        registerHandler(SystemServiceProto.InsteadModifiedCheckRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(InsteadModifiedCheckHandler.class));
        registerHandler(SystemServiceProto.FnCplLoadDupGrdHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FnCplLoadDupGrdHangmogHandler.class));
        registerHandler(SystemServiceProto.GetDefaultOrdDanui1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetDefaultOrdDanui1Handler.class));
        registerHandler(SystemServiceProto.GetDefaultOrdDanui2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetDefaultOrdDanui2Handler.class));
        registerHandler(SystemServiceProto.PrOcsInterfaceInsertRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PrOcsInterfaceInsertHandler.class));
        registerHandler(SystemServiceProto.LoadColumnCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadColumnCodeNameHandler.class));
        registerHandler(SystemServiceProto.LoadSearchOrder1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadSearchOrder1Handler.class));
        registerHandler(SystemServiceProto.CFFormIlgwalChangeCboNalsuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CFFormIlgwalChangeCboNalsuHandler.class));
        registerHandler(SystemServiceProto.CFFormGetSelectHopeDateCboNalsuRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CFFormGetSelectHopeDateCboNalsuHandler.class));
        registerHandler(SystemServiceProto.CFFormUnevenPrescribeLayDRG0120Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CFFormUnevenPrescribeLayDRG0120Handler.class));


        //[START] OrderBiz
        registerHandler(SystemServiceProto.OcsoGetNaewonYNRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoGetNaewonYNHandler.class));
        registerHandler(SystemServiceProto.OcsoLoadCht0110Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoLoadCht0110Handler.class));
        registerHandler(SystemServiceProto.IsResultToConsultRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(IsResultToConsultHandler.class));
        registerHandler(SystemServiceProto.PrOcsLoadNaewonInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PrOcsLoadNaewonInfoHandler.class));
        registerHandler(SystemServiceProto.LoadPatientNaewonListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadPatientNaewonListHandler.class));
        registerHandler(SystemServiceProto.LoadSearchOrder2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadSearchOrder2Handler.class));
        registerHandler(SystemServiceProto.GetJundaTableRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetJundaTableHandler.class));
        registerHandler(SystemServiceProto.GetMainGwaDoctorCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetMainGwaDoctorCodeHandler.class));
        registerHandler(SystemServiceProto.SaveOfenUsedHangmogRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SaveOfenUsedHangmogHandler.class));
        registerHandler(SystemServiceProto.IsToiwonGojiYNandEndOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(IsToiwonGojiYNandEndOrderHandler.class));
        registerHandler(SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(HIOcsCheckJundalPartLoadJaeryoJundalHandler.class));
        registerHandler(SystemServiceProto.CheckPatientStatusRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckPatientStatusHandler.class));
        registerHandler(SystemServiceProto.DupCheckCPLOrder1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DupCheckCPLOrder1Handler.class));
        registerHandler(SystemServiceProto.DupCheckInputInpOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DupCheckInputInpOrderHandler.class));
        registerHandler(SystemServiceProto.OCS0103U12GrdGeneralRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12GrdGeneralHandler.class));
        registerHandler(SystemServiceProto.OCS0103U12SetTabWonnaeDrugRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U12SetTabWonnaeDrugHandler.class));
        registerHandler(SystemServiceProto.GetJundaTable1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetJundaTable1Handler.class));
        registerHandler(SystemServiceProto.GetBogyongInfo3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetBogyongInfo3Handler.class));
        registerHandler(SystemServiceProto.GetApproveFlagsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetApproveFlagsHandler.class));
        // [END] OCS.Lib OrderBiz
        
        registerHandler(SystemServiceProto.OcsoProcHQNInterfaceRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsoProcHQNInterfaceHandler.class));
        registerHandler(SystemServiceProto.GetFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetFindWorkerHandler.class));
        registerHandler(SystemServiceProto.ExistAllergyDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ExistAllergyDataHandler.class));
        registerHandler(SystemServiceProto.GetOutJinryoCommentCntRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetOutJinryoCommentCntHandler.class));
        registerHandler(SystemServiceProto.OpenAllergyInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OpenAllergyInfoHandler.class));
        registerHandler(SystemServiceProto.NoConfirmConsultRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NoConfirmConsultHandler.class));
        registerHandler(SystemServiceProto.LoadPatientSpecificCommentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadPatientSpecificCommentHandler.class));
        registerHandler(SystemServiceProto.KensaReserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(KensaReserHandler.class));
        registerHandler(SystemServiceProto.GetOutTaGwaJinryoCntRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetOutTaGwaJinryoCntHandler.class));
        registerHandler(SystemServiceProto.IpwonReserStatusRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(IpwonReserStatusHandler.class));
        registerHandler(SystemServiceProto.AbleInsteadOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(AbleInsteadOrderHandler.class));
        registerHandler(SystemServiceProto.GetOrderCountRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetOrderCountHandler.class));
        registerHandler(SystemServiceProto.GetOrderKeyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetOrderKeyHandler.class));
        registerHandler(SystemServiceProto.DupCheckInputOutOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(DupCheckInputOutOrderHandler.class));
        registerHandler(SystemServiceProto.LoadComboDataSourceRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadComboDataSourceHandler.class));
        registerHandler(SystemServiceProto.AdmMessageCallRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(AdmMessageCallHandler.class));
        registerHandler(SystemServiceProto.UdpHelperSendMsgToID2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(UdpHelperSendMsgToID2Handler.class));
        registerHandler(SystemServiceProto.ComboDvTimeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboDvTimeHandler.class));
        registerHandler(SystemServiceProto.ComboSuryangRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboSuryangHandler.class));
        registerHandler(SystemServiceProto.ComboDvRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboDvHandler.class));
        registerHandler(SystemServiceProto.ComboNalsuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboNalsuHandler.class));
        registerHandler(SystemServiceProto.OcsOrderBizGetUserOptionRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OcsOrderBizGetUserOptionHandler.class));
        registerHandler(SystemServiceProto.LoadConsultEndYNRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadConsultEndYNHandler.class));
        registerHandler(SystemServiceProto.OBCheckRegularDrugRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBCheckRegularDrugHandler.class));
        registerHandler(SystemServiceProto.OBCheckSpecialDrugForPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBCheckSpecialDrugForPatientHandler.class));
        registerHandler(SystemServiceProto.OBGetBogyongByDvRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBGetBogyongByDvHandler.class));
        registerHandler(SystemServiceProto.OBLoadSearchOrderInfoDRGRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBLoadSearchOrderInfoDRGHandler.class));
        registerHandler(SystemServiceProto.OBGetBogyongInfo2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBGetBogyongInfo2Handler.class));
        registerHandler(SystemServiceProto.OBGetBogyongInfo1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBGetBogyongInfo1Handler.class));
        registerHandler(SystemServiceProto.OBGetJundaTable1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBGetJundaTable1Handler.class));
        registerHandler(SystemServiceProto.OBLoadSimsaCommentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBLoadSimsaCommentHandler.class));
        registerHandler(SystemServiceProto.LoadOftenUsedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadOftenUsedHandler.class));
        registerHandler(SystemServiceProto.IsJaewonPatientRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(IsJaewonPatientHandler.class));
        
        registerHandler(SystemServiceProto.LoadOcs0131Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadOcs0131Handler.class));
        registerHandler(SystemServiceProto.LoadOcs0132Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadOcs0132Handler.class));
        registerHandler(SystemServiceProto.GetEnablePostApproveRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetEnablePostApproveHandler.class));
        registerHandler(SystemServiceProto.OFGetCboOrderGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OFGetCboOrderGubunHandler.class));
        //[END] Orderbiz
        
        //[START] HangmogInfo
        registerHandler(SystemServiceProto.FnDrgGetCycleOrdDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FnDrgGetCycleOrdDateHandler.class));
        registerHandler(SystemServiceProto.GetMsgInsulinRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetMsgInsulinHandler.class));
        registerHandler(SystemServiceProto.HILoadCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(HILoadCodeNameHandler.class));

        registerHandler(SystemServiceProto.HIOcsBogyongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(HIOcsBogyongHandler.class));
        registerHandler(SystemServiceProto.HIOcsSpecificCommentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(HIOcsSpecificCommentHandler.class));
        registerHandler(SystemServiceProto.CheckHangSangInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckHangSangInfoHandler.class));
        registerHandler(SystemServiceProto.HIGetGenericNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(HIGetGenericNameHandler.class));
        registerHandler(SystemServiceProto.HIGetHangmogNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(HIGetHangmogNameHandler.class));

		//[END] HangmogInfo   FN_OCS_USER_OPTION_INFO
        
        //[START] PatientInfo
        registerHandler(SystemServiceProto.PrOcsLoadBunhoInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PrOcsLoadBunhoInfoHandler.class));
        registerHandler(SystemServiceProto.PrOcsLoadIpwonReserInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PrOcsLoadIpwonReserInfoHandler.class));
        registerHandler(SystemServiceProto.FnInpLoadJaewonIlsuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FnInpLoadJaewonIlsuHandler.class));
        registerHandler(SystemServiceProto.PrOcsLoadIpwonInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PrOcsLoadIpwonInfoHandler.class));
        //[END] PatientInfo
        
        registerHandler(SystemServiceProto.ComboGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboGwaHandler.class));
        registerHandler(SystemServiceProto.ComboGumsaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboGumsaHandler.class));
        
        //[START] IHIS Form
        registerHandler(SystemServiceProto.FormScreenListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FormScreenListHandler.class));
        registerHandler(SystemServiceProto.FormEnvironInfoMessageRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FormEnvironInfoMessageHandler.class));
        registerHandler(SystemServiceProto.FormEnvironInfoSysDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FormEnvironInfoSysDateHandler.class));
        registerHandler(SystemServiceProto.FormEnvironInfoSysDateTimeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FormEnvironInfoSysDateTimeHandler.class));
        registerHandler(SystemServiceProto.MenuViewFormRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(MenuViewFormHandler.class));
        registerHandler(SystemServiceProto.FormUserInfoUnRegisterSystemUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FormUserInfoUnRegisterSystemUserHandler.class));
        registerHandler(SystemServiceProto.LayConstantInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LayConstantInfoHandler.class));

        //[END] IHIS Form
        
        //OCSA
        registerHandler(SystemServiceProto.ComboSearchConditionRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboSearchConditionHandler.class));
        registerHandler(SystemServiceProto.ComboPortableYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboPortableYnHandler.class));
        registerHandler(SystemServiceProto.ComboPayRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboPayHandler.class));
        registerHandler(SystemServiceProto.ComboJusaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboJusaHandler.class));
        registerHandler(SystemServiceProto.ComboOrdDanuiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboOrdDanuiHandler.class));
        registerHandler(SystemServiceProto.ComboJusaSpdGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboJusaSpdGubunHandler.class));
        registerHandler(SystemServiceProto.ComboNaewonYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboNaewonYnHandler.class));
        registerHandler(SystemServiceProto.ComboJubsuGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboJubsuGubunHandler.class));
        
        //OCSA
        //[START]OrderFunc
        registerHandler(SystemServiceProto.OFMakeUserComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OFMakeUserComboHandler.class));
        registerHandler(SystemServiceProto.OFMakeGwaComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OFMakeGwaComboHandler.class));
        registerHandler(SystemServiceProto.OFUpdateDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OFUpdateDataHandler.class));
        registerHandler(SystemServiceProto.OFFormSetMakeFormLoadRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OFFormSetMakeFormLoadHandler.class));
        registerHandler(SystemServiceProto.ComboDoctorGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboDoctorGwaHandler.class));
        registerHandler(SystemServiceProto.OFMakeTreeViewRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OFMakeTreeViewHandler.class));
        
        //[END]OrderFunc
        //[START] CACHE
        registerHandler(SystemServiceProto.ComboSangEndSayuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboSangEndSayuHandler.class));
        registerHandler(SystemServiceProto.CbxXrayGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CbxXrayGubunHandler.class));
        registerHandler(SystemServiceProto.CboPartRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CboPartHandler.class));
        registerHandler(SystemServiceProto.CboBuwiBunryuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CboBuwiBunryuHandler.class));
        registerHandler(SystemServiceProto.ComboCplsUiTakRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboCplsUiTakHandler.class));
        registerHandler(SystemServiceProto.ComboPfesCboPartRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboPfesCboPartHandler.class));
        registerHandler(SystemServiceProto.OCS0132GetServerIpRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0132GetServerIpHandler.class));

        //[END] CACHE
        
        registerHandler(SystemServiceProto.XMstGridDeleteRowRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XMstGridDeleteRowHandler.class));
        registerHandler(SystemServiceProto.GetPatientInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetPatientInfoHandler.class));
        registerHandler(SystemServiceProto.ComboInputTabRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboInputTabHandler.class));
        registerHandler(SystemServiceProto.OBFnOcsIsGeneralYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OBFnOcsIsGeneralYnHandler.class));
        
        registerHandler(SystemServiceProto.ComboBarCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboBarCodeHandler.class));
        registerHandler(SystemServiceProto.ComboInOutGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboInOutGubunHandler.class));
        registerHandler(SystemServiceProto.ComboResultFormRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboResultFormHandler.class));
        registerHandler(SystemServiceProto.ComboSpcialNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboSpcialNameHandler.class));
        registerHandler(SystemServiceProto.ComboHoDongRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboHoDongHandler.class));
        registerHandler(SystemServiceProto.ComboADM1110GetByColNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboADM1110GetByColNameHandler.class));
        // [START] CPL2010U00
        registerHandler(SystemServiceProto.ComboADM3200FwkActorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboADM3200FwkActorHandler.class));
        registerHandler(SystemServiceProto.ComboNUR0102CboTimeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboNUR0102CboTimeHandler.class));
        registerHandler(SystemServiceProto.ComboADM3200CbxActorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboADM3200CbxActorHandler.class));
        // [END] CPL2010U00
        //[START]OCSACT
        registerHandler(SystemServiceProto.FwPaCommentGrdCmmtFwkRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FwPaCommentGrdCmmtFwkHandler.class));
        registerHandler(SystemServiceProto.FwBizObjectXPaCommentLayCmmtGubunfwkRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(FwBizObjectXPaCommentLayCmmtGubunfwkHandler.class));
        //[END]OCSACT
        registerHandler(SystemServiceProto.CboHospJinGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CboHospJinGubunHandler.class));
        registerHandler(SystemServiceProto.BASSFwkBuseoGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BASSFwkBuseoGubunHandler.class));
        registerHandler(SystemServiceProto.BASSCboInputGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BASSCboInputGubunHandler.class));
        
        // [START] CHT0115Q01
        registerHandler(SystemServiceProto.CHTSXEditSusikGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CHTSXEditSusikGubunHandler.class));
        registerHandler(SystemServiceProto.CHTSCboSusikGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CHTSCboSusikGubunHandler.class));
        // [END] CHT0115Q01
        
        //[START] CACHE_OCS0103U00
        registerHandler(SystemServiceProto.OCS0103U00FindBoxCRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00FindBoxCHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00FindBoxDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00FindBoxDHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboResultGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboResultGubunHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboIfInputControlRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboIfInputControlHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboEmergencyRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboEmergencyHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboSubulConvertGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboSubulConvertGubunHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboWonyoiOrderYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboWonyoiOrderYnHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboDvTimeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboDvTimeHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboInputControlRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboInputControlHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboOrderGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboOrderGubunHandler.class));
        registerHandler(SystemServiceProto.OCS0103U00CboSlipGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(OCS0103U00CboSlipGubunHandler.class));
        //[START] CACHE_OCS0103U00
        
        registerHandler(SystemServiceProto.ComboUserGroupRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboUserGroupHandler.class));
        registerHandler(SystemServiceProto.CboDoctorGradeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CboDoctorGradeHandler.class));
        registerHandler(SystemServiceProto.ComboNuGroupRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboNuGroupHandler.class));
        //[START]CACHE_ADM107U_FWK_USER_ID
        //[END]CACHE_ADM107U_FWK_USER_ID
        
        registerHandler(SystemServiceProto.ADM106UFwkSysIdRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM106UFwkSysIdHandler.class));
        //[START] CACHE_CBO_ADMIN_GUBUN = "BAS.AdminGubun" 
        registerHandler(SystemServiceProto.ComboAdminGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboAdminGubunHandler.class));
        //[END]CACHE_CBO_ADMIN_GUBUN = "BAS.AdminGubun" 
        registerHandler(SystemServiceProto.ADM102UFwkSysIdRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ADM102UFwkSysIdHandler.class));
        registerHandler(SystemServiceProto.ComboNur0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ComboNur0101Handler.class));
        registerHandler(SystemServiceProto.CreateGwaComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CreateGwaComboHandler.class));
        //[START] CACHE_XRT0122Q00_LAYCBO_XRT0102 
        registerHandler(SystemServiceProto.Xrt0122Q00LayComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Xrt0122Q00LayComboHandler.class));
        //[END] CACHE_XRT0122Q00_LAYCBO_XRT0102 
        
        //[START]
        registerHandler(SystemServiceProto.BAS0110Q00LayJohapGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BAS0110Q00LayJohapGubunHandler.class));
        //[END]
        
        //[START] CACHE_PHY2001U04
        registerHandler(SystemServiceProto.PHY2001U04CboJubsuGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04CboJubsuGubunHandler.class));
        registerHandler(SystemServiceProto.PHY2001U04GrdCboJubsuGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY2001U04GrdCboJubsuGubunHandler.class));
        //[END] CACHE_PHY2001U04
         
        // [START] PHY8002U01
        registerHandler(SystemServiceProto.PHY8002U01CboDisUseKaizenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01CboDisUseKaizenHandler.class));
        registerHandler(SystemServiceProto.PHY8002U01CboDisUseKainyuRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01CboDisUseKainyuHandler.class));
        registerHandler(SystemServiceProto.PHY8002U01CboDisUseADLRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01CboDisUseADLHandler.class));
        registerHandler(SystemServiceProto.PHY8002U01CboDisUseGasyouRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01CboDisUseGasyouHandler.class));
        registerHandler(SystemServiceProto.PHY8002U01GetLayComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(PHY8002U01GetLayComboHandler.class));

        //[END] PHY8002U01
        
        //NUR2001U04
        registerHandler(SystemServiceProto.NUR2001U04CboGwaRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(NUR2001U04CboGwaHandler.class));
        //NUR2001U04
        
        // [START] CommonForms
        registerHandler(SystemServiceProto.ReservedCommentDloOCS0221Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ReservedCommentDloOCS0221Handler.class));
        registerHandler(SystemServiceProto.ReservedCommentGrdOCS0222Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(ReservedCommentGrdOCS0222Handler.class));
        // [END] CommonForms
        
        // [START] COMHOSP
        registerHandler(SystemServiceProto.FwXHospCodeBoxLoadAllRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(FwXHospCodeBoxLoadAllHandler.class));
        registerHandler(SystemServiceProto.FwXHospCodeBoxLoadByHospCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(FwXHospCodeBoxLoadByHospCodeHandler.class));
        registerHandler(SystemServiceProto.FwXHospCodeBoxGetGrdHospCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(FwXHospCodeBoxGetGrdHospCodeHandler.class));

        // [START] COMHOSP
        
        // [START] StartForm
        //TODO remove MainFormGetSuperAdminMenuItemRequest MainFormGetAdminMenuItemRequest
        registerHandler(SystemServiceProto.AdmLoginFormCheckLoginUserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(AdmLoginFormCheckLoginUserHandler.class));
        
        //TODO: shit
        registerHandler(SystemServiceProto.MainFormGetSuperAdminMenuItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MainFormGetSuperAdminMenuItemHandler.class));
        registerHandler(SystemServiceProto.MainFormGetAdminMenuItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MainFormGetAdminMenuItemHandler.class));
        //end 
        
        registerHandler(SystemServiceProto.FwUserInfoChangePswRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(FwUserInfoChangePswHandler.class));
        registerHandler(SystemServiceProto.MainFormGetSysInfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MainFormGetSysInfoHandler.class));
        registerHandler(SystemServiceProto.MainFormGetMsgSystemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(MainFormGetMsgSystemHandler.class));
        // [END] StartForm
        registerHandler(SystemServiceProto.PatientInfoLoadPatientNaewonListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(PatientInfoLoadPatientNaewonListHandler.class));
        // [START] CPLMASTERUPLOADER
        registerHandler(SystemServiceProto.CPLMASTERUPLOADERCboMstTypeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CPLMASTERUPLOADERCboMstTypeHandler.class));
        // [START] CPLMASTERUPLOADER
        
        // [START] CheckHideButton
        registerHandler(SystemServiceProto.CheckHideButtonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckHideButtonHandler.class));
        // [END] CheckHideButton
        
        // [START] FindLatestBunho
        registerHandler(SystemServiceProto.GetLatestBunhoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(GetLatestBunhoHandler.class));
        // [END] FindLatestBunho
        
        // [START] ChangeSystemUserRequest
        registerHandler(SystemServiceProto.ChangeSystemUserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ChangeSystemUserHandler.class));
        // [START] ChangeSystemUserRequest
        
        // [START] kinki
//        registerHandler(SystemServiceProto.SyncInteractionCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncInteractionCacheHandler.class));
//        registerHandler(SystemServiceProto.SyncGenericNameCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncGenericNameCacheHandler.class));
//        registerHandler(SystemServiceProto.SyncDrugDosageCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncDrugDosageCacheHandler.class));
//        registerHandler(SystemServiceProto.SyncDrugCheckingCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncDrugCheckingCacheHandler.class));
//        registerHandler(SystemServiceProto.SyncDosageAddtionCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncDosageAddtionCacheHandler.class));
//        registerHandler(SystemServiceProto.SyncDosageNormalCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncDosageNormalCacheHandler.class));
//        registerHandler(SystemServiceProto.SyncDosageStandardCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncDosageStandardCacheHandler.class));
//        registerHandler(SystemServiceProto.SyncKinkiDiseaseCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncKinkiDiseaseCacheHandler.class));
       // registerHandler(SystemServiceProto.SyncKinkiMessageCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncKinkiMessageCacheHandler.class));
        registerHandler(SystemServiceProto.SyncKinkiCacheRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SyncKinkiCacheHandler.class));
        // [END] kinki
        
        //TODO remove after test

        // [START] LockUserRequest
        registerHandler(SystemServiceProto.AdmLoginFormLockUserRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(AdmLoginFormLockUserHandler.class));
        // [END] LockUserRequest
        
        // [START] CACHE_OCSEMR_CBO_INPUT_TAB 
        registerHandler(SystemServiceProto.OcsEMRLoadComboInputTabRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OcsEMRLoadComboInputTabHandler.class));
        registerHandler(SystemServiceProto.FormSelectHospCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(FormSelectHospCodeHandler.class));
       // registerHandler(SystemServiceProto.OrcaLoginRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OrcaLoginHandler.class));
        // [END] CACHE_OCSEMR_CBO_INPUT_TAB 
        
        registerHandler(SystemServiceProto.UpdateMasterDataRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(UpdateMasterDataHandler.class));
        registerHandler(SystemServiceProto.GetORCAEnvRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(GetORCAEnvHandler.class));
        registerHandler(SystemServiceProto.CheckNewMstDataRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CheckNewMstDataHandler.class));
        
        registerHandler(SystemServiceProto.GetORCAEnvByGigwanCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(GetORCAEnvByGigwanCodeHandler.class));
        registerHandler(SystemServiceProto.GetIntegratedSystemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(GetIntegratedSystemHandler.class));
//        Composite
        registerHandler(SystemServiceProto.LoadHangmogInfoCompositeFirstRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(LoadHangmogInfoCompositeFirstHandler.class));
        registerHandler(SystemServiceProto.LoadHangmogInfoCompositeSecondRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(LoadHangmogInfoCompositeSecondHandler.class));
   
        //[START] KCCK API
        registerHandler(SystemServiceProto.GetHospitalListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(GetHospitalListHandler.class));
        registerHandler(SystemServiceProto.VerifyPatientAccountRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(VerifyPatientAccountHandler.class));
        registerHandler(SystemServiceProto.FindDepartmentByHospCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(FindDepartmentByHospCodeHandler.class));
        //[END] KCCK API
        
        //[START] CMI API
        registerHandler(SystemServiceProto.GetHospitalInfoByHospCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(GetHospitalInfoByHospCodeHandler.class));
        //[END] CMI API
        
        registerHandler(SystemServiceProto.LoadSearchCommonOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(LoadSearchCommonOrderHandler.class));
        
        registerHandler(SystemServiceProto.OBCheckInventoryRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OBCheckInventoryHandler.class));

        //[START] MBS API
        registerHandler(SystemServiceProto.KcckVefiryAccountRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(KcckVefiryAccountHandler.class));
        //[END] MBS API

        registerHandler(SystemServiceProto.GetWaitingPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(GetWaitingPatientHandler.class));
        
        //[START] MIH
        registerHandler(SystemServiceProto.OBIsToiwonResYnRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OBIsToiwonResYnHandler.class));
        registerHandler(SystemServiceProto.OBGetNotApproveDeseaseCntRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OBGetNotApproveDeseaseCntHandler.class));
        registerHandler(SystemServiceProto.OBIsCPPatientRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OBIsCPPatientHandler.class));
        registerHandler(SystemServiceProto.OBIsMeterialOrderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OBIsMeterialOrderHandler.class));
        
        registerHandler(SystemServiceProto.OBIsgetBeforeApporderRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(OBIsgetBeforeApporderHandler.class));
        registerHandler(SystemServiceProto.DupCheckCPLOrder2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(DupCheckCPLOrder2Handler.class));
        registerHandler(SystemServiceProto.NURUserIDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(NURUserIDHandler.class));
        //[END] MIH
        
        vertx.eventBus().registerHandler(AdministrationNotice.MAINTAINANCE_NOTICE.getAddress(), new Handler<Message<byte[]>>() {
            @Override
            public void handle(Message<byte[]> event) {
                try {
                    AdmaServiceProto.Adms2016U00SaveMaintainanceSettingRequest message = AdmaServiceProto.Adms2016U00SaveMaintainanceSettingRequest.parseFrom(event.body());
                    LOGGER.info("Receive maintain notice: " + format(message));
                    for (AdmaModelProto.MaintainanceSettingInfo info : message.getMaintainanceSettingsList()) {
                        VertxContext.current().maintainance(info.getHospGroupCd(), info.getMaintenanceMode() != 0);
                    }
                } catch (InvalidProtocolBufferException e) {
                    LOGGER.warn(e.getMessage(), e);
                }
            }
        }, event -> {
            if (event.succeeded()) {
                LOGGER.info("Completed registerHandler of " + AdministrationNotice.MAINTAINANCE_NOTICE.getAddress());
            } else {
                LOGGER.info(String.format("RegisterHandler of %s was failed. Result = %s", AdministrationNotice.MAINTAINANCE_NOTICE.getAddress(), event.result()));
            }
        });
    }

    @Override
    protected void doStop() throws Exception {

}
}

