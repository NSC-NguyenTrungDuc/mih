package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdCommentInfo;
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
public class END1001U02GrdComment1Handler extends ScreenHandler<EndoServiceProto.END1001U02GrdComment1Request, EndoServiceProto.END1001U02GrdComment1Response> {                      
	private static final Log LOGGER = LogFactory.getLog(END1001U02GrdComment1Handler.class);                                    
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;                                                                    
	                                                                                                                

	@Override
	@Transactional(readOnly = true)
	public EndoServiceProto.END1001U02GrdComment1Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02GrdComment1Request request) throws Exception {
		EndoServiceProto.END1001U02GrdComment1Response.Builder response = EndoServiceProto.END1001U02GrdComment1Response.newBuilder();
		List<XRT1002U00GrdCommentInfo> listResult = out0106Repository.getXRT1002U00GrdComment(getHospitalCode(vertx, sessionId), request.getBunho(), "B", null);
		if(!CollectionUtils.isEmpty(listResult)){
			for(XRT1002U00GrdCommentInfo item : listResult){
				EndoModelProto.END1001U02StrInfo.Builder info = EndoModelProto.END1001U02StrInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getComments())){
					info.setValue(item.getComments());
				}
				response.addGrdComment1Item(info);
			}
		}
		return response.build();
	}                                                                                                                 
}