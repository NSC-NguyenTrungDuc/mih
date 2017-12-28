package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.data.model.ihis.adma.IFS0001U00GrdDetailInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00GrdDetailRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0001U00GrdDetailResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0001U00GrdDetailHandler extends ScreenHandler<BassServiceProto.IFS0001U00GrdDetailRequest, BassServiceProto.IFS0001U00GrdDetailResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0001U00GrdDetailHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0002Repository ifs0002Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public IFS0001U00GrdDetailResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, IFS0001U00GrdDetailRequest request)
					throws Exception {
  	   	BassServiceProto.IFS0001U00GrdDetailResponse.Builder response = BassServiceProto.IFS0001U00GrdDetailResponse.newBuilder();    
  	   	String offset = request.getOffset();
	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<IFS0001U00GrdDetailInfo> listGrd = ifs0002Repository.getIFS0001U00GrdDetailInfo(getHospitalCode(vertx, sessionId), request.getCodeType(),startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(IFS0001U00GrdDetailInfo item : listGrd){
				BassModelProto.IFS0001U00GrdDetailInfo.Builder info = BassModelProto.IFS0001U00GrdDetailInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdDetailItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}