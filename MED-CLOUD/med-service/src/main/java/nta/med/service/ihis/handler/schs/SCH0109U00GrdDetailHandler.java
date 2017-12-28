package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0109;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00GrdDetailRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00GrdDetailResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0109U00GrdDetailHandler
	extends ScreenHandler<SchsServiceProto.SCH0109U00GrdDetailRequest, SchsServiceProto.SCH0109U00GrdDetailResponse> {
	
	@Resource
	private Sch0109Repository sch0109Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH0109U00GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0109U00GrdDetailRequest request)
			throws Exception {
        SchsServiceProto.SCH0109U00GrdDetailResponse.Builder response = SchsServiceProto.SCH0109U00GrdDetailResponse.newBuilder();
    	List<Sch0109> listSch0109 = sch0109Repository.getSCH0109U00GrdDetailInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
    	if(listSch0109 != null && !listSch0109.isEmpty()){
			for(Sch0109 item : listSch0109){
				SchsModelProto.SCH0109U00GrdDetailInfo.Builder info = SchsModelProto.SCH0109U00GrdDetailInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDetailList(info);
			}
		}
        return response.build();	
	}
}
