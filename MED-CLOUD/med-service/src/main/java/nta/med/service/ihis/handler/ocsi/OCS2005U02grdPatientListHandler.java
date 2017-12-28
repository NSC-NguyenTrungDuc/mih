package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.ocsi.OCS2005U02grdPatientListInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02grdPatientListRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02grdPatientListResponse;

@Service
@Scope("prototype")
public class OCS2005U02grdPatientListHandler extends ScreenHandler<OcsiServiceProto.OCS2005U02grdPatientListRequest, OcsiServiceProto.OCS2005U02grdPatientListResponse>{
	@Resource
	private Out0101Repository out0101Reporisoty;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U02grdPatientListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02grdPatientListRequest request) throws Exception{
		OcsiServiceProto.OCS2005U02grdPatientListResponse.Builder response = OcsiServiceProto.OCS2005U02grdPatientListResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<OCS2005U02grdPatientListInfo> result = out0101Reporisoty.getOCS2005U02grdPatientListInfo(hospCode, request.getOrderDate(), language, request.getFInputGubun(),
				request.getBunho(), request.getHoDong(), request.getHoCode(), request.getJaewonYn(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(OCS2005U02grdPatientListInfo item : result){
				OcsiModelProto.OCS2005U02grdPatientListInfo.Builder info = OcsiModelProto.OCS2005U02grdPatientListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdMasterItem(info);
			}
		}
		return response.build();
	}
	

}
