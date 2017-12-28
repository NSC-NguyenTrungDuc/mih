package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01ScheduleItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01ScheduleHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01ScheduleRequest, InjsServiceProto.InjsINJ1001U01ScheduleResponse> {
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01ScheduleHandler.class);
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01ScheduleRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}else if(!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01ScheduleResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01ScheduleRequest request) throws Exception {
		 InjsServiceProto.InjsINJ1001U01ScheduleResponse.Builder response = InjsServiceProto.InjsINJ1001U01ScheduleResponse.newBuilder();
		 List<InjsINJ1001U01ScheduleItemInfo> listObject = ocs1003Repository.getInjsINJ1001U01ScheduleItemInfo(getHospitalCode(vertx, sessionId), 
				 getLanguage(vertx, sessionId), request.getBunho(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), 
         		request.getPostOrderYn(), request.getPreOrderYn(), DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD), request.getActingFlag());
         
         if (!CollectionUtils.isEmpty(listObject)) {
         	for (InjsINJ1001U01ScheduleItemInfo item : listObject) {
         		InjsModelProto.InjsINJ1001U01ScheduleItemInfo.Builder info = InjsModelProto.InjsINJ1001U01ScheduleItemInfo.newBuilder();
         		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
         		response.addScheduleItem(info);
         	}
         }
		return response.build();
	}
}
