package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.ocs.Ocs0118;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0118Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0118U00GrdSaveLayoutInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0118U00GrdSaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")
public class OCS0118U00GrdSaveLayoutHandler extends ScreenHandler<OcsaServiceProto.OCS0118U00GrdSaveLayoutRequest,SystemServiceProto.UpdateResponse>  {                     
	@Resource                                                                                                       
	private Ocs0118Repository ocs0118Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0118U00GrdSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();     
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean save = false;
		if(!CollectionUtils.isEmpty(request.getGrdSaveLayoutInfoList())){
			for(OCS0118U00GrdSaveLayoutInfo info : request.getGrdSaveLayoutInfoList()){
				if(info.getRowState().equals(DataRowState.ADDED.getValue())){
					save = insertOcs0118(info, hospCode);
				}else if(info.getRowState().equals(DataRowState.MODIFIED.getValue())){
					save = updateOcs0118(info, hospCode);
				}else if(info.getRowState().equals(DataRowState.DELETED.getValue())){
					save = deleteOcs0118(info, hospCode);
				}
			}
		}
		response.setResult(save);
		return response.build();
	}  
	
	
	public boolean insertOcs0118(OcsaModelProto.OCS0118U00GrdSaveLayoutInfo info, String hospCode){
		Ocs0118 ocs0118 = new Ocs0118();
		ocs0118.setSysDate(new Date());
		ocs0118.setSysId(info.getSysId());
		ocs0118.setConvClass(info.getConvCls());
		ocs0118.setConvGubun(info.getConvGubun());
		ocs0118.setHangmogCode(info.getHangmogCode());
		ocs0118.setConvHangmog(info.getConvHangmog());
		ocs0118.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
		ocs0118.setRemark(info.getRemark());
		ocs0118.setHospCode(hospCode);
		ocs0118.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		ocs0118Repository.save(ocs0118);
		return true;
	}
	
	public boolean updateOcs0118(OcsaModelProto.OCS0118U00GrdSaveLayoutInfo info, String hospCode){
		if(ocs0118Repository.updateOCS0118U00GrdSaveLayout(info.getSysId(), info.getConvHangmog(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD), 
				info.getRemark(), info.getConvCls(), info.getConvGubun(), info.getHangmogCode(), hospCode)>0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean deleteOcs0118(OcsaModelProto.OCS0118U00GrdSaveLayoutInfo info, String hospCode){
		if(ocs0118Repository.deleteOCS0118U00GrdSaveLayout(info.getConvCls(), info.getConvGubun(), info.getHangmogCode(), hospCode)>0){
			return true;
		}else{
			return false;
		}
	}
}
