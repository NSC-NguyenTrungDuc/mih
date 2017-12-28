package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur5200;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur5200Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR5020U00SaveNur5200Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR5020U00SaveNur5200Handler
		extends ScreenHandler<NuriServiceProto.NUR5020U00SaveNur5200Request, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur5200Repository nur5200Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR5020U00SaveNur5200Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		String hoDong = request.getHoDong();
		Date nurWrdt = DateUtil.toDate(request.getNurWrdt(), DateUtil.PATTERN_YYMMDD);
		String confirmYn = request.getConfirmYn();
		Date sysDate = Calendar.getInstance().getTime();
		
		List<Nur5200> items = nur5200Repository.findByHospCodeHoDongNurWrdtSeq(hospCode, hoDong, nurWrdt);
		if(!CollectionUtils.isEmpty(items)){
			Nur5200 nur5200 = items.get(0);
			if("N".equals(nur5200.getConfirmYn())){
				nur5200.setUpdDate(sysDate);
				nur5200.setUpdId(userId);
				nur5200.setConfirmYn(confirmYn);
				
				nur5200Repository.save(nur5200);
			}
		} else {
			Nur5200 nur5200 = new Nur5200();	
			nur5200.setSysDate(sysDate);
			nur5200.setSysId(userId);
			nur5200.setUpdDate(sysDate);
			nur5200.setUpdId(userId);
			nur5200.setHospCode(hospCode);
			nur5200.setHoDong(hoDong);
			nur5200.setNurWrdt(nurWrdt);
			nur5200.setConfirmYn(confirmYn);
			nur5200.setSeq(1.0);
			
			nur5200Repository.save(nur5200);
		}
		
		response.setResult(true);
		return response.build();
	}

}
