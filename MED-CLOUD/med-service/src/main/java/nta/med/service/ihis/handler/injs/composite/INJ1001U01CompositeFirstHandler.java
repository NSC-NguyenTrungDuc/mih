package nta.med.service.ihis.handler.injs.composite;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01CboTimeHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01CplOrderStatusHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01DetailListHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01MasterListHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01MlayConstantInfoHandler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01ScheduleHandler;
import nta.med.service.ihis.handler.system.GetPatientByCodeHandler;
import nta.med.service.ihis.proto.InjsModelProto.InjsINJ1001U01MasterListItemInfo;
import nta.med.service.ihis.proto.InjsModelProto.InjsINJ1001U01ScheduleItemInfo;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01CompositeFirstRequest;
import nta.med.service.ihis.proto.InjsServiceProto.INJ1001U01CompositeFirstResponse;
import nta.med.service.ihis.proto.InjsServiceProto.InjsINJ1001U01DetailListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientByCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientByCodeResponse;

@Service
@Scope("prototype")
public class INJ1001U01CompositeFirstHandler extends
		ScreenHandler<InjsServiceProto.INJ1001U01CompositeFirstRequest, InjsServiceProto.INJ1001U01CompositeFirstResponse> {
	private static final Log LOGGER = LogFactory.getLog(INJ1001U01CompositeFirstHandler.class);

	@Resource
	private InjsINJ1001U01CboTimeHandler injsINJ1001U01CboTimeHandler;

	@Resource
	private InjsINJ1001U01MasterListHandler injsINJ1001U01MasterListHandler;

	@Resource
	private GetPatientByCodeHandler getPatientByCodeHandler;
	
	@Resource
	private InjsINJ1001U01CplOrderStatusHandler injsINJ1001U01CplOrderStatusHandler;

	@Resource
	private InjsINJ1001U01MlayConstantInfoHandler injsINJ1001U01MlayConstantInfoHandler;

	@Resource
	private InjsINJ1001U01ScheduleHandler injsINJ1001U01ScheduleHandler;
	
	@Resource
	private InjsINJ1001U01DetailListHandler injsINJ1001U01DetailListHandler;

	@Override
	public INJ1001U01CompositeFirstResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INJ1001U01CompositeFirstRequest request) throws Exception {
		InjsServiceProto.INJ1001U01CompositeFirstResponse.Builder response = InjsServiceProto.INJ1001U01CompositeFirstResponse
				.newBuilder();
		response.setCboTimeList(injsINJ1001U01CboTimeHandler.handle(vertx, clientId, sessionId, contextId, request.getCboTimeParam()));
		// 1
		response.setGrdMasterList(injsINJ1001U01MasterListHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdMasterParam()));
		// 2
		List<InjsINJ1001U01MasterListItemInfo> masterListItemInfo = response.getGrdMasterList().getMasterListItemList();
		
		if (!CollectionUtils.isEmpty(masterListItemInfo)) {
			InjsINJ1001U01MasterListItemInfo firstItem = masterListItemInfo.get(0);
			
			GetPatientByCodeRequest getPatientByCodeRequest = GetPatientByCodeRequest.newBuilder()
					.setPatientCode(firstItem.getBunho())
					.setHospCode(getHospitalCode(vertx, sessionId))
					.build();
			
			response.setPatientInfo(getPatientByCodeHandler.handle(vertx, clientId, sessionId, contextId, getPatientByCodeRequest));
		}
		else
		{
			GetPatientByCodeResponse.Builder getPatientByCodeResponse = GetPatientByCodeResponse.newBuilder();
			//getPatientByCodeResponse.getPatientInfoList();
			response.setPatientInfo(getPatientByCodeResponse);
		}
		
		response.setOrderStatusRes(injsINJ1001U01CplOrderStatusHandler.handle(vertx, clientId, sessionId, contextId, request.getOrderStatus()));
		
		response.setConstantInfoRes(injsINJ1001U01MlayConstantInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getConstantInfo()));
		
		//3
		response.setScheduleRes(injsINJ1001U01ScheduleHandler.handle(vertx, clientId, sessionId, contextId, request.getSchedule()));
		
		List<InjsINJ1001U01ScheduleItemInfo> listScheduleItemInfo = response.getScheduleRes().getScheduleItemList();
		
		if (!CollectionUtils.isEmpty(listScheduleItemInfo)) {
			InjsINJ1001U01ScheduleItemInfo firstItem = listScheduleItemInfo.get(0);
			
			InjsINJ1001U01DetailListRequest detailListRequest = InjsINJ1001U01DetailListRequest.newBuilder()
					.setBunho("")
					.setGwa(firstItem.getGwa())
					.setDoctor(firstItem.getDoctor())
					.setReserDate(firstItem.getReserDate())
					.setActingDate(firstItem.getActingDate())
					.setActingFlag("N")
					.build();		
			
			response.setDetailtListRes(injsINJ1001U01DetailListHandler.handle(vertx, clientId, sessionId, contextId, detailListRequest));
		} else {
			response.setDetailtListRes(injsINJ1001U01DetailListHandler.handle(vertx, clientId, sessionId, contextId, request.getDetailtList()));
		}
		
		return response.build();
	}

}
