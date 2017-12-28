package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur4005;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur4005Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR4005U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR4005U01SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR4005U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur4005Repository nur4005Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR4005U01SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Date sysDate = Calendar.getInstance().getTime();
		
		List<NuriModelProto.NUR4005U01GrdNUR4005Info> infos = request.getGrdListList();
		
		for (NuriModelProto.NUR4005U01GrdNUR4005Info info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur4005 nur4005 = new Nur4005();
				nur4005.setSysDate(sysDate);
				nur4005.setSysId(userId);
				nur4005.setUpdDate(sysDate);
				nur4005.setUpdId(userId);
				nur4005.setHospCode(hospCode);
				nur4005.setFknur4001(CommonUtils.parseDouble(info.getFknur4001()));
				nur4005.setGubun(info.getGubun());
				nur4005.setReserDate(DateUtil.toDate(info.getReserDate(), DateUtil.PATTERN_YYMMDD));
				nur4005.setValuContents(info.getValuContents());
				nur4005.setValuDate(DateUtil.toDate(info.getValuDate(), DateUtil.PATTERN_YYMMDD));
				nur4005.setValuer(info.getValuer());
				
				nur4005Repository.save(nur4005);
			} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur4005Repository.updateByHospCodeFknur4001RerserDate(userId, info.getGubun(), info.getValuContents(), DateUtil.toDate(info.getValuDate(), DateUtil.PATTERN_YYMMDD)
						, info.getValuer(), hospCode, CommonUtils.parseDouble(info.getFknur4001()), DateUtil.toDate(info.getReserDate(), DateUtil.PATTERN_YYMMDD));
			}else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur4005Repository.deleteByHospCodeFknur4001RerserDate(hospCode,
						CommonUtils.parseDouble(info.getFknur4001()),
						DateUtil.toDate(info.getReserDate(), DateUtil.PATTERN_YYMMDD));
			}
		}
		
		response.setResult(true);
		return response.build();
	}

	
}
