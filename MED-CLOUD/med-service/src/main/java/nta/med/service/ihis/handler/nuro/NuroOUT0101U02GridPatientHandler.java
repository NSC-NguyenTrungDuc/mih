package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridPatientInfo;
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
public class NuroOUT0101U02GridPatientHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GridPatientRequest, NuroServiceProto. NuroOUT0101U02GridPatientResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GridPatientHandler.class);
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto. NuroOUT0101U02GridPatientResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GridPatientRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GridPatientResponse.Builder response = NuroServiceProto.NuroOUT0101U02GridPatientResponse.newBuilder();
		List<NuroOUT0101U02GridPatientInfo> listNuroOUT0101U02GridPatientInfo = out0101Repository.getNuroOUT0101U02GridPatientInfo(getHospitalCode(vertx, sessionId), request.getPatientCode(), getLanguage(vertx, sessionId));
		if(listNuroOUT0101U02GridPatientInfo != null && !listNuroOUT0101U02GridPatientInfo.isEmpty()){
			for(NuroOUT0101U02GridPatientInfo item : listNuroOUT0101U02GridPatientInfo){
				NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder nuroGridPatientInfo = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder();
				BeanUtils.copyProperties(item, listNuroOUT0101U02GridPatientInfo, getLanguage(vertx, sessionId));
				response.addGridPatienItem(nuroGridPatientInfo);
			}
		}
		return response.build();
	}

}
