package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridBoheomInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT0101U02GridBoheomHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GridBoheomRequest, NuroServiceProto.NuroOUT0101U02GridBoheomResponse>{
	 private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GridBoheomHandler.class);
	@Resource
	 Out0101Repository out0101Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GridBoheomResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GridBoheomRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GridBoheomResponse.Builder response = NuroServiceProto.NuroOUT0101U02GridBoheomResponse.newBuilder();
		List<NuroOUT0101U02GridBoheomInfo> listNuroOUT0101U02GridBoheomInfo = out0101Repository.getNuroOUT0101U02GridBoheomInfo(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getPatientCode());
		if(listNuroOUT0101U02GridBoheomInfo != null && !listNuroOUT0101U02GridBoheomInfo.isEmpty()){
			for(NuroOUT0101U02GridBoheomInfo item : listNuroOUT0101U02GridBoheomInfo){
				NuroModelProto.NuroOUT0101U02GridBoheomInfo.Builder nuroOUT0101U02GridBoheomInfo = NuroModelProto.NuroOUT0101U02GridBoheomInfo.newBuilder();	
				BeanUtils.copyProperties(item, nuroOUT0101U02GridBoheomInfo, getLanguage(vertx, sessionId));
				response.addGridBoheomItem(nuroOUT0101U02GridBoheomInfo);
			}
		}
		return response.build();
	}

}
