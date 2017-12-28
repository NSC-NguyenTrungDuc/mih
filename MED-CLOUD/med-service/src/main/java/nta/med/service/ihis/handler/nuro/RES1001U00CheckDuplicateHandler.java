package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.NuroModelProto.RES1001U00SaveLayoutItemInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00CheckDuplicateRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U00CheckDuplicateResponse;

@Service
@Scope("prototype")
public class RES1001U00CheckDuplicateHandler extends ScreenHandler<NuroServiceProto.RES1001U00CheckDuplicateRequest, NuroServiceProto.RES1001U00CheckDuplicateResponse>{
	private static final Log logger = LogFactory.getLog(RES1001U00CheckDuplicateHandler.class);
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public RES1001U00CheckDuplicateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			RES1001U00CheckDuplicateRequest request) throws Exception {
		NuroServiceProto.RES1001U00CheckDuplicateResponse.Builder response = NuroServiceProto.RES1001U00CheckDuplicateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		boolean isOtherClinic = false;
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherClinic = true;
		}
		for(RES1001U00SaveLayoutItemInfo info : request.getInputInfoList()){
			// check duplicate
			List<ComboListItemInfo> listDoctorName = out1001Repository.getRES1001U00CheckDuplicate(hospCode, sessionHospCode,
					info.getBunho(), info.getGwa(), info.getJinryoPreDate(), info.getJinryoPreTime(), language,
					isOtherClinic);
			if (!CollectionUtils.isEmpty(listDoctorName)) {
				if(!StringUtils.isEmpty(listDoctorName.get(0).getCode())){
					response.setDoctorName(listDoctorName.get(0).getCode());
				}
				if(!StringUtils.isEmpty(listDoctorName.get(0).getCodeName())){
					response.setGwaName(listDoctorName.get(0).getCodeName());
				}
				response.setDuplicateResult("1");
				break;
			}else{
				response.setDuplicateResult("0");
			}
		}
		return response.build();
	}

}
