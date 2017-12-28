package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.system.BuseoInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.BuseoListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.BuseoListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class BuseoListHandler 
	extends ScreenHandler<SystemServiceProto.BuseoListRequest, SystemServiceProto.BuseoListResponse>{
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public BuseoListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BuseoListRequest request)
			throws Exception {
        List<BuseoInfo> listBasManageZipCodeInfo = bas0260Repository.getBuseoInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBuseoGubun());
        SystemServiceProto.BuseoListResponse.Builder response = SystemServiceProto.BuseoListResponse.newBuilder();           
        if (listBasManageZipCodeInfo != null && !listBasManageZipCodeInfo.isEmpty()) {
            for (BuseoInfo obj : listBasManageZipCodeInfo) {
            	SystemModelProto.BuseoInfo.Builder builder = SystemModelProto.BuseoInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getBuseoCode())) {
                	builder.setBuseoCode(obj.getBuseoCode());
                }
                if(!StringUtils.isEmpty(obj.getBuseoName())) {
                	builder.setBuseoName(obj.getBuseoName());
                }
                response.addBuseoList(builder);
            }
        }
        return response.build();
	}
}
