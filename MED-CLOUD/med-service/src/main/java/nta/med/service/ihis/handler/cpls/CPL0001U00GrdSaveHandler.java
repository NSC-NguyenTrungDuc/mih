package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.cpl.Cpl0001;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.cpl.Cpl0001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto.CPL0001U00GrdSlipInfo;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0001U00GrdSaveRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL0001U00GrdSaveHandler extends ScreenHandler<CPL0001U00GrdSaveRequest, UpdateResponse> {

	@Resource
	private Cpl0001Repository cpl0001Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL0001U00GrdSaveRequest request)
			throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		boolean save = false;
		if(!CollectionUtils.isEmpty(request.getDtList())){
			String hospCode = getHospitalCode(vertx, sessionId);
			for(CPL0001U00GrdSlipInfo item : request.getDtList()){
				if(item.getRowState().equals(DataRowState.ADDED.getValue())){
					save = insertCpl0001(item, hospCode, request.getQUserId());
				}else if(item.getRowState().equals(DataRowState.MODIFIED.getValue())){
					save = updateCpl0001(item, hospCode, request.getQUserId());
				}else if(item.getRowState().equals(DataRowState.DELETED.getValue())){
					save = deleteCpl0001(item, hospCode);
				}
			}
		}
		response.setResult(save);
		return response.build();
	}
	
	private boolean insertCpl0001(CPL0001U00GrdSlipInfo item, String hospCode, String userId){
		Cpl0001 cpl0001 = new Cpl0001();
		cpl0001.setSysDate(new Date());
		cpl0001.setSysId(userId);
		cpl0001.setUpdId(userId);
		cpl0001.setUpdDate(new Date());
		cpl0001.setSlipCode(item.getSlipCode());
		cpl0001.setSlipName(item.getSlipName());
		cpl0001.setSlipNameRe(item.getSlipNameRe());
		cpl0001.setJundalGubun(item.getJundalGubun());
		cpl0001.setHospCode(hospCode);
		cpl0001Repository.save(cpl0001);
		return true;
	}
	
	private boolean updateCpl0001(CPL0001U00GrdSlipInfo item, String hospCode, String userId){
		if(cpl0001Repository.updateCPL0001U00GrdSave(
				userId, 
				new Date(), 
				item.getSlipName(), 
				item.getSlipNameRe(), 
				item.getJundalGubun(), 
				hospCode, 
				item.getSlipCode())>0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean deleteCpl0001(CPL0001U00GrdSlipInfo item, String hospCode){
		if(cpl0001Repository.deleteCPL0001U00GrdSave(
				hospCode, 
				item.getSlipCode())>0){
			return true;
		}else{
			return false;
		}
	}
}
