package nta.med.service.ihis.handler.cpls.composite;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.cpls.CPL2010U00GrdOrderHandler;
import nta.med.service.ihis.handler.cpls.CPL2010U00GrdPaListHandler;
import nta.med.service.ihis.handler.cpls.CPL2010U00LayChkNamesHandler;
import nta.med.service.ihis.handler.cpls.CPL2010U00VsvPaHandler;
import nta.med.service.ihis.handler.cpls.CplsCPL2010U00CheckInjCplOrderCPL2010Handler;
import nta.med.service.ihis.handler.cpls.CplsCPL2010U00GrdSpecimenCPL2010Handler;
import nta.med.service.ihis.handler.cpls.CplsCPL2010U00GrdTubeQueryStartingCPL2010Handler;
import nta.med.service.ihis.handler.cpls.CplsCPL2010U00MlayConstantCPL2010Handler;
import nta.med.service.ihis.handler.system.CheckUserLoginHandler;
import nta.med.service.ihis.handler.system.ComboADM3200CbxActorHandler;
import nta.med.service.ihis.handler.system.FormEnvironInfoSysDateHandler;
import nta.med.service.ihis.handler.system.FormEnvironInfoSysDateTimeHandler;
import nta.med.service.ihis.handler.system.FormScreenListHandler;
import nta.med.service.ihis.handler.system.MdiFormMainMenuHandler;
import nta.med.service.ihis.handler.system.MdiFormOpenMainScreenHandler;
import nta.med.service.ihis.handler.system.XPaInfoBoxHandler;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00CheckInjCplOrderRequest;
import nta.med.service.ihis.proto.CplsModelProto.CPL2010U00GrdOrderListItemInfo;
import nta.med.service.ihis.proto.CplsModelProto.CPL2010U00GrdPaListItemInfo;
import nta.med.service.ihis.proto.CplsModelProto.CPL2010U00GrdSpecimenListItemInfo;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdOrderRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdSpecimenRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL2010U00GrdTubeQueryStartingRequest;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * 
 * @author DEV-HuanLT
 *
 */
