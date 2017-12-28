package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

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
public class InjsINJ1001U01CommentListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01CommentListRequest, InjsServiceProto.InjsINJ1001U01CommentListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(InjsINJ1001U01CommentListHandler.class);                                        
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;                                                                    

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01CommentListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01CommentListRequest request) throws Exception {
		InjsServiceProto.InjsINJ1001U01CommentListResponse.Builder response = InjsServiceProto.InjsINJ1001U01CommentListResponse.newBuilder(); 
		List<String> listComments =out0106Repository.findCommentsByBunhoAndCmmtGubun(getHospitalCode(vertx, sessionId), request.getBunho(), request.getCommtGubun());
		if(!CollectionUtils.isEmpty(listComments)){
			for(String item : listComments){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item)) {
					info.setDataValue(item);
				}
				response.addComments(info);
			}
		}
		return response.build();
	}                                                                                                                 
}