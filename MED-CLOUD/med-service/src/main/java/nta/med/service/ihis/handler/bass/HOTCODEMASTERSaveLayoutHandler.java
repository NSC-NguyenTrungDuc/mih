package nta.med.service.ihis.handler.bass;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.adm.AdmHotcode;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.BaseRepository;
import nta.med.data.dao.medi.adm.AdmHotCodeRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.HOTCODEMASTERGetGrdListInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.HOTCODEMASTERSaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class HOTCODEMASTERSaveLayoutHandler extends ScreenHandler<BassServiceProto.HOTCODEMASTERSaveLayoutRequest, SystemServiceProto.UpdateResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(HOTCODEMASTERSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private AdmHotCodeRepository admHotCodeRepository;    
	@Resource
	private BaseRepository baseRepository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			HOTCODEMASTERSaveLayoutRequest request) throws Exception {
		 SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		 List<HOTCODEMASTERGetGrdListInfo> listInfo = request.getLayoutItemList();
		 List<AdmHotcode> listAdmHotCode = new ArrayList<AdmHotcode>();
		 String userId = request.getUserId();
		 if("Y".equalsIgnoreCase(request.getTruncateYn())){
			 Integer result = admHotCodeRepository.truncateAdmHotCode();
		 }
		 if(!CollectionUtils.isEmpty(listInfo)){
			 for(HOTCODEMASTERGetGrdListInfo item : listInfo){
				 Date date = new Date();
				 Timestamp timeStamp = new Timestamp(date.getTime());
				 Date sgYmd = DateUtil.toDate(item.getSgYmd().trim(), DateUtil.PATTERN_YYMMDD_BLANK);
				 
				 AdmHotcode admHotCode = new AdmHotcode();
				 BeanUtils.copyProperties(item, admHotCode, getLanguage(vertx, sessionId));
				 admHotCode.setClassif(item.getClsif());
				 admHotCode.setSgYmd(sgYmd);
				 admHotCode.setCreated(timeStamp);
				 admHotCode.setUpdated(timeStamp);
				 admHotCode.setSysId(userId);
				 admHotCode.setUpdId(userId);
				 admHotCode.setActiveFlg(new BigDecimal(1));
				 listAdmHotCode.add(admHotCode);
			 }
			 baseRepository.saveObjects(listAdmHotCode);
		 }
		response.setResult(true);
		return response.build();
	}                                                                                                                 
}