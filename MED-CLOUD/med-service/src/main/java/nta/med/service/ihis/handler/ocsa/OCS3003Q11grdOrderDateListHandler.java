package nta.med.service.ihis.handler.ocsa;

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
import nta.med.data.dao.medi.nut.Nut0001Repository;
import nta.med.data.model.ihis.ocsa.OCS3003Q11grdOrderDateListInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q11grdOrderDateListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS3003Q11grdOrderDateListResponse;

@Service                                                                                                          
@Scope("prototype") 
public class OCS3003Q11grdOrderDateListHandler extends ScreenHandler<OcsaServiceProto.OCS3003Q11grdOrderDateListRequest, OcsaServiceProto.OCS3003Q11grdOrderDateListResponse>{
	@Resource
	private Nut0001Repository nut0001Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OCS3003Q11grdOrderDateListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS3003Q11grdOrderDateListRequest request) throws Exception {
		OcsaServiceProto.OCS3003Q11grdOrderDateListResponse.Builder response = OcsaServiceProto.OCS3003Q11grdOrderDateListResponse.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);   
        List<OCS3003Q11grdOrderDateListInfo> list = nut0001Repository.getOCS3003Q11grdOrderDateListInfo(getHospitalCode(vertx, sessionId), request.getBunho(), startNum, CommonUtils.parseInteger(request.getOffset()));
        if (!CollectionUtils.isEmpty(list)) {
        	for (OCS3003Q11grdOrderDateListInfo item : list) {
				OcsaModelProto.OCS3003Q11grdOrderDateListInfo.Builder info = OcsaModelProto.OCS3003Q11grdOrderDateListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(info);
			}
        }
		return response.build();
	}

}
