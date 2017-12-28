package nta.med.service.ihis.handler.system;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0380Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CheckHangSangInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.CheckHangSangInfoResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
public class CheckHangSangInfoHandler
	extends ScreenHandler<SystemServiceProto.CheckHangSangInfoRequest, SystemServiceProto.CheckHangSangInfoResponse> {                     
	
	@Resource                                                                                                       
	private Bas0380Repository bas0380Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CheckHangSangInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CheckHangSangInfoRequest request)
			throws Exception {                                                                  
  	   	SystemServiceProto.CheckHangSangInfoResponse.Builder response = SystemServiceProto.CheckHangSangInfoResponse.newBuilder();                      
		CommonModelProto.CheckHangSangInfo info = request.getHangSangInfo();
		Date checkDate = DateUtil.toDate(info.getAppDate(), DateUtil.PATTERN_YYMMDD);
		Date birthDate = DateUtil.toDate(info.getBirthDate(), DateUtil.PATTERN_YYMMDD);
		String result = bas0380Repository.checkHangSangInfo(getHospitalCode(vertx, sessionId), info.getHangmogCode(), info.getSangCode(),
				checkDate, info.getInOutGubun(), info.getGwa(), birthDate);
		if(!StringUtils.isEmpty(result)){
			CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
			builder.setDataValue(result);
			response.setResultCheck(builder);
		}
		return response.build();
	}
}
