package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur6014Repository;
import nta.med.data.model.ihis.nuri.NUR6011U01grdImageInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01grdImageHandler extends ScreenHandler<NuriServiceProto.NUR6011U01grdImageRequest, NuriServiceProto.NUR6011U01grdImageResponse> {   
	
	@Resource                                   
	private Nur6014Repository nur6014Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01grdImageResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01grdImageRequest request) throws Exception {
				
		NuriServiceProto.NUR6011U01grdImageResponse.Builder response = NuriServiceProto.NUR6011U01grdImageResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR6011U01grdImageInfo> result = nur6014Repository.getNUR6011U01grdImageInfo(hospCode, request.getBunho(), request.getFromDate(), request.getBuwiGubun(),
						request.getAssessorDate(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR6011U01grdImageInfo item : result){
				NuriModelProto.NUR6011U01grdImageInfo.Builder info = NuriModelProto.NUR6011U01grdImageInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItems(info);
			}
		}
		
		return response.build();
	}
}
