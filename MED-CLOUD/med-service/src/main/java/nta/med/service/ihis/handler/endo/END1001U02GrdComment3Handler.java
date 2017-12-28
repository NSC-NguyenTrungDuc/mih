package nta.med.service.ihis.handler.endo;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.model.ihis.endo.END1001U02GrdComment3Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class END1001U02GrdComment3Handler extends ScreenHandler<EndoServiceProto.END1001U02GrdComment3Request, EndoServiceProto.END1001U02GrdComment3Response> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02GrdComment3Handler.class);                                    
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;   
	
	@Override
	public boolean isValid(EndoServiceProto.END1001U02GrdComment3Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public EndoServiceProto.END1001U02GrdComment3Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02GrdComment3Request request) throws Exception {
		EndoServiceProto.END1001U02GrdComment3Response.Builder response = EndoServiceProto.END1001U02GrdComment3Response.newBuilder(); 
		Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		List<END1001U02GrdComment3Info> listResult = out0106Repository.getEND1001U02GrdComment3Info(getHospitalCode(vertx, sessionId), request.getBunho(), orderDate);
		if(!CollectionUtils.isEmpty(listResult)){
			for(END1001U02GrdComment3Info item : listResult){
				EndoModelProto.END1001U02GrdComment3Info.Builder info = EndoModelProto.END1001U02GrdComment3Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addGrdComment3Item(info);
			}
		}
		return response.build();
	}                                                                                                                 
}