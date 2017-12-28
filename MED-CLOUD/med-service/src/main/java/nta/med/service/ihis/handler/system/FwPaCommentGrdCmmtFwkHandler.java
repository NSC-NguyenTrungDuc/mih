package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.data.model.ihis.ocso.FwPaCommentGrdCmmtFwkInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.FwPaCommentGrdCmmtFwkRequest;
import nta.med.service.ihis.proto.SystemServiceProto.FwPaCommentGrdCmmtFwkResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class FwPaCommentGrdCmmtFwkHandler
	extends ScreenHandler<SystemServiceProto.FwPaCommentGrdCmmtFwkRequest, SystemServiceProto.FwPaCommentGrdCmmtFwkResponse> {                     
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public FwPaCommentGrdCmmtFwkResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			FwPaCommentGrdCmmtFwkRequest request) throws Exception {                                                                
  	   	SystemServiceProto.FwPaCommentGrdCmmtFwkResponse.Builder response = SystemServiceProto.FwPaCommentGrdCmmtFwkResponse.newBuilder();                      
		Double fkocs = CommonUtils.parseDouble(request.getFkocs());
		List<FwPaCommentGrdCmmtFwkInfo> listComment = out0106Repository.getFwBizObjectXPaCommentLayCmmtGubunfwkInfo(getHospitalCode(vertx, sessionId),request.getBunho(),
				request.getCmmtGubun(),request.getJundalTable(),request.getJundalPart(), fkocs);
		if(!CollectionUtils.isEmpty(listComment)){
			for(FwPaCommentGrdCmmtFwkInfo item : listComment){
				SystemModelProto.FwPaCommentGrdCmmtFwkInfo.Builder info = SystemModelProto.FwPaCommentGrdCmmtFwkInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getFkocs() != null) {
					info.setFkocs(String.format("%.0f",item.getFkocs()));
				}
				if (item.getSer() != null) {
					info.setSer(String.format("%.0f",item.getSer()));
				}
				response.addGrdCmmtFwkItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}