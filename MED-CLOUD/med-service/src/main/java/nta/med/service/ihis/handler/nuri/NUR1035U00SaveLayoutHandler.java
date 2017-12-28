package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur1035;
import nta.med.core.domain.nur.Nur1036;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1035Repository;
import nta.med.data.dao.medi.nur.Nur1036Repository;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1035U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR1035U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource                                   
	private Nur1035Repository nur1035Repository;
	
	@Resource                                   
	private Nur1036Repository nur1036Repository;
	
	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1035U00SaveLayoutRequest request) throws Exception {
				
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		String bunho = request.getBunho();
		
		List<NuriModelProto.NUR1035U00grdNUR1035Info> grdNur1035 = request.getGrdnur1035InfoList();
		List<NuriModelProto.NUR1035U00grdNUR1036Info> grdNur1036 = request.getGrdnur1036InfoList();		
		
		if(!handleGrdNur1035(grdNur1035, hospCode, userId, bunho)){
			throw new ExecutionException(response.setResult(false).build());
		}
		
		if(!handleGrdNur1036(grdNur1036, hospCode, userId)){
			throw new ExecutionException(response.setResult(false).build());
		}
		response.setResult(true);
		
		return response.build();
	}
	
	private boolean handleGrdNur1035(List<NuriModelProto.NUR1035U00grdNUR1035Info> grdNur1035, String hospCode, String userId, String bunho){
		for(NuriModelProto.NUR1035U00grdNUR1035Info item : grdNur1035){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				insertNur1035(item, hospCode, userId, bunho);
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(nur1035Repository.updateNUR1035U00grdNur1035(hospCode, userId, item.getMethodCode(), item.getStartDate(),
						item.getEndDate(), CommonUtils.parseDouble(item.getPknur1035())) < 0){
					return false;
				}
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(nur1035Repository.deleteNUR1035U00grdNur1035(hospCode, CommonUtils.parseDouble(item.getPknur1035())) < 0){
					return false;
				}
			}
		}
		return true;
	}
	
	private boolean handleGrdNur1036(List<NuriModelProto.NUR1035U00grdNUR1036Info> grdNur1036, String hospCode, String userId){
		for(NuriModelProto.NUR1035U00grdNUR1036Info item : grdNur1036){
			if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
				insertNur1036(item, hospCode, userId);
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
				if(nur1036Repository.updateNUR1035U00grdNur1036(hospCode, userId, item.getInputId(), item.getDangerAct(), item.getChangedSkin(),
						item.getEdema(), item.getNumbness(), item.getScratch(), item.getTubeTrouble(), item.getPetechia(), item.getRemark(),
						CommonUtils.parseDouble(item.getFknur1035()), item.getCheckDate(), item.getCheckTime()) < 0){
					return false;
				}
			}else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
				if(nur1036Repository.deleteNUR1035U00grdNur1036(hospCode, CommonUtils.parseDouble(item.getFknur1035()),
						item.getCheckDate(), item.getCheckTime()) < 0){
					return false;
				}
			}
		}
		return true;
	}
	
	private void insertNur1035(NuriModelProto.NUR1035U00grdNUR1035Info item, String hospCode, String userId, String bunho){
		Nur1035 nur1035 = new Nur1035();
		
		nur1035.setSysDate(new Date());
		nur1035.setSysId(userId);
		nur1035.setUpdDate(new Date());
		nur1035.setUpdId(userId);
		nur1035.setHospCode(hospCode);
		nur1035.setPknur1035(CommonUtils.parseDouble(item.getPknur1035()));
		nur1035.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		nur1035.setBunho(bunho);
		nur1035.setMethodCode(item.getMethodCode());
		nur1035.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		nur1035.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
		nur1035.setInputId(item.getInputId());
		
		nur1035Repository.save(nur1035);
	}
	
	private void insertNur1036(NuriModelProto.NUR1035U00grdNUR1036Info item, String hospCode, String userId){
		Nur1036 nur1036 = new Nur1036();
		nur1036.setSysDate(new Date());
		nur1036.setSysId(userId);
		nur1036.setUpdDate(new Date());
		nur1036.setUpdId(userId);
		nur1036.setHospCode(hospCode);
		nur1036.setFknur1035(CommonUtils.parseDouble(item.getFknur1035()));
		nur1036.setCheckDate(DateUtil.toDate(item.getCheckDate(), DateUtil.PATTERN_YYMMDD));
		nur1036.setCheckTime(item.getCheckTime());
		nur1036.setInputId(item.getInputId());
		nur1036.setDangerAct(item.getDangerAct());
		nur1036.setChangedSkin(item.getChangedSkin());
		nur1036.setEdema(item.getEdema());
		nur1036.setNumbness(item.getNumbness());
		nur1036.setScratch(item.getScratch());
		nur1036.setTubeTrouble(item.getTubeTrouble());
		nur1036.setPetechia(item.getPetechia());
		nur1036.setRemark(item.getRemark());
		
		nur1036Repository.save(nur1036);
	}
}
