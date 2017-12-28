package nta.med.service.ihis.handler.bass;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0230;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0230Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0230U00GrdBas0230SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import nta.med.service.ihis.proto.CommonModelProto;

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
public class BAS0230U00GrdBas0230SaveLayoutHandler extends ScreenHandler<BassServiceProto.BAS0230U00GrdBas0230SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0230U00GrdBas0230SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Bas0230Repository bas0230Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0230U00GrdBas0230SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		response.setResult(false);
		List<CommonModelProto.BAS0230U00GrdBAS0230Info> listInfo = request.getItemInfoList();
		if(!CollectionUtils.isEmpty(listInfo)) {
			String userId = request.getUserId();
			String hospitalCode = getHospitalCode(vertx, sessionId);
			String language = getLanguage(vertx, sessionId);
			for (CommonModelProto.BAS0230U00GrdBAS0230Info info : listInfo) {
				if(DataRowState.ADDED.getValue().equals(info.getRowState())) {
					insertBas0230(info, userId, hospitalCode, language);
				} else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
					if (bas0230Repository.updateBAS0230U00(userId, new Date(), info.getBunName(), 
							hospitalCode, info.getBunCode(), 
							DateUtil.toDate(info.getBunYmd(), DateUtil.PATTERN_YYMMDD), language) <= 0) {
						throw new ExecutionException(response.build());
					}
				} else if(DataRowState.DELETED.getValue().equals(info.getRowState())) {
					if (bas0230Repository.deleteBAS0230U00(hospitalCode, info.getBunCode(), 
							DateUtil.toDate(info.getBunYmd(), DateUtil.PATTERN_YYMMDD), language) <= 0) {
						throw new ExecutionException(response.build());
					}
				}
			}
			response.setResult(true);
		}
		return response.build();
	}  
	
	private void insertBas0230(CommonModelProto.BAS0230U00GrdBAS0230Info info, String userId, String hospitalCode, String language){
		Bas0230 bas0230 = new Bas0230();
		bas0230.setSysDate(new Date());
		bas0230.setSysId(userId);
		bas0230.setUpdDate(new Date());
		bas0230.setUpdId(userId);
		bas0230.setHospCode(hospitalCode);
		bas0230.setBunCode(info.getBunCode());
		bas0230.setBunYmd(DateUtil.toDate(info.getBunYmd(), DateUtil.PATTERN_YYMMDD));
		bas0230.setBunName(info.getBunName());
		bas0230.setLanguage(language);
		bas0230Repository.save(bas0230);
	}
}