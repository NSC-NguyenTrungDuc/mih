package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0170Repository;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.model.ihis.system.SpeciFicCommentInputYnInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.SpeciFicCommentInputYnRequest;
import nta.med.service.ihis.proto.SystemServiceProto.SpeciFicCommentInputYnResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SpeciFicCommentInputYnHandler extends ScreenHandler<SystemServiceProto.SpeciFicCommentInputYnRequest, SystemServiceProto.SpeciFicCommentInputYnResponse> {                     
	@Resource                                                                                                       
	private Ocs0170Repository ocs0170Repository;                                                                    
	@Resource
	private Xrt0001Repository xrt0001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SpeciFicCommentInputYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SpeciFicCommentInputYnRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.SpeciFicCommentInputYnResponse.Builder response = SystemServiceProto.SpeciFicCommentInputYnResponse.newBuilder();      
      	String hospCode = getHospitalCode(vertx, sessionId);
		List<SpeciFicCommentInputYnInfo> listComment = ocs0170Repository.getSpeciFicCommentInputYnInfo(hospCode,request.getHanmogCode());
		if(!CollectionUtils.isEmpty(listComment)){
			String tableId = listComment.get(0).getTableId();
			String colId = listComment.get(0).getColId();
			String getYn = xrt0001Repository.getSpeciFicCommentInputYnRequest(hospCode, tableId, colId,CommonUtils.parseDouble(request.getPkocskey()));
			if(!StringUtils.isEmpty(getYn)){
				response.setYValue(getYn);
			}
		}else{
			response.setCheckTableRow(false);
		}
		return response.build();
	}
}