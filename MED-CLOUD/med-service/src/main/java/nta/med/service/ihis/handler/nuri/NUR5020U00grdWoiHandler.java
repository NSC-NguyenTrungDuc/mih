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
import nta.med.data.dao.medi.nur.Nur1014Repository;
import nta.med.data.dao.medi.nur.Nur5023Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00grdWoiInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdWoiRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdWoiResponse;

@Service
@Scope("prototype")
public class NUR5020U00grdWoiHandler
		extends ScreenHandler<NuriServiceProto.NUR5020U00grdWoiRequest, NuriServiceProto.NUR5020U00grdWoiResponse> {
	
	@Resource
	private Nur1014Repository nur1014Repository;
	
	@Resource
	private Nur5023Repository nur5023Repository;

	@Override
	public NUR5020U00grdWoiResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00grdWoiRequest request) throws Exception {

		NUR5020U00grdWoiResponse.Builder response = NUR5020U00grdWoiResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR5020U00grdWoiInfo> result;
		
		if(request.getQueryNumber().equals("1")){
			result = nur1014Repository.getNUR5020U00grdWoiInfo(hospCode, request.getHoDong(), request.getDate(), language, startNum, offset);
		}else{
			result = nur5023Repository.getNUR5020U00grdWoiInfoMode2(hospCode, language, request.getDate(), request.getHoDong(), startNum, offset);
		}
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR5020U00grdWoiInfo item : result){
				NuriModelProto.NUR5020U00grdWoiInfo.Builder info = NuriModelProto.NUR5020U00grdWoiInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if(item.getPknur5023() != ""){
					if (item.getPknur5023() != null) {
						info.setPknur5023(String.format("%.0f",CommonUtils.parseDouble(item.getPknur5023())));
					}
				}
				response.addGrdMasterItem(info);
			}
		}
		
		return response.build();
	}

}
