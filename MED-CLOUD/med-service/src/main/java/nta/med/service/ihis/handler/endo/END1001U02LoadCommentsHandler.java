package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdCommentInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02LoadCommentsRequest;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02LoadCommentsResponse;

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
public class END1001U02LoadCommentsHandler extends ScreenHandler<EndoServiceProto.END1001U02LoadCommentsRequest, EndoServiceProto.END1001U02LoadCommentsResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02LoadCommentsHandler.class);                                    
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;  

	@Override
	@Transactional(readOnly = true)
	public END1001U02LoadCommentsResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			END1001U02LoadCommentsRequest request) throws Exception {
		EndoServiceProto.END1001U02LoadCommentsResponse.Builder response = EndoServiceProto.END1001U02LoadCommentsResponse.newBuilder();
		//XRT1002U00GrdCommentInfo cmt1
		List<XRT1002U00GrdCommentInfo> listCmt1 = out0106Repository.getXRT1002U00GrdComment(getHospitalCode(vertx, sessionId), request.getBunho(), "B", null);
		if(!CollectionUtils.isEmpty(listCmt1)){
			for(XRT1002U00GrdCommentInfo item : listCmt1){
				EndoModelProto.END1001U02StrInfo.Builder info = EndoModelProto.END1001U02StrInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getComments())){
					info.setValue(item.getComments());
				}
				response.addGrdcomment1Item(info);
			}
		}
		//XRT1002U00GrdCommentInfo cmt2
		List<XRT1002U00GrdCommentInfo> listCmt2 = out0106Repository.getXRT1002U00GrdComment(getHospitalCode(vertx, sessionId), request.getBunho(), "P", "PFE");
		if(!CollectionUtils.isEmpty(listCmt2)){
			for(XRT1002U00GrdCommentInfo item : listCmt2){
				EndoModelProto.END1001U02StrInfo.Builder info = EndoModelProto.END1001U02StrInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getComments())){
					info.setValue(item.getComments());
				}
				response.addGrdcomment2Item(info);
			}
		}
		//END1001U02LayOrderDateInfo 
		List<String> listLayOrderDate = out0106Repository.getXRT1002U00LayOrderDate(getHospitalCode(vertx, sessionId), "PFE", request.getBunho());
		if(!CollectionUtils.isEmpty(listLayOrderDate)){
			for(String item : listLayOrderDate){
				EndoModelProto.END1001U02LayOrderDateInfo.Builder info = EndoModelProto.END1001U02LayOrderDateInfo.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setOrderDate(item);
				}
				response.addLayorderdateItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}