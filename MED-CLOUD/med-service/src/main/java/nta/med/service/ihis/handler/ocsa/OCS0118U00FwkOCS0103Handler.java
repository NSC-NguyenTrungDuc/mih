package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0118U00FwkOCS0103Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0118U00FwkOCS0103Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0118U00FwkOCS0103Handler extends ScreenHandler<OcsaServiceProto.OCS0118U00FwkOCS0103Request,OcsaServiceProto.OCS0118U00FwkOCS0103Response>  {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override           
	@Transactional(readOnly = true)
	public OCS0118U00FwkOCS0103Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0118U00FwkOCS0103Request request) throws Exception {
  	   	OcsaServiceProto.OCS0118U00FwkOCS0103Response.Builder response = OcsaServiceProto.OCS0118U00FwkOCS0103Response.newBuilder();
  	  List<ComboListItemInfo> list =  ocs0103Repository.getOCS0118U00FwkOCS0103Info(getHospitalCode(vertx, sessionId), request.getFind1());
  	  if(!CollectionUtils.isEmpty(list)){
  		for(ComboListItemInfo item : list){
  		  OcsaModelProto.OCS0118U00FwkOCS0103Info.Builder info = OcsaModelProto.OCS0118U00FwkOCS0103Info.newBuilder();
  		  if(!StringUtils.isEmpty(item.getCode())){
  			  info.setHangmogCode(item.getCode());
  		  }
  		  if(!StringUtils.isEmpty(item.getCodeName())){
			  info.setHangmogName(item.getCodeName());
		  }
  		response.addFwkOCS0103Info(info);
  		}
  	  }
	return response.build();
	}  

}
