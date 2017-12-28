package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ReserTimeChkRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ReserTimeChkResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201U99ReserTimeChkHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99ReserTimeChkRequest, SchsServiceProto.SchsSCH0201U99ReserTimeChkResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99ReserTimeChkResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99ReserTimeChkRequest request) throws Exception {
		SchsServiceProto.SchsSCH0201U99ReserTimeChkResponse.Builder response = SchsServiceProto.SchsSCH0201U99ReserTimeChkResponse.newBuilder();
		String result = sch0201Repository.getSCH0201U99ReserTimeChk(getHospitalCode(vertx, sessionId),request.getBunho(),request.getReserDate(),
				request.getReserTime(), CommonUtils.parseDouble(request.getPksch0201()));
		if(!StringUtils.isEmpty(result)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.addChkCheck(info);
		}
		return response.build();
	}
}
