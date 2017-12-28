package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0312Repository;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetCodeListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdSetCodeListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdSetCodeListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class OCS0311U00grdSetCodeListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0311U00grdSetCodeListRequest, OcsaServiceProto.OCS0311U00grdSetCodeListResponse> {                             
	@Resource                                                                                                       
	private Ocs0312Repository ocs0312Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS0311U00grdSetCodeListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311U00grdSetCodeListRequest request) throws Exception {                                                                 
		OcsaServiceProto.OCS0311U00grdSetCodeListResponse.Builder response=OcsaServiceProto.OCS0311U00grdSetCodeListResponse.newBuilder();
		List<OCS0311U00grdSetCodeListInfo> listGrdSet= ocs0312Repository.getOCS0311U00grdSetCodeListInfo(getHospitalCode(vertx, sessionId),request.getSetPart(),request.getHangmogCode());
		if(listGrdSet !=null && !listGrdSet.isEmpty()){
			for(OCS0311U00grdSetCodeListInfo item : listGrdSet){
				 OcsaModelProto.OCS0311U00grdSetCodeListInfo.Builder info= OcsaModelProto.OCS0311U00grdSetCodeListInfo.newBuilder();
				 if (!StringUtils.isEmpty(item.getSetPart())) {
						info.setSetPart(item.getSetPart());
					}
					if (!StringUtils.isEmpty(item.getHangmogCode())) {
						info.setHangmogCode(item.getHangmogCode());
					}
					if (!StringUtils.isEmpty(item.getSetCode())) {
						info.setSetCode(item.getSetCode());
					}
					if (!StringUtils.isEmpty(item.getComments())) {
						info.setComments(item.getComments());
					}
					if (!StringUtils.isEmpty(item.getSetCodeName())) {
						info.setSetCodeName(item.getSetCodeName());
					}
					response.addGrdSetCode(info);
			}
		}
		return response.build();
	}

}                                                                                                                 
