package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ExecTimeListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99StoreProcedureResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class SchsSCH0201U99ExecTimeListHandler extends
		ScreenHandler<SchsServiceProto.SchsSCH0201U99ExecTimeListRequest, SchsServiceProto.SchsSCH0201U99StoreProcedureResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	
	@Override
	public boolean isValid(SchsSCH0201U99ExecTimeListRequest request, Vertx vertx,
			String clientId, String sessionId) {

		if (!StringUtils.isEmpty(request.getIReserDate()) && DateUtil.toDate(request.getIReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	public SchsSCH0201U99StoreProcedureResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SchsSCH0201U99ExecTimeListRequest request) throws Exception {
		SchsServiceProto.SchsSCH0201U99StoreProcedureResponse.Builder response = SchsServiceProto.SchsSCH0201U99StoreProcedureResponse.newBuilder();
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			sch0201Repository.callSchsSCH0201Q04PrSchTimeListOther(request.getHospCodeLink(), sessionHospCode, request.getIIpAddress(),
					request.getIJundalTable(), request.getIJundalPart(), request.getIGumsaja(), request.getIReserDate());
		}else{
			sch0201Repository.callSchsSCH0201Q04PrSchTimeList(sessionHospCode, request.getIIpAddress(),
					request.getIJundalTable(), request.getIJundalPart(), request.getIGumsaja(), request.getIReserDate());
		}
		response.setResult(true);
		return response.build();
	}
}
