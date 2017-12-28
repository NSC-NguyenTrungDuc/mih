package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.ocs.Ocs0306;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0306Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto.OcsaOCS0304U00GrdOCS0306ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0304U00GrdOCS0306SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class OCS0304U00GrdOCS0306SaveLayoutHandler
	extends ScreenHandler<OcsaServiceProto.OCS0304U00GrdOCS0306SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0304U00GrdOCS0306SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0306Repository ocs0306Repository;                                                                   
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0304U00GrdOCS0306SaveLayoutRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();     
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		if(!CollectionUtils.isEmpty(request.getGrdOcs0306ListList())){
			for(OcsaOCS0304U00GrdOCS0306ListInfo item : request.getGrdOcs0306ListList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResult(insert0306(item, request.getUserId(), hospCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(update0306(item, request.getUserId(), hospCode));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					response.setResult(delete0306(item, hospCode));
				}
			}
		} else {
			response.setResult(true);
		}
		return response.build();
	}
	// [START] CRUD 0306
	public boolean insert0306(OcsaOCS0304U00GrdOCS0306ListInfo item, String userId, String hospCode){
		 Ocs0306 ocs0306 = new Ocs0306();
	     ocs0306.setSysDate(new Date());
	     ocs0306.setSysId(userId); 
	     ocs0306.setMemb(item.getMemb());
	     if(item.getDirectGubun() != null && !item.getDirectGubun().isEmpty()){
	     	ocs0306.setMembGubun(item.getDirectGubun());
	     }else{
	     	ocs0306.setMembGubun("1");
	     }
	     ocs0306.setYaksokDirectCode(item.getYaksokDirectCode());
	     ocs0306.setBogyongCode(item.getBogyongCode()); 
	     if(item.getBomSourceKey()!= null && !item.getBomSourceKey().isEmpty()){
	     	ocs0306.setBomSourceKey(CommonUtils.parseDouble(item.getBomSourceKey()));        
	     }
	     ocs0306.setBomYn(item.getBomYn()    );              
	     ocs0306.setDirectCode(item.getDirectCode() );          
	     ocs0306.setDirectDetail(item.getDirectDetail()  );       
	     ocs0306.setDirectGubun(item.getDirectGubun()     );   
	     if(item.getDv()!= null && !item.getDv().isEmpty()){  
	     	ocs0306.setDv(CommonUtils.parseDouble(item.getDv()));       
	     }   
	     ocs0306.setDvTime(item.getDvTime());
	     ocs0306.setHangmogCode(item.getHangmogCode()    );     
	     ocs0306.setHospCode(hospCode);             
	     if(item.getInsulinFrom()!= null && !item.getInsulinFrom().isEmpty()){
	     	ocs0306.setInsulinFrom(CommonUtils.parseDouble(item.getInsulinFrom()));       
	     }  
	     ocs0306.setJusaCode(item.getJusaCode()  );           
	     ocs0306.setJusaSpdGubun(item.getJusaSpdGubun() );   
	     if(item.getNalsu()!= null && !item.getNalsu().isEmpty()){
	     	ocs0306.setNalsu(CommonUtils.parseDouble(item.getNalsu()));        
	     }
	     ocs0306.setOrdDanui(item.getOrdDanui()   );    
	     if(item.getPkSeq()!= null && !item.getPkSeq().isEmpty()){
	     	ocs0306.setPkSeq(CommonUtils.parseDouble(item.getPkSeq()));        
	     }
	     if(item.getSeq()!= null && !item.getSeq().isEmpty()){     
	     	ocs0306.setSeq(CommonUtils.parseDouble(item.getSeq()));       
	     }
	     if(item.getSuryang()!= null && !item.getSuryang().isEmpty()){
	     	ocs0306.setSuryang(CommonUtils.parseDouble(item.getSuryang()));        
	     }      
	     ocs0306.setTimeGubun(item.getTimeGubun());                                 
	     ocs0306.setYaksokDirectCode(item.getYaksokDirectCode() );   
	     ocs0306Repository.save(ocs0306);
	     return true;
	}
	public boolean update0306(OcsaOCS0304U00GrdOCS0306ListInfo item, String userId, String hospCode){
		Double seq = 0.0;
		Double suryang = 0.0;
		Double nalsu = 0.0;
		Double dv = 0.0;
		Double insulinFrom = 0.0;
		Double insulinTo = 0.0;
		Double bomSourceKey = 0.0;
		Double pkSeq = 0.0;
		if(item.getSeq() != null && !item.getSeq().isEmpty() ){
			seq = CommonUtils.parseDouble(item.getSeq());
		}			
		if(item.getSuryang() != null && !item.getSuryang().isEmpty() ){
			suryang = CommonUtils.parseDouble(item.getSuryang());
		}			
		if(item.getNalsu() != null && !item.getNalsu().isEmpty() ){
			nalsu = CommonUtils.parseDouble(item.getNalsu());
		}			
		if(item.getDv() != null && !item.getDv().isEmpty() ){
			dv = CommonUtils.parseDouble(item.getDv());
		}			
		if(item.getInsulinFrom() != null && !item.getInsulinFrom().isEmpty() ){
			insulinFrom = CommonUtils.parseDouble(item.getInsulinFrom());
		}			
		if(item.getInsulinTo() != null && !item.getInsulinTo().isEmpty() ){
			insulinTo = CommonUtils.parseDouble(item.getInsulinTo());
		}			
		if(item.getBomSourceKey() != null && !item.getBomSourceKey().isEmpty() ){
			bomSourceKey = CommonUtils.parseDouble(item.getBomSourceKey());
		}			
		if(item.getPkSeq() != null && !item.getPkSeq().isEmpty() ){
			pkSeq = CommonUtils.parseDouble(item.getPkSeq());
		}

		if(ocs0306Repository.updateOcsaOCS0304U00UOCS0306(
				userId,
				seq, 
				item.getHangmogCode(),
				suryang,
				nalsu,
				item.getOrdDanui(),
				item.getBogyongCode(),
				item.getJusaCode(),
				item.getJusaSpdGubun(),
				dv,
				item.getDvTime(),
				insulinFrom,
				insulinTo,
				item.getTimeGubun(),
				item.getBomYn(),
				bomSourceKey,
				item.getMemb(),
				"1",
				item.getYaksokDirectCode(),
				item.getDirectGubun(),
				item.getDirectCode(),
				pkSeq,
				hospCode) > 0){
			return true;
		}else{
			return false;
		}
	}
	
	private boolean delete0306(OcsaOCS0304U00GrdOCS0306ListInfo item, String hospCode){
	 	Double pkSeq = 0.0;
		if(item.getPkSeq() != null && !item.getPkSeq().isEmpty()){
			pkSeq = CommonUtils.parseDouble(item.getPkSeq());
		}
		LOGGER.info("DELETE pkSeq="+ pkSeq);
		if(ocs0306Repository.deleteOcsaOCS0304U00OCS0306(
						item.getMemb(),
						"1", //membGubun
						item.getYaksokDirectCode(),
						pkSeq,
						hospCode) > 0 ){
			LOGGER.info("DELETE SUCCESSFULLY");
			return true;
		}else{
			LOGGER.info("DELETE UNSUCCESSFULLY");
			return false;
		}
	}
	// [END] CRUD 0306
}