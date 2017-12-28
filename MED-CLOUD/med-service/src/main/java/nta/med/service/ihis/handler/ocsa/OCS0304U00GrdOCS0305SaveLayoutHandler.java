package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0305;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0305Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0304U00GrdOCS0305ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304U00GrdOCS0305SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")         
@Transactional
public class OCS0304U00GrdOCS0305SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCS0304U00GrdOCS0305SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Ocs0305Repository ocs0305Repository;                                                                
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0304U00GrdOCS0305SaveLayoutRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();        
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		if(!CollectionUtils.isEmpty(request.getGrdOcs0305ListList())){
			for(OcsaOCS0304U00GrdOCS0305ListInfo item : request.getGrdOcs0305ListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResult(insert0305(item, request.getUserId(), hospCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(update0305(item, request.getUserId(), hospCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					response.setResult(delete0305(item, hospCode));
				}
			}
		} else {
			response.setResult(true);
		}
		return response.build();
	}         
	// [START] CRUD 0305
	 public boolean insert0305(OcsaOCS0304U00GrdOCS0305ListInfo item, String userId, String hospCode){
		 	Ocs0305 ocs0305 = new Ocs0305();
			ocs0305.setSysDate(new Date());
			ocs0305.setSysId(userId);
			ocs0305.setMemb(item.getMemb());
			
//			if(item.getDirectGubun() != null && !item.getDirectGubun().isEmpty()){
//				ocs0305.setMembGubun(item.getDirectGubun());
//			}else{
//				ocs0305.setMembGubun("1");
//			}
			
			ocs0305.setMembGubun("1");
			ocs0305.setYaksokDirectCode(item.getYaksokDirectCode());
			if(item.getPkSeq() != null && !item.getPkSeq().isEmpty()){
				ocs0305.setPkSeq(CommonUtils.parseDouble(item.getPkSeq()));
			}else{
				ocs0305.setPkSeq(1.0);
			}

			ocs0305.setDirectGubun(item.getDirectGubun());
			ocs0305.setDirectCode(item.getDirectCode());
			ocs0305.setDirectCont1(item.getDirectCont1());
			ocs0305.setDirectCont2(item.getDirectCont2());
			ocs0305.setDirectText(item.getDirectText());
			ocs0305.setHospCode(hospCode);
			ocs0305Repository.save(ocs0305);
			return true;
		}
		public boolean update0305(OcsaOCS0304U00GrdOCS0305ListInfo item, String userId, String hospCode){
			Double pkSeq = 0.0;
			if(item.getPkSeq() != null && !item.getPkSeq().isEmpty() ){
				pkSeq = CommonUtils.parseDouble(item.getPkSeq());
			}
			if(ocs0305Repository.updateOcsaOCS0304U00UOCS0305(userId, item.getDirectGubun(), 
					item.getDirectCode(),item.getDirectCont1(),item.getDirectCont2(),item.getDirectText(),
					item.getMemb(),"1",item.getYaksokDirectCode(),pkSeq,hospCode) > 0){
				return true;
			}else{
				return false;
			}
		}
		 private boolean delete0305(OcsaOCS0304U00GrdOCS0305ListInfo item, String hospCode){
			 Double pkSeq = 0.0;
				if(item.getPkSeq() != null && !item.getPkSeq().isEmpty()){
					pkSeq = CommonUtils.parseDouble(item.getPkSeq());
				}
				if(ocs0305Repository.deleteOcsaOCS0304U00OCS0305(
						item.getMemb(),
						"1", // MEMB_GUBUN
						item.getYaksokDirectCode(),
						pkSeq,
						hospCode) > 0){
					return true;
				}else{
					return false;
				}
		 }
		// [END] CRUD 0305
}