@Service
@Scope("prototype")
public class CPL2010U00OpenScreenCompositeHandler extends
		ScreenHandler<CplsServiceProto.CPL2010U00OpenScreenCompositeRequest, CplsServiceProto.CPL2010U00OpenScreenCompositeResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(CPL2010U00OpenScreenCompositeHandler.class);
	
	@Resource
	private CheckUserLoginHandler checkUserLoginHandler;
	
	@Resource
	private MdiFormMainMenuHandler mdiFormMainMenuHandler;
	
	@Resource
	private MdiFormOpenMainScreenHandler mdiFormOpenMainScreenHandler;
	
	@Resource
	private FormScreenListHandler formScreenListHandler;
	
	@Resource
	private ComboADM3200CbxActorHandler comboADM3200CbxActorHandler;
	
	@Resource
	private FormEnvironInfoSysDateHandler formEnvironInfoSysDateHandler;
	
	@Resource
	private CPL2010U00GrdPaListHandler cpl2010U00GrdPaListHandler;
	
	@Resource
	private CPL2010U00VsvPaHandler cpl2010U00VsvPaHandler;
	
	@Resource
	private XPaInfoBoxHandler xpaInfoBoxHandler;
	
	@Resource
	private CPL2010U00LayChkNamesHandler cpl2010U00LayChkNamesHandler;
	
	@Resource
	private CPL2010U00GrdOrderHandler cpl2010U00GrdOrderHandler;
	
	@Resource
	private CplsCPL2010U00GrdSpecimenCPL2010Handler cpl2010U00GrdSpecimenHandler;
	
	@Resource
	private CplsCPL2010U00GrdTubeQueryStartingCPL2010Handler cpl2010U00GrdTubeQueryStartingHandler;
	
	@Resource
	private FormEnvironInfoSysDateTimeHandler formEnvironInfoSysDateTimeHandler;
	
	@Resource
	private CplsCPL2010U00MlayConstantCPL2010Handler cpl2010U00MlayConstantInfoHandler;

	@Resource
	private CplsCPL2010U00CheckInjCplOrderCPL2010Handler cplsCPL2010U00CheckInjCplOrderCPL2010Handler;
	
	@Override
	@Transactional
	public CplsServiceProto.CPL2010U00OpenScreenCompositeResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, CplsServiceProto.CPL2010U00OpenScreenCompositeRequest request) throws Exception {
		CplsServiceProto.CPL2010U00OpenScreenCompositeResponse.Builder response = CplsServiceProto.CPL2010U00OpenScreenCompositeResponse.newBuilder();
		
		//LOGGER.info("1 CheckUserLoginHandler: " + System.currentTimeMillis());
		if (request.hasCheckUser()) {
			response.setCheckUser(checkUserLoginHandler.handle(vertx, clientId, sessionId, contextId,
					request.getCheckUser()));
		}

		//LOGGER.info("2 MdiFormMainMenuHandler: " + System.currentTimeMillis());
		if(request.hasMdiFrom()){
			response.setMdiFrom(mdiFormMainMenuHandler.handle(vertx, clientId, sessionId, contextId,
					request.getMdiFrom()));
		}
		
		//LOGGER.info("3 MdiFormOpenMainScreenHandler: " + System.currentTimeMillis());
		if(request.hasMdiScreen()){
			response.setMdiScreen(mdiFormOpenMainScreenHandler.handle(vertx, clientId, sessionId, contextId,
					request.getMdiScreen()));
		}
		
		//LOGGER.info("4 FormScreenListHandler: " + System.currentTimeMillis());
		if(request.hasFromScreen()){
			response.setFromScreen(formScreenListHandler.handle(vertx, clientId, sessionId, contextId,
					request.getFromScreen()));
		}
		
		//LOGGER.info("5 ComboADM3200CbxActorHandler: " + System.currentTimeMillis());
		if(request.hasCbxActor()){
			response.setCbxActor(comboADM3200CbxActorHandler.handle(vertx, clientId, sessionId, contextId,
					request.getCbxActor()));
		}
		
		//LOGGER.info("6 FormEnvironInfoSysDateHandler: " + System.currentTimeMillis());
		if(request.getInfoSysDateList() != null){
			for (SystemServiceProto.FormEnvironInfoSysDateRequest item : request.getInfoSysDateList()) {
				response.addInfoSysDate(formEnvironInfoSysDateHandler.handle(vertx, clientId, sessionId, contextId, item));
			}
		}
		
		// here 1
		//LOGGER.info("7 CPL2010U00GrdPaListHandler: " + System.currentTimeMillis());
		if(request.hasPaList()){
			response.setPaList(cpl2010U00GrdPaListHandler.handle(vertx, clientId, sessionId, contextId,
					request.getPaList()));
		}
		
		//LOGGER.info("8 CPL2010U00VsvPaHandler: " + System.currentTimeMillis());
		if(request.hasVsvPa()){
			response.setVsvPa(cpl2010U00VsvPaHandler.handle(vertx, clientId, sessionId, contextId,
					request.getVsvPa()));
		}
		
		//LOGGER.info("9 XPaInfoBoxHandler: " + System.currentTimeMillis());
		if(request.hasInfoBox()){
			response.setInfoBox(xpaInfoBoxHandler.handle(vertx, clientId, sessionId, contextId,
					request.getInfoBox()));
		}
		
		//LOGGER.info("10 CPL2010U00LayChkNamesHandler: " + System.currentTimeMillis());
		if(request.hasLayChkName()){
			response.setLayChkName(cpl2010U00LayChkNamesHandler.handle(vertx, clientId, sessionId, contextId,
					request.getLayChkName()));
		}
		
		// here 2
		//LOGGER.info("11 CPL2010U00GrdOrderHandler: " + System.currentTimeMillis());
		List<CPL2010U00GrdPaListItemInfo> paList = response.getPaList().getGrdPalistListList();
		if(!CollectionUtils.isEmpty(paList)){
			CPL2010U00GrdPaListItemInfo firstItem = paList.get(0); 
			CPL2010U00GrdOrderRequest rq = CPL2010U00GrdOrderRequest.newBuilder()
					.setBunho(firstItem.getBunho())
					.setMijubsu(request.getGrdOrder().getMijubsu()) //
					.setReserYn(firstItem.getReserYn())
					.setFromDate(request.getGrdOrder().getFromDate())
					.setToDate(request.getGrdOrder().getToDate())
					.setDoctor(firstItem.getDoctor())
					.setEmergencyYn(firstItem.getEmergencyYn())
					.build();
			
			response.setGrdOrder(cpl2010U00GrdOrderHandler.handle(vertx, clientId, sessionId, contextId, rq));
		}
		
		// here 3
		//LOGGER.info("12 CplsCPL2010U00GrdSpecimenCPL2010Handler: " + System.currentTimeMillis());
		List<CPL2010U00GrdOrderListItemInfo> grdList = response.getGrdOrder().getGrdOrderListList();
		if(!CollectionUtils.isEmpty(grdList)){
			CPL2010U00GrdOrderListItemInfo firstItem = grdList.get(0);
			CPL2010U00GrdSpecimenRequest  rq1 = CPL2010U00GrdSpecimenRequest .newBuilder()
					.setMJubsuYn(YesNo.OTHER.getValue())
					.setOrderDate(firstItem.getOrderDate())
					.setBunho(firstItem.getBunho())
					.setGwa(firstItem.getGwa())
					.setOrderTime(firstItem.getOrderTime())
					.setDoctor(firstItem.getDoctor())
					.setReserDate(firstItem.getReserDate())
					.setJubsuDate(firstItem.getJubsuDate())
					.setJubsuTime(firstItem.getJubsuTime())
					.setJubsuja(firstItem.getJubsuja())
					.setGroupSer(firstItem.getGroupSer())
					.setReserYn(response.getPaList().getGrdPalistList(0).getReserYn())
					.setEmergencyYn(response.getPaList().getGrdPalistList(0).getEmergencyYn())
					.build();
			
			response.setGrdSpecimen(cpl2010U00GrdSpecimenHandler.handle(vertx, clientId, sessionId, contextId, rq1));
			
			CPL2010U00CheckInjCplOrderRequest rq2 = CPL2010U00CheckInjCplOrderRequest.newBuilder()
					.setIoGubun(firstItem.getInOutGubun())
					.setBunho(firstItem.getBunho())
					.setOrderDate(firstItem.getOrderDate())
					.build();
			
			response.setInjCplOrder(cplsCPL2010U00CheckInjCplOrderCPL2010Handler.handle(vertx, clientId, sessionId, contextId, rq2));
		}
		
		// here 4
		//LOGGER.info("13 CplsCPL2010U00GrdTubeQueryStartingCPL2010Handler: " + System.currentTimeMillis());
		List<CPL2010U00GrdSpecimenListItemInfo> specimenList = response.getGrdSpecimen().getGrdSpecimenListList();
		if(!CollectionUtils.isEmpty(specimenList)){
			CPL2010U00GrdSpecimenListItemInfo firstItem = specimenList.get(0);
			CPL2010U00GrdTubeQueryStartingRequest  rq = CPL2010U00GrdTubeQueryStartingRequest .newBuilder()
					.setRbxJubsuChecked(request.getGrdTube().getRbxJubsuChecked()) // TODO
					.setOrderDate(firstItem.getOrderDate())
					.setOrderTime(firstItem.getOrderTime())
					.setBunho(firstItem.getBunho())
					.build();
			
			response.setGrdTube(cpl2010U00GrdTubeQueryStartingHandler.handle(vertx, clientId, sessionId, contextId, rq));
		}
		
		//LOGGER.info("14 FormEnvironInfoSysDateTimeHandler: " + System.currentTimeMillis());
		if(request.getInfoSysDateTimeList() != null){
			for (SystemServiceProto.FormEnvironInfoSysDateTimeRequest item : request.getInfoSysDateTimeList()) {
				response.addInfoSysDateTime(formEnvironInfoSysDateTimeHandler.handle(vertx, clientId, sessionId, contextId, item));
			}
		}
		
		//LOGGER.info("15 CplsCPL2010U00MlayConstantCPL2010Handler: " + System.currentTimeMillis());
		if(request.getConstantInfoList() != null){
			for (CplsServiceProto.CPL2010U00MlayConstantInfoRequest item : request.getConstantInfoList()) {
				response.addConstantInfo(cpl2010U00MlayConstantInfoHandler.handle(vertx, clientId, sessionId, contextId, item));
			}
		}
		
		//LOGGER.info("END CPL2010U00OpenScreenCompositeHandler_: " + System.currentTimeMillis());
		return response.build();
	}
}
