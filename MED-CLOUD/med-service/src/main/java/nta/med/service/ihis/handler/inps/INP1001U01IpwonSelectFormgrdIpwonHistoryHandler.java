package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001U01IpwonSelectFormgrdIpwonHistoryInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01IpwonSelectFormgrdIpwonHistoryRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01IpwonSelectFormgrdIpwonHistoryResponse;

@Service                                                                                                          
@Scope("prototype")
public class INP1001U01IpwonSelectFormgrdIpwonHistoryHandler extends ScreenHandler<InpsServiceProto.INP1001U01IpwonSelectFormgrdIpwonHistoryRequest, InpsServiceProto.INP1001U01IpwonSelectFormgrdIpwonHistoryResponse>{
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1001U01IpwonSelectFormgrdIpwonHistoryResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP1001U01IpwonSelectFormgrdIpwonHistoryRequest request) throws Exception {
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);  
		InpsServiceProto.INP1001U01IpwonSelectFormgrdIpwonHistoryResponse.Builder response = InpsServiceProto.INP1001U01IpwonSelectFormgrdIpwonHistoryResponse.newBuilder();
		List<INP1001U01IpwonSelectFormgrdIpwonHistoryInfo> list = inp1001Repository.getINP1001U01IpwonSelectFormgrdIpwonHistoryInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), startNum, CommonUtils.parseInteger(offset));
		if (!CollectionUtils.isEmpty(list)) {
			for (INP1001U01IpwonSelectFormgrdIpwonHistoryInfo item : list) {
				InpsModelProto.INP1001U01IpwonSelectFormgrdIpwonHistoryInfo.Builder info = InpsModelProto.INP1001U01IpwonSelectFormgrdIpwonHistoryInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}
}
