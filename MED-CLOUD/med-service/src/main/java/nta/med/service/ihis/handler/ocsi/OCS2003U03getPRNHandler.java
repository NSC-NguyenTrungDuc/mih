package nta.med.service.ihis.handler.ocsi;

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
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.ocsi.OCS2003U03getPRNInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getPRNRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003U03getPRNResponse;

@Service
@Scope("prototype")
public class OCS2003U03getPRNHandler extends ScreenHandler<OcsiServiceProto.OCS2003U03getPRNRequest, OcsiServiceProto.OCS2003U03getPRNResponse>{
	@Resource
	private Ocs2003Repository ocs2003Repository;
		
	@Override
	@Transactional(readOnly=true)
	public OCS2003U03getPRNResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003U03getPRNRequest request) throws Exception {
		OcsiServiceProto.OCS2003U03getPRNResponse.Builder response = OcsiServiceProto.OCS2003U03getPRNResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<OCS2003U03getPRNInfo> layList;
		
		if(request.getNameControl().equals("serial")){
			layList = ocs2003Repository.getOCS2003U03getPRNInfoSerial(hospCode, language, request.getJubsuDate(), request.getDrgBunho(), request.getSerialText());
		}else if(request.getNameControl().equals("serial2003")){
			layList = ocs2003Repository.getOCS2003U03getPRNInfoSerial2003(hospCode, language, CommonUtils.parseDouble(request.getFkocs2003()), request.getSerialText());
		}else{
			layList = ocs2003Repository.getOCS2003U03getPRNInfoElse(hospCode, language, request.getJubsuDate(), request.getDrgBunho(), request.getSerialText());
		}
		
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003U03getPRNInfo item : layList){
				OcsiModelProto.OCS2003U03getPRNInfo.Builder info = OcsiModelProto.OCS2003U03getPRNInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListPRN(info);
			}
		}
		return response.build();
	}
}
