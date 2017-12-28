package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.data.model.ihis.nuri.NUR0101U00grdDetailInfo;
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
public class NUR0101U00grdDetailHandler extends ScreenHandler<NuriServiceProto.NUR0101U00grdDetailRequest, NuriServiceProto.NUR0101U00grdDetailResponse> {   
	
	@Resource                                   
	private Nur0101Repository nur0101Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR0101U00grdDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR0101U00grdDetailRequest request) throws Exception {
				
		NuriServiceProto.NUR0101U00grdDetailResponse.Builder response = NuriServiceProto.NUR0101U00grdDetailResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR0101U00grdDetailInfo> result = nur0101Repository.getNUR0101U00grdDetailInfo(hospCode, language, request.getCodeType(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR0101U00grdDetailInfo item : result){
				NuriModelProto.NUR0101U00grdDetailInfo.Builder info = NuriModelProto.NUR0101U00grdDetailInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		
		return response.build();
	}
}
