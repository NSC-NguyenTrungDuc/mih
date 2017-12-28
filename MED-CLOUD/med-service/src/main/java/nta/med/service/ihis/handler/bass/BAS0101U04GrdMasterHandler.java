package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0101Repository;
import nta.med.data.model.ihis.adma.BAS0101U04GrdMasterInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U04GrdMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U04GrdMasterResponse;

@Service                                                                                                          
@Scope("prototype")
public class BAS0101U04GrdMasterHandler extends ScreenHandler<BassServiceProto.BAS0101U04GrdMasterRequest, BassServiceProto.BAS0101U04GrdMasterResponse> {                     
	
	@Resource                                   
	private Bas0101Repository bas0101Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0101U04GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0101U04GrdMasterRequest request)
			throws Exception {                                                                   
	   	BassServiceProto.BAS0101U04GrdMasterResponse.Builder response = BassServiceProto.BAS0101U04GrdMasterResponse.newBuilder();    
	   	String offset = request.getOffset();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<BAS0101U04GrdMasterInfo> listItem = bas0101Repository.getBAS0101U04GrdMasterInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getCodeType(), startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0101U04GrdMasterInfo item : listItem){
				BassModelProto.BAS0101U04GrdMasterInfo.Builder builder = BassModelProto.BAS0101U04GrdMasterInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(builder);
			}
		}
		return response.build();
	} 
}
