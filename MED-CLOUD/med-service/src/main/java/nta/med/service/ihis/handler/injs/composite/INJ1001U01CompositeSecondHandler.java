package nta.med.service.ihis.handler.injs.composite;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.injs.INJ1001U01GrdSangHandler;
import nta.med.service.ihis.handler.injs.INJ1001U01Grouped2Handler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01AllergyListHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01ChkbStateHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01CplOrderStatusHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01DetailListHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01MlayConstantInfoHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01ReserDateListHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01ScheduleHandler;
import nta.med.service.ihis.handler.system.GetPatientByCodeHandler;
import nta.med.service.ihis.proto.InjsModelProto.InjsINJ1001U01ScheduleItemInfo;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01CompositeSecondRequest;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01CompositeSecondResponse;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01GrdSangRequest;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01Grouped2Request;
import nta.med.service.ihis.proto.InjsServiceProto.InjsINJ1001U01DetailListRequest;

@Service
@Scope("prototype")
public class INJ1001U01CompositeSecondHandler extends ScreenHandler<InjsServiceProto.INJ1001U01CompositeSecondRequest , InjsServiceProto.INJ1001U01CompositeSecondResponse> {

	@Resource
    private InjsINJ1001U01DetailListHandler injsINJ1001U01DetailListHandler;
	@Resource
    private INJ1001U01GrdSangHandler iNJ1001U01GrdSangHandler;
	@Resource
    private InjsINJ1001U01CplOrderStatusHandler injsINJ1001U01CplOrderStatusHandler;
	@Resource
    private INJ1001U01Grouped2Handler iNJ1001U01Grouped2Handler;
	@Resource
    private InjsINJ1001U01AllergyListHandler injsINJ1001U01AllergyListHandler;
	@Resource
    private InjsINJ1001U01ReserDateListHandler injsINJ1001U01ReserDateListHandler;
	@Resource
    private InjsINJ1001U01ChkbStateHandler injsINJ1001U01ChkbStateHandler;
	@Resource
	private GetPatientByCodeHandler      getPatientByCodeHandler;
	@Resource
	private InjsINJ1001U01ScheduleHandler      injsINJ1001U01ScheduleHandler;
	@Resource
	private InjsINJ1001U01MlayConstantInfoHandler injsINJ1001U01MlayConstantInfoHandler;
	
	@Override
	@Transactional(readOnly = true)
	public INJ1001U01CompositeSecondResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INJ1001U01CompositeSecondRequest request) throws Exception {
		InjsServiceProto.INJ1001U01CompositeSecondResponse.Builder response = InjsServiceProto.INJ1001U01CompositeSecondResponse.newBuilder(); 
		
		response.setCplOrder(injsINJ1001U01CplOrderStatusHandler.handle(vertx, clientId, sessionId, contextId, request.getCplOrder()));
		
		response.setAllergy(injsINJ1001U01AllergyListHandler.handle(vertx, clientId, sessionId, contextId, request.getAllergy()));
		
		response.setReserDate(injsINJ1001U01ReserDateListHandler.handle(vertx, clientId, sessionId, contextId, request.getReserDate()));
		
		for (InjsServiceProto.InjsINJ1001U01ChkbStateRequest item : request.getChkbStateList()) {
			 response.addChkbState(injsINJ1001U01ChkbStateHandler.handle(vertx, clientId, sessionId, contextId, item));
	    }
		
		response.setPatientInfo(getPatientByCodeHandler.handle(vertx, clientId, sessionId, contextId, request.getPatientInfo()));
		
		
		//1
		response.setSchedule(injsINJ1001U01ScheduleHandler.handle(vertx, clientId, sessionId, contextId, request.getSchedule()));
		
		//2
		List<InjsINJ1001U01ScheduleItemInfo> scheduleList = response.getSchedule().getScheduleItemList();
		if(!CollectionUtils.isEmpty(scheduleList)){
			InjsINJ1001U01ScheduleItemInfo firstItem = scheduleList.get(0); 
			// 2.1
			InjsINJ1001U01DetailListRequest detailListRequest = InjsINJ1001U01DetailListRequest.newBuilder()
					.setBunho(request.getSchedule().getBunho())
					.setGwa(firstItem.getGwa())
					.setDoctor(firstItem.getDoctor())
					.setReserDate(firstItem.getReserDate())
					.setActingDate(firstItem.getActingDate())
					.setActingFlag(request.getSchedule().getActingFlag())
					.build();		
			
			response.setGrdDetail(injsINJ1001U01DetailListHandler.handle(vertx, clientId, sessionId, contextId, detailListRequest));
			
			// 2.2
			INJ1001U01GrdSangRequest grdSangRequest = INJ1001U01GrdSangRequest.newBuilder()
					.setHospCode(getHospitalCode(vertx, sessionId))
					.setBunho(request.getGrdSang().getBunho())
					.setGwa(firstItem.getGwa())
					.setReserDate(firstItem.getReserDate())
					.build();
			
			response.setGrdSang(iNJ1001U01GrdSangHandler.handle(vertx, clientId, sessionId, contextId, grdSangRequest));
			
			// 2.3
			INJ1001U01Grouped2Request  grouped2Request = INJ1001U01Grouped2Request .newBuilder()
					.setBunho(request.getGrouped().getBunho())
					.setQueryDate(request.getGrouped().getQueryDate())
					.setOrderDate(firstItem.getOrderDate())
					.setPostOrderYn(request.getGrouped().getPostOrderYn())
					.setPreOrderYn(request.getGrouped().getPreOrderYn())
					.setReserDate(firstItem.getReserDate())
					.setActingFlag("N")
					.setGwa(firstItem.getGwa())
					.setDoctor(firstItem.getDoctor())
					.setActingDate(firstItem.getActingDate())
					.setCommtGubun(request.getGrouped().getCommtGubun())
					.build();
			
			response.setGrouped(iNJ1001U01Grouped2Handler.handle(vertx, clientId, sessionId, contextId, grouped2Request));
		}
		
		response.setConsInfo(injsINJ1001U01MlayConstantInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getConsInfo()));
		
		return response.build();
	}

}
