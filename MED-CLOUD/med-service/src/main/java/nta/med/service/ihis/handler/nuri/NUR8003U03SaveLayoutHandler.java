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

import nta.med.core.domain.nur.Nur8003;
import nta.med.core.domain.nur.Nur8033;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur8003Repository;
import nta.med.data.dao.medi.nur.Nur8033Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR8003U03SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR8003U03SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR8003U03SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur8003Repository nur8003Repository;
	
	@Resource
	private Nur8033Repository nur8033Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR8003U03SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String bunho = request.getBunho();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		String userId = getUserId(vertx, sessionId);
		Date writeDate = DateUtil.toDate(request.getWriteDate(), DateUtil.PATTERN_YYMMDD);
		String hoDong = request.getHoDong();
		Date sysDate = Calendar.getInstance().getTime();
		
		List<NuriModelProto.NUR8003U03GrdAInfo> infos = request.getSaveListList();
		for (NuriModelProto.NUR8003U03GrdAInfo info : infos) {
			if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				
				// handle NUR8003
				List<Nur8003> masterList = nur8003Repository.findByHospCodeBunhoWriteDateFirstGubunGrCode(hospCode,
						bunho, writeDate, info.getFirstGubun(), info.getGrCode());
				if(CollectionUtils.isEmpty(masterList)){
					Nur8003 nur8003 = new Nur8003();
					nur8003.setSysId(userId);
					nur8003.setSysDate(sysDate);
					nur8003.setUpdId(userId);
					nur8003.setUpdDate(sysDate);
					nur8003.setHospCode(hospCode);
					nur8003.setBunho(bunho);
					nur8003.setFkinp1001(fkinp1001);
					nur8003.setWriteDate(writeDate);
					nur8003.setFirstGubun(info.getFirstGubun());
					nur8003.setGrCode(info.getGrCode());
					nur8003.setWriteHodong(hoDong);
					
					nur8003Repository.save(nur8003);
				} else {
					Nur8003 nur8003 = masterList.get(0);
					nur8003.setUpdId(userId);
					nur8003.setUpdDate(sysDate);
					nur8003.setWriteHodong(hoDong);
					
					nur8003Repository.save(nur8003);
				}
				
				// handle NUR8033
				List<Nur8033> detailList = nur8033Repository.findByHospCodeBunhoWriteDateFirstGubunGrCode(hospCode,
						bunho, writeDate, info.getFirstGubun(), info.getGrCode(), info.getRsCode());
				
				if(CollectionUtils.isEmpty(detailList)){
					Nur8033 nur8033 = new Nur8033();
					nur8033.setSysId(userId);                    
					nur8033.setSysDate(sysDate);                 
					nur8033.setUpdId(userId);                    
					nur8033.setUpdDate(sysDate);                 
					nur8033.setHospCode(hospCode);               
					nur8033.setBunho(bunho);                     
					nur8033.setFkinp1001(fkinp1001);             
					nur8033.setWriteDate(writeDate);             
					nur8033.setFirstGubun(info.getFirstGubun()); 
					nur8033.setGrCode(info.getGrCode());         
					nur8033.setRsCode(info.getRsCode());
					nur8033.setSmCode(info.getSmCode());
					nur8033.setSmDetail(info.getSmDetail());
					nur8033.setSumGubun(info.getSumGubun());
					nur8033.setNurPoint(CommonUtils.parseDouble(info.getNurPoint()));
					nur8033.setNewSmCode(info.getNewSmCode());
					nur8033.setNewSmDetail(info.getNewSmDetail());
					nur8033.setNewNurPoint(CommonUtils.parseDouble(info.getNewNurPoint()));
					nur8033.setWriteHodong(hoDong);
					
					nur8033Repository.save(nur8033);
				} else {
					Nur8033 nur8033 = detailList.get(0);
					nur8033.setUpdId(userId);                    
					nur8033.setUpdDate(sysDate);
					nur8033.setWriteHodong(hoDong);
					nur8033.setSmCode(info.getSmCode());
					nur8033.setSmDetail(info.getSmDetail());
					nur8033.setNurPoint(CommonUtils.parseDouble(info.getNurPoint()));
					nur8033.setNewSmCode(info.getNewSmCode());
					nur8033.setNewSmDetail(info.getNewSmDetail());
					nur8033.setNewNurPoint(CommonUtils.parseDouble(info.getNewNurPoint()));
					
					nur8033Repository.save(nur8033);
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}

}
