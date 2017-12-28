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
import nta.med.data.dao.medi.nur.Nur5027Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00grdNURCntInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdNURCntRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdNURCntResponse;

@Service
@Scope("prototype")
public class NUR5020U00grdNURCntHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00grdNURCntRequest, NuriServiceProto.NUR5020U00grdNURCntResponse> {
	
	@Resource
	private Nur5027Repository nur5027Repository;

	@Override
	public NUR5020U00grdNURCntResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00grdNURCntRequest request) throws Exception {
		NUR5020U00grdNURCntResponse.Builder response = NUR5020U00grdNURCntResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR5020U00grdNURCntInfo> result = nur5027Repository.getNUR5020U00grdNURCntInfo(request.getDate(), request.getHoDong(), hospCode, startNum, offset);
		if(!CollectionUtils.isEmpty(result)){
			for(NUR5020U00grdNURCntInfo item : result){
				NuriModelProto.NUR5020U00grdNURCntInfo.Builder info = NuriModelProto.NUR5020U00grdNURCntInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		
		return response.build();
	}

}
