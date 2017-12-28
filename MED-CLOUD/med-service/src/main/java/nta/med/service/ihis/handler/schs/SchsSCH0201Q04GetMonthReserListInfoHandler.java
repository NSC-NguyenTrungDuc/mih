package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04GetMonthReserListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetMonthReserListInfoRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetMonthReserListInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q04GetMonthReserListInfoHandler 
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q04GetMonthReserListInfoRequest, SchsServiceProto.SchsSCH0201Q04GetMonthReserListInfoResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;

	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q04GetMonthReserListInfoResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q04GetMonthReserListInfoRequest request)
			throws Exception {
		List<SchsSCH0201Q04GetMonthReserListInfo> listResult = sch0201Repository.getSchsSCH0201Q04GetMonthReserListInfo(getHospitalCode(vertx, sessionId),
				request.getJundalTable(), request.getJundalPart(),request.getMonth());
		SchsServiceProto.SchsSCH0201Q04GetMonthReserListInfoResponse.Builder response = SchsServiceProto.SchsSCH0201Q04GetMonthReserListInfoResponse
				.newBuilder();
		if (listResult != null && !listResult.isEmpty()) {
			for (SchsSCH0201Q04GetMonthReserListInfo item : listResult) {
				SchsModelProto.SchsSCH0201Q04GetMonthReserListInfo.Builder info = SchsModelProto.SchsSCH0201Q04GetMonthReserListInfo
						.newBuilder();
				if (!StringUtils.isEmpty(item.getHoliDay())) {
					info.setHoliDay(item.getHoliDay().toString());
				}
				if (!StringUtils.isEmpty(item.getReserCnt())) {
					info.setReserCnt(item.getReserCnt().toString());
				}
				if (!StringUtils.isEmpty(item.getInwonCnt())) {
					info.setInwonCnt(item.getInwonCnt().toString());
				}
				response.addMonthReserListItem(info);
			}
		}
		return response.build();
	}
}
