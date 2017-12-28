package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0123;
import nta.med.core.glossary.DataRowState;
import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class BAS0123U00SaveLayoutHandler extends ScreenHandler<BassServiceProto.BAS0123U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0123U00SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Bas0123Repository bas0123Repository;                                                                    
	                                                                                                                
	@Override        
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0123U00SaveLayoutRequest request) throws Exception {                     
		String hospitalCode = getHospitalCode(vertx, sessionId);
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		if (!CollectionUtils.isEmpty(request.getItemInfoList())) {
			String userId = request.getUserId();
			for (BassModelProto.BAS0123U00GrdBAS0123Info item : request.getItemInfoList()){
				if (DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					boolean rs = insertBas0123(userId, item, hospitalCode);
					response.setResult(rs);
				} else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState()))  {
					bas0123Repository.updateBas0123(userId, new Date(), item.getZipName1(), item.getZipName2(), 
							item.getZipName3(), item.getZipNameGana1(), item.getZipNameGana2(), item.getZipNameGana3(), 
							item.getZipTonggye(), item.getZipCode());
					response.setResult(true);
					
				} else if (DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())) {
					bas0123Repository.deleteBas0123(item.getZipCode());
					response.setResult(true);
				}
			}
		}
		return response.build();
	}    
	
	private boolean insertBas0123(String userId, BassModelProto.BAS0123U00GrdBAS0123Info item, String hospitalCode) {
		String ck = bas0123Repository.checkExistBas0123U00(item.getZipCode(), item.getZipName1(), item.getZipName2(), item.getZipName3());
		if (!StringUtils.isEmpty(ck)) {
			if ("Y".equalsIgnoreCase(ck)) {
				return false;
			}
		}
		Bas0123 bas0123 = new Bas0123();
		bas0123.setSysDate(new Date());
		bas0123.setSysId(userId);
		bas0123.setUpdDate(new Date());
		bas0123.setUpdId(userId);
		bas0123.setZipCode(item.getZipCode());
		bas0123.setZipName1(item.getZipName1());
		bas0123.setZipName2(item.getZipName2());
		bas0123.setZipName3(item.getZipName3());
		bas0123.setZipNameGana1(item.getZipNameGana1());
		bas0123.setZipNameGana2(item.getZipNameGana2());
		bas0123.setZipNameGana3(item.getZipNameGana3());
		bas0123.setZipTonggye(item.getZipTonggye());
		bas0123.setZipCode1(item.getZipCode1());
		bas0123.setZipCode2(item.getZipCode2());
		bas0123Repository.save(bas0123);
		return true;
	}
}