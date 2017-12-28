package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.doc.Doc4003Repository;
import nta.med.data.model.ihis.ocsa.DOC4003U00GrdDOC4003Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.DOC4003U00GrdDOC4003Request;
import nta.med.service.ihis.proto.OcsaServiceProto.DOC4003U00GrdDOC4003Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class DOC4003U00GrdDOC4003Handler extends ScreenHandler<OcsaServiceProto.DOC4003U00GrdDOC4003Request,OcsaServiceProto.DOC4003U00GrdDOC4003Response>  {                     
	@Resource                                                                                                       
	private Doc4003Repository doc4003Repository;                                                                    
	                                                                                                                
	@Override                     
	@Transactional(readOnly = true)
	public DOC4003U00GrdDOC4003Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DOC4003U00GrdDOC4003Request request) throws Exception {
  	   	OcsaServiceProto.DOC4003U00GrdDOC4003Response.Builder response = OcsaServiceProto.DOC4003U00GrdDOC4003Response.newBuilder();
  	  List<DOC4003U00GrdDOC4003Info> list =  doc4003Repository.getDOC4003U00GrdDOC4003Info(getHospitalCode(vertx, sessionId), request.getBunho());
  	  if(!CollectionUtils.isEmpty(list)){
  		for(DOC4003U00GrdDOC4003Info item : list){
  		  OcsaModelProto.DOC4003U00GrdDOC4003Info.Builder info = OcsaModelProto.DOC4003U00GrdDOC4003Info.newBuilder();
  		  BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
  		  response.addDoc4003Item(info);
  		}
  	  }
	return response.build();
	}  

}
