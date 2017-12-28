package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur6005;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur6005Repository;
import nta.med.service.ihis.proto.NuriModelProto.NUR6005U00grdNUR6005Info;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR6005U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR6005U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR6005U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(NUR6005U00SaveLayoutHandler.class);
	
	@Resource
	private Nur6005Repository nur6005Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR6005U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		Date sysDate = Calendar.getInstance().getTime();
		
		List<NUR6005U00grdNUR6005Info> infos = request.getGrdnur6005InfoList();
		for (NUR6005U00grdNUR6005Info info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				List<Nur6005> items = nur6005Repository.findByHospCodeBunhoStartDate(getHospitalCode(vertx, sessionId),
						info.getBunho(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				
				if(!CollectionUtils.isEmpty(items)){
					LOGGER.info("DUPLICATE KEY NUR6005 !!!");
					response.setResult(false);
					return response.build();
				}
				
				Nur6005 nur6005 = new Nur6005();
				nur6005.setSysDate(sysDate);
				nur6005.setSysId(userId);
				nur6005.setUpdDate(sysDate);
				nur6005.setUpdId(userId);
				nur6005.setHospCode(hospCode);
				nur6005.setMetressGubun(info.getMetressGubun());
				nur6005.setBunho(info.getBunho());
				nur6005.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				nur6005.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
				nur6005.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
				nur6005.setDataGubun("U");
				
				nur6005Repository.save(nur6005);
			} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				List<Nur6005> items = nur6005Repository.findByHospCodeBunhoStartDate(getHospitalCode(vertx, sessionId),
						info.getBunho(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				if(!CollectionUtils.isEmpty(items)){
					Nur6005 nur6005 = items.get(0);
					
					nur6005.setUpdDate(sysDate);
					nur6005.setUpdId(userId);
					nur6005.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
					nur6005.setMetressGubun(info.getMetressGubun());
					nur6005.setDataGubun("U");
					
					nur6005Repository.save(nur6005);
				}
				
			} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				List<Nur6005> items = nur6005Repository.findByHospCodeBunhoStartDate(getHospitalCode(vertx, sessionId),
						info.getBunho(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				if(!CollectionUtils.isEmpty(items)){
					Nur6005 nur6005 = items.get(0);
					nur6005Repository.delete(nur6005);
				}
			}
			
		}
		
		response.setResult(true);
		return response.build();
	}

}
