package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.Ocs0103Q00LoadOcs0103ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.Ocs0103Q00LoadOcs0103Request;
import nta.med.service.ihis.proto.OcsaServiceProto.Ocs0103Q00LoadOcs0103Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class Ocs0103Q00LoadOcs0103Handler extends ScreenHandler<OcsaServiceProto.Ocs0103Q00LoadOcs0103Request, OcsaServiceProto.Ocs0103Q00LoadOcs0103Response> {                     
	private static final Log LOGGER = LogFactory.getLog(Ocs0103Q00LoadOcs0103Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public Ocs0103Q00LoadOcs0103Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			Ocs0103Q00LoadOcs0103Request request) throws Exception {                                                                   
  	   	OcsaServiceProto.Ocs0103Q00LoadOcs0103Response.Builder response = OcsaServiceProto.Ocs0103Q00LoadOcs0103Response.newBuilder();                      
  	   	String offset = request.getOffSet();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
  	   	List<Ocs0103Q00LoadOcs0103ListItemInfo> listItem = ocs0103Repository.getOcs0103Q00LoadOcs0103(getHospitalCode(vertx, sessionId), request.getQueryCode(),
				request.getOrderGubun(), request.getChildYn(), request.getInputTab(), startNum, CommonUtils.parseInteger(offset), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listItem)){
    		for(Ocs0103Q00LoadOcs0103ListItemInfo item :listItem){
    			OcsaModelProto.Ocs0103Q00LoadOcs0103ListItemInfo.Builder info =OcsaModelProto.Ocs0103Q00LoadOcs0103ListItemInfo.newBuilder();
    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			if (item.getSeq() != null) {
    				info.setSeq(String.format("%.0f",item.getSeq()));
    			}
				response.addListInfo(info);
    		}
    	}
		return response.build();
	}
}
