package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.adma.ADM3200R00grdADM3200Info;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM3200R00grdADM3200Request;


@Service                                                                                                          
@Scope("prototype")
public class ADM3200R00grdADM3200Handler extends ScreenHandler<AdmaServiceProto.ADM3200R00grdADM3200Request, AdmaServiceProto.ADM3200R00grdADM3200Response>{
	private static final Log LOGGER = LogFactory.getLog(ADM3200R00grdADM3200Handler.class);           
	
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;
	
//	@Override
//	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
//			ADM3200R00grdADM3200Request request) throws Exception {
//		setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup("323", "JA", "", 1));
//	}
	
	@Override
	@Transactional(readOnly = true)
	public AdmaServiceProto.ADM3200R00grdADM3200Response handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM3200R00grdADM3200Request request) throws Exception {
		AdmaServiceProto.ADM3200R00grdADM3200Response.Builder response = AdmaServiceProto.ADM3200R00grdADM3200Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
  	   	
		List<ADM3200R00grdADM3200Info> listItem = adm3200Repository.getADM3200R00grdADM3200Info(hospCode, request.getUserGroup(), request.getHoDong(), startNum, offset);
		if (!CollectionUtils.isEmpty(listItem)) {
			for (ADM3200R00grdADM3200Info item : listItem) {
				AdmaModelProto.ADM3200R00grdADM3200Info.Builder builder = AdmaModelProto.ADM3200R00grdADM3200Info.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addGrdMasterItem(builder);
			}
		}		
		
		return response.build();
	}

}
