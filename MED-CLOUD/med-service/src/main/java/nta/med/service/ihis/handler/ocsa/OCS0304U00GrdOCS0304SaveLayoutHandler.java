package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0304;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0304Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0304U00GrdOCS0304ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304U00GrdOCS0304SaveLayoutRequest;
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
public class OCS0304U00GrdOCS0304SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCS0304U00GrdOCS0304SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Ocs0304Repository ocs0304Repository;                                                                      
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0304U00GrdOCS0304SaveLayoutRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();   
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		if(!CollectionUtils.isEmpty(request.getGrdOcs0304ListList())){
			for(OcsaOCS0304U00GrdOCS0304ListInfo item : request.getGrdOcs0304ListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResult(insert0304(item, request.getUserId(), hospCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(update0304(item, request.getUserId(), hospCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					response.setResult(delete0304(item, hospCode));
				}
			}
		}else {
			response.setResult(true);
		}
		return response.build();
	}
	// [START] CRUD 0304
	public boolean insert0304(OcsaOCS0304U00GrdOCS0304ListInfo item, String userId, String hospCode){
		Double Seq = 0.0;
		if(item.getSeq() != null && !item.getSeq().isEmpty()){
			Seq = CommonUtils.parseDouble(item.getSeq() );
		}
		Ocs0304 ocs0304 = new Ocs0304();
		ocs0304.setSysDate(new Date());
		ocs0304.setSysId(userId);
		ocs0304.setMemb(item.getMemb());
		if(item.getMembGubun() != null && !item.getMembGubun().isEmpty()){
			ocs0304.setMembGubun(item.getMembGubun());
		}else{
			ocs0304.setMembGubun("1");
		}
		ocs0304.setYaksokDirectCode(item.getYaksokDirectCode());
		ocs0304.setYaksokDirectName(item.getYaksokDirectName());
		ocs0304.setSeq(Seq);
		ocs0304.setMent(item.getMent());
		ocs0304.setHospCode(hospCode);
		ocs0304Repository.save(ocs0304);
		return true;
	}
	
	public boolean update0304(OcsaOCS0304U00GrdOCS0304ListInfo item, String userId, String hospCode){
		Double seq = 0.0;
		if(item.getSeq() != null && !item.getSeq().isEmpty() ){
			seq = CommonUtils.parseDouble(item.getSeq());
		}
		if(ocs0304Repository.updateOcsaOCS0304U00OCS0304(userId,seq,item.getYaksokDirectName(),item.getMemb(),
				item.getMent(),"1", item.getYaksokDirectCode(),hospCode) > 0){
			return true;
		}else{
			return false;
		}
	}
	private boolean delete0304(OcsaOCS0304U00GrdOCS0304ListInfo item, String hospCode){
		if(ocs0304Repository.deleteOcsaOCS0304U00OCS0304(
			item.getMemb(),
			"1", //item.getMembGubun(),
			item.getYaksokDirectCode(),
			hospCode) > 0){
			return true;
		}else{
			return false;
		}
	}
		 
	// [END] CRUD 0304
}