package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0108;
import nta.med.data.dao.medi.sch.Sch0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U01GrdMasterRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U01GrdMasterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SCH0109U01GrdMasterHandler
	extends ScreenHandler<SchsServiceProto.SCH0109U01GrdMasterRequest, SchsServiceProto.SCH0109U01GrdMasterResponse> {                     
	@Resource                                                                                                       
	private Sch0108Repository sch0108Repository;                                                                    
	                                                                                                                
	@Override        
	@Transactional(readOnly=true)
	public SCH0109U01GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0109U01GrdMasterRequest request)
			throws Exception {                                                                 
  	   	SchsServiceProto.SCH0109U01GrdMasterResponse.Builder response = SchsServiceProto.SCH0109U01GrdMasterResponse.newBuilder();                      
		List<Sch0108> listSch0108 = sch0108Repository.getSCH0109U01GrdMasterInfo(getHospitalCode(vertx, sessionId), "%" + request.getCodeType() + "%", "%" + request.getCodeTypeName() + "%", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listSch0108)){
			for(Sch0108 sch0108 : listSch0108){
				SchsModelProto.SCH0109U01GrdMasterInfo.Builder info = SchsModelProto.SCH0109U01GrdMasterInfo.newBuilder();
				if (!StringUtils.isEmpty(sch0108.getCodeType())) {
					info.setCodeType(sch0108.getCodeType());
				}
				if (!StringUtils.isEmpty(sch0108.getCodeTypeName())) {
					info.setCodeTypeName(sch0108.getCodeTypeName());
				}
				if (!StringUtils.isEmpty(sch0108.getAdminGubun())) {
					info.setAdminGubun(sch0108.getAdminGubun());
				}
				if (!StringUtils.isEmpty(sch0108.getRemark())) {
					info.setRemark(sch0108.getRemark());
				}
				response.addGrdMstItem(info);
			}
		}
		return response.build();
	}
}