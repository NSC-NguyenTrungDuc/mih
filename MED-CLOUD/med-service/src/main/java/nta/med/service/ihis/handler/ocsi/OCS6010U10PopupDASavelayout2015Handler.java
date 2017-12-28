package nta.med.service.ihis.handler.ocsi;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs2015;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupDASavelayout2015Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupDASavelayout2015Handler extends
		ScreenHandler<OcsiServiceProto.OCS6010U10PopupDASavelayout2015Request, SystemServiceProto.UpdateResponse> {

	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupDASavelayout2015Request request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Double fkocs2005 = CommonUtils.parseDouble(request.getFkocs2005());
		
		List<OcsiModelProto.OCS6010U10PopupTAgrdOCS2015Info> infos = request.getGrdSaveList();
		if(CollectionUtils.isEmpty(infos)){
			throw new ExecutionException(response.setResult(false).build());
		}
		
		for (OcsiModelProto.OCS6010U10PopupTAgrdOCS2015Info info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowStage())){
				double seq = ocs2015Repository.getNextSeqOcs2015InFrmDrugAting(hospCode
						, info.getBunho()
						, CommonUtils.parseDouble(info.getFkinp1001())
						, DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)
						, info.getInputGubun()
						, CommonUtils.parseDouble(info.getPkSeq())
						, DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD));
				
				Ocs2015 ocs2015 = new Ocs2015();
				Date sysDate = Calendar.getInstance().getTime();
				
				ocs2015.setSysDate(sysDate);
				ocs2015.setSysId(userId);
				ocs2015.setUpdDate(sysDate);
				ocs2015.setInputId(info.getInputId());
				ocs2015.setHospCode(hospCode);
				ocs2015.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
				ocs2015.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
				ocs2015.setInputGubun(info.getInputGubun());
				ocs2015.setPkocs2015(CommonUtils.parseDouble(info.getPkocs2015()));
				ocs2015.setBunho(info.getBunho());
				ocs2015.setPkSeq(CommonUtils.parseDouble(info.getPkSeq()));
				ocs2015.setSeq(seq);
				ocs2015.setDrtDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
				ocs2015.setActDate(DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD));
				ocs2015.setActId(info.getActId());
				ocs2015.setActResultCode(info.getActResultCode());
				ocs2015.setActResultText(info.getActResultText());
				ocs2015.setSuryang(null);	
				ocs2015.setDirectGubun(null);
				ocs2015.setFkocs2005(fkocs2005);
				
				ocs2015Repository.save(ocs2015);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowStage())){
				ocs2015Repository.updateOCS6010U10(hospCode
						, CommonUtils.parseDouble(info.getPkocs2015())
						, userId
						, DateUtil.toDate(info.getActDate(), DateUtil.PATTERN_YYMMDD)
						, info.getActId()
						, info.getActResultCode()
						, info.getActResultText());
			}
		}
		
		response.setResult(true);
		return response.build();
	}

}
