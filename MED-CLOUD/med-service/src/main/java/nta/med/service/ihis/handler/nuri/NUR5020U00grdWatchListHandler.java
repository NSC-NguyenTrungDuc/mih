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
import nta.med.data.dao.medi.nur.Nur5024Repository;
import nta.med.data.model.ihis.nuri.NUR5020U00grdWatchListInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdWatchListRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00grdWatchListResponse;

@Service
@Scope("prototype")
public class NUR5020U00grdWatchListHandler extends
		ScreenHandler<NuriServiceProto.NUR5020U00grdWatchListRequest, NuriServiceProto.NUR5020U00grdWatchListResponse> {
	
	@Resource
	private Nur5024Repository nur5024Repository;

	@Override
	public NUR5020U00grdWatchListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00grdWatchListRequest request) throws Exception {
		
		NUR5020U00grdWatchListResponse.Builder response = NUR5020U00grdWatchListResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR5020U00grdWatchListInfo> result = nur5024Repository.getNUR5020U00grdWatchListInfo(hospCode, language, request.getDate(), request.getHoDong(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR5020U00grdWatchListInfo item : result){
				NuriModelProto.NUR5020U00grdWatchListInfo.Builder info = NuriModelProto.NUR5020U00grdWatchListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		
		return null;
	}

}
