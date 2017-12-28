package nta.med.service.ihis.handler.ocsi;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs2016;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDASavelayout2016Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupDASavelayout2016Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupDASavelayout2016Request, SystemServiceProto.UpdateResponse> {

	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupDASavelayout2016Request request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		List<OcsiModelProto.OCS6010U10PopupTAgrdOCS2016Info> infos = request.getGrdSaveList();
		if(CollectionUtils.isEmpty(infos)){
			response.setResult(false);
			return response.build();
		}
		
		for (OcsiModelProto.OCS6010U10PopupTAgrdOCS2016Info info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowStage())){
				String pkocs2016 = commonRepository.getNextVal("OCS2016_SEQ");
				Double seq = ocs2016Repository.getMaxSeqOCS6010U10(getHospitalCode(vertx, sessionId), info.getFkocs2015());
				Date sysDate = Calendar.getInstance().getTime();
				
				Ocs2016 ocs2016 = new Ocs2016();
				ocs2016.setSysDate(sysDate);
				ocs2016.setSysId(getUserId(vertx, sessionId));
				ocs2016.setHospCode(getHospitalCode(vertx, sessionId));
				ocs2016.setPkocs2016(CommonUtils.parseDouble(pkocs2016));
				ocs2016.setFkocs2015(CommonUtils.parseDouble(info.getFkocs2015()));
				ocs2016.setSeq(seq);
				ocs2016.setHangmogCode(info.getHangmogCode());
				ocs2016.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
				ocs2016.setNalsu(CommonUtils.parseDouble(info.getNalsu()));
				ocs2016.setOrdDanui(info.getOrdDanui());
				ocs2016.setBogyongCode(info.getBogyongCode());
				ocs2016.setJusaCode(info.getJusaCode());
				ocs2016.setJusaSpdGubun(info.getJusaSpdGubun());
				ocs2016.setDv(CommonUtils.parseDouble(info.getDv()));
				ocs2016.setDvTime(info.getDvTime());
				ocs2016.setTimeGubun(null);	//TODO
				ocs2016.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
				ocs2016.setBomYn(info.getBomYn());
				
				ocs2016Repository.save(ocs2016);
			}
		}
		
		response.setResult(true);
		return response.build();
	}

}
