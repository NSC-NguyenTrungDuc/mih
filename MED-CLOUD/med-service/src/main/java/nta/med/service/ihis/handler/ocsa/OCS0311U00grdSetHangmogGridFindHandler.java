package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0311U00grdSetHangmogGridFindListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdSetHangmogGridFindRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0311U00grdSetHangmogGridFindResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class OCS0311U00grdSetHangmogGridFindHandler
extends ScreenHandler<OcsaServiceProto.OCS0311U00grdSetHangmogGridFindRequest, OcsaServiceProto.OCS0311U00grdSetHangmogGridFindResponse> {                             
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public OCS0311U00grdSetHangmogGridFindResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0311U00grdSetHangmogGridFindRequest request) throws Exception {   
		OcsaServiceProto.OCS0311U00grdSetHangmogGridFindResponse.Builder response=OcsaServiceProto.OCS0311U00grdSetHangmogGridFindResponse.newBuilder();
		List<OCS0311U00grdSetHangmogGridFindListInfo> listGrdSetHangmog =  ocs0103Repository.getOCS0311U00grdSetHangmogGridFindListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getHangmogCode());
		 if(!CollectionUtils.isEmpty(listGrdSetHangmog)){
			 for(OCS0311U00grdSetHangmogGridFindListInfo item : listGrdSetHangmog){
				 OcsaModelProto.OCS0311U00grdSetHangmogGridFindListInfo.Builder info= OcsaModelProto.OCS0311U00grdSetHangmogGridFindListInfo.newBuilder();
				 	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGrdSetHangmog(info);
			 }
		 }
		 return response.build();
	}

}                                                                                                                 
