package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur5025Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00grdCommentInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdCommentRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdCommentResponse;

@Service
@Scope("prototype")
public class NUR5020U00grdCommentHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00grdCommentRequest, NuriServiceProto.NUR5020U00grdCommentResponse> {
	
	@Resource
	private Nur5025Repository nur5025Repository;

	@Override
	public NUR5020U00grdCommentResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00grdCommentRequest request) throws Exception {
		
		NUR5020U00grdCommentResponse.Builder response = NUR5020U00grdCommentResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR5020U00grdCommentInfo> result = nur5025Repository.getNUR5020U00grdCommentInfo(hospCode, request.getDate(), request.getHoDong(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR5020U00grdCommentInfo item : result){
				NuriModelProto.NUR5020U00grdCommentInfo.Builder info = NuriModelProto.NUR5020U00grdCommentInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		
		return response.build();
	}

}
