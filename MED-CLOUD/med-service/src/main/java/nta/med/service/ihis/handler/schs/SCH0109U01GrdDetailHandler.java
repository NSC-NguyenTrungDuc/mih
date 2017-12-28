package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0109;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U01GrdDetailRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U01GrdDetailResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SCH0109U01GrdDetailHandler
	extends ScreenHandler<SchsServiceProto.SCH0109U01GrdDetailRequest, SchsServiceProto.SCH0109U01GrdDetailResponse> {                     
	@Resource                                                                                                       
	private Sch0109Repository sch0109Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly=true)                                                                                                 
	public SCH0109U01GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0109U01GrdDetailRequest request)
			throws Exception {                                                                   
  	   	SchsServiceProto.SCH0109U01GrdDetailResponse.Builder response = SchsServiceProto.SCH0109U01GrdDetailResponse.newBuilder();                      
		List<Sch0109> listSch0109 = sch0109Repository.getSCH0109U00GrdDetailInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
		if(!CollectionUtils.isEmpty(listSch0109)){
			for(Sch0109 sch0109 : listSch0109){
				SchsModelProto.SCH0109U01GrdDetailInfo.Builder info = SchsModelProto.SCH0109U01GrdDetailInfo.newBuilder();
				if (!StringUtils.isEmpty(sch0109.getCodeType())) {
					info.setCodeType(sch0109.getCodeType());
				}
				if (!StringUtils.isEmpty(sch0109.getCode())) {
					info.setCode(sch0109.getCode());
				}
				if (!StringUtils.isEmpty(sch0109.getCodeName())) {
					info.setCodeName(sch0109.getCodeName());
				}
				if (!StringUtils.isEmpty(sch0109.getCodeName2())) {
					info.setCodeName2(sch0109.getCodeName2());
				}
				if (!StringUtils.isEmpty(sch0109.getCode2())) {
					info.setCode2(sch0109.getCode2());
				}
				if (sch0109.getSeq() != null) {
					info.setSeq(String.format("%.0f", sch0109.getSeq()));
				}
				response.addGrdDetailItem(info);
			}
		}
		return response.build();
	}
